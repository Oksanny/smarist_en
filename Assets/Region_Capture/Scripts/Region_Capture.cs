using System;
using System.Collections;
using UnityEngine;
using Vuforia;

#if UNITY_EDITOR
#pragma warning disable 0414
#endif

public class Region_Capture : MonoBehaviour
{
    public Camera camera;
    public Camera ARCAmera;
    public Transform target;
    public Transform s1;
    public Transform s2;
    public Transform s3;
    public Transform s4;
    private Camera Child_AR_Camera;
    private GameObject AR_Camera_Vector;
	private Renderer m_renderer;
    [Space(10)] 
    public GameObject ARCamera;
    public GameObject ImageTarget;
    public GameObject BackgroundPlane;
    public bool flag=true;
    [Space(20)]
    public bool AutoRegionSize = true;
    public bool HideFromARCamera = true;
    public bool CheckMarkerPosition = false;
    [Space(20)]
    public bool ColorDebugMode = false;

    //[HideInInspector]
    public bool MarkerIsOUT, MarkerIsIN;
    private int countFrame;
    private bool Is_Child_ImageTarget, reverse_matrix;
	private float tmp00_init, tmp01_init, tmp02_init, tmp00_updt, tmp01_updt, tmp02_updt;
	private int frame_num;
    public static Texture2D VideoBackgroundTexure;
	public static float CPH,CPW,vuforia_ios_magic;
	private TrackableBehaviour mTrackableBehaviour;

    private void Start()
    {
		mTrackableBehaviour = ImageTarget.GetComponent<Vuforia.TrackableBehaviour>();
        
        if (!m_renderer) m_renderer = GetComponent<Renderer>();
        AR_Camera_Vector = GameObject.Find("AR Camera Vector");

        if (AR_Camera_Vector == null)
        {
            AR_Camera_Vector = new GameObject("AR Camera Vector");
        }

        if (GetComponentInParent<ImageTargetBehaviour>()) Is_Child_ImageTarget = true;

        if (ARCamera == null || ImageTarget == null || BackgroundPlane == null)
        {
            Debug.LogWarning("ARCamera, ImageTarget or BackgroundPlane not assigned!");
            enabled = false;
        }
        else
        {
            if (AutoRegionSize)
            {
                var imageTargetBehaviour = ImageTarget.GetComponent<ImageTargetBehaviour>();
                if (Is_Child_ImageTarget)
                {
                    transform.localPosition = Vector3.zero;
                    transform.localEulerAngles = Vector3.zero;


                    if (imageTargetBehaviour.GetSize().x > imageTargetBehaviour.GetSize().y)
                        transform.localScale =
							new Vector3(0.1f, 0.1f,imageTargetBehaviour.GetSize().y/imageTargetBehaviour.GetSize().x*0.1f);
                    else
                        transform.localScale =
                            new Vector3(imageTargetBehaviour.GetSize().x/imageTargetBehaviour.GetSize().y*0.1f, 0.1f, 0.1f);
                }

                else
                {
                    transform.position = ImageTarget.transform.position;
                    transform.localRotation = ImageTarget.transform.localRotation;
                    transform.localScale =
                        new Vector3(imageTargetBehaviour.GetSize().x, 10.0f, imageTargetBehaviour.GetSize().y)/10.0f;
                }
            }

            Child_AR_Camera = ARCamera.GetComponentInChildren<Camera>();
            gameObject.layer = 20;

            if (HideFromARCamera && !ColorDebugMode)
                Child_AR_Camera.cullingMask &= ~(1 << LayerMask.NameToLayer("Region_Capture"));

            if (ColorDebugMode)
            {
                m_renderer.material.SetInt("_KR", 0);
                m_renderer.material.SetInt("_KG", 1);
            }

            CPH = Child_AR_Camera.pixelHeight;
            CPW = Child_AR_Camera.pixelWidth;

			vuforia_ios_magic = 1.0f;

            StartCoroutine(Start_Initialize());
            StartCoroutine(CheckVideoMode());
        }

		////////////////////////////////////////////////////////////////////////////////////////////
		//								IOS Devices Names
		//
		//   http://www.everyi.com/by-identifier/ipod-iphone-ipad-specs-by-model-identifier.html
		//
		////////////////////////////////////////////////////////////////////////////////////////////


		if (SystemInfo.deviceModel.Contains ("iPad5,3") || SystemInfo.deviceModel.Contains ("iPad5,4"))
			reverse_matrix = true;

    }


    private void Initialize()
    {
        var meshFilter = BackgroundPlane.GetComponent<MeshFilter>();
        if (VuforiaRenderer.Instance.IsVideoBackgroundInfoAvailable())
        {
            var videoTextureInfo = VuforiaRenderer.Instance.GetVideoTextureInfo();

            if (videoTextureInfo.imageSize.x == 0 || videoTextureInfo.imageSize.y == 0) goto End;

            var k_x = videoTextureInfo.imageSize.x/(float) videoTextureInfo.textureSize.x*0.5f;
            var k_y = videoTextureInfo.imageSize.y/(float) videoTextureInfo.textureSize.y*0.5f;

            m_renderer.material.SetFloat("_KX", k_x);
            m_renderer.material.SetFloat("_KY", k_y);

            VideoBackgroundTexure = VuforiaRenderer.Instance.VideoBackgroundTexture as Texture2D;

            if (!VideoBackgroundTexure || !meshFilter) goto End;

            m_renderer.material.SetTexture("_MainTex", VideoBackgroundTexure);

            AR_Camera_Vector.transform.parent = ARCamera.transform;
            AR_Camera_Vector.transform.localPosition = Vector3.zero;
            AR_Camera_Vector.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            AR_Camera_Vector.transform.localEulerAngles = new Vector3(0.0f, 180.0f, 180.0f);

			#if !UNITY_EDITOR && !UNITY_STANDALONE

				var P = VuforiaUnity.GetProjectionGL(0, 0, 0);

					tmp00_init = P.m00;
					tmp01_init = P.m01;
					tmp02_init = P.m02;

				if (CameraDevice.Instance.GetCameraDirection() == CameraDevice.CameraDirection.CAMERA_FRONT) AR_Camera_Vector.transform.localEulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);

				if (Screen.orientation == ScreenOrientation.LandscapeRight || Screen.orientation == ScreenOrientation.LandscapeLeft) 
					vuforia_ios_magic = -1.0f;

				if (Screen.orientation == ScreenOrientation.Portrait) {
					if (Application.platform == RuntimePlatform.IPhonePlayer && tmp02_init < 0) vuforia_ios_magic = -2.0f;
					else vuforia_ios_magic = 1.0f;
					if (SystemInfo.deviceModel.Contains ("iPhone5,3") || SystemInfo.deviceModel.Contains ("iPhone5,4")) vuforia_ios_magic = -1.0f;
				}

				if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
					if (Application.platform == RuntimePlatform.IPhonePlayer && tmp02_init > 0) vuforia_ios_magic = 2.0f;
					else vuforia_ios_magic = -1.0f;
					if (SystemInfo.deviceModel.Contains ("iPhone5,3") || SystemInfo.deviceModel.Contains ("iPhone5,4")) vuforia_ios_magic = 1.0f;
				}

			#endif


			#if UNITY_EDITOR || UNITY_STANDALONE
                AR_Camera_Vector.transform.localPosition = new Vector3(0.0f, ImageTarget.GetComponent<ImageTargetBehaviour>().GetSize().x/240.0f, 0.0f);

			#else
				float aspect = (float)videoTextureInfo.imageSize.x / (float)videoTextureInfo.imageSize.y;
				if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				AR_Camera_Vector.transform.localScale = new Vector3 (1.0f / aspect, aspect, 1.0f);
				}
			#endif

            End:

			if (videoTextureInfo.imageSize.x == 0 || videoTextureInfo.imageSize.y == 0 || !VideoBackgroundTexure || !meshFilter) {
				StartCoroutine (Start_Initialize ());
			}

        }
        else
        {
            StartCoroutine(Start_Initialize());
        }
    }

    private void LateUpdate()
    {
        if (AutoRegionSize && !Is_Child_ImageTarget)
        {
            transform.position = ImageTarget.transform.position;
            transform.localRotation = ImageTarget.transform.localRotation;
        }

        var M = transform.localToWorldMatrix;
        var V = AR_Camera_Vector.transform.worldToLocalMatrix;
        var P = VuforiaUnity.GetProjectionGL(0, 0, 0);

	#if !UNITY_EDITOR && !UNITY_STANDALONE

		tmp00_updt = P.m00;
		tmp01_updt = P.m01;
		tmp02_updt = P.m02;

		if (tmp00_updt != tmp00_init || tmp01_updt != tmp01_init || tmp02_updt != tmp02_init) StartCoroutine(Start_Initialize());

		if (Screen.orientation == ScreenOrientation.LandscapeRight) P.m02 *= vuforia_ios_magic;
		if (Screen.orientation == ScreenOrientation.LandscapeLeft) P.m12 *= vuforia_ios_magic;

		if (Screen.orientation == ScreenOrientation.Portrait || Screen.orientation == ScreenOrientation.PortraitUpsideDown) {

		if (reverse_matrix) {

			P.m02 = -P.m12;
			P.m12 = -tmp02_updt;
			}

			P.m02 /= vuforia_ios_magic;
			P.m12 *= vuforia_ios_magic;

		}

	#endif

        m_renderer.material.SetMatrix("_MATRIX_MVP", P*V*M);

		if (mTrackableBehaviour != null && (int)mTrackableBehaviour.CurrentStatus > 1) {
			m_renderer.material.SetFloat ("_Alpha", 1);
			m_renderer.enabled = true;
		} 

		else {
			m_renderer.material.SetFloat ("_Alpha", 0);
			frame_num += 1;

			if (frame_num > 3) {
				m_renderer.enabled = false;
				frame_num = 0;
			}
		}

        if (CheckMarkerPosition || ColorDebugMode)
        {
          // Debug.Log("AR =" + Quaternion.Angle(ARCamera.transform.rotation, target.rotation));
            var boundPoint1 = m_renderer.bounds.min;
            var boundPoint2 = m_renderer.bounds.max;
            var boundPoint3 = new Vector3(boundPoint1.x, boundPoint1.y, boundPoint2.z);
            var boundPoint4 = new Vector3(boundPoint2.x, boundPoint1.y, boundPoint1.z);
            float a = 0;
            if (Screen.width<Screen.height)
            {
                a = Screen.width;
            }
            if (Screen.height < Screen.width)
            {
                a = Screen.height;
            }
           // Debug.Log("a="+a);
        // s1.position = new Vector3(boundPoint1.x, boundPoint1.y, boundPoint1.z);
        // s2.position = new Vector3(boundPoint2.x, boundPoint2.y, boundPoint2.z);
        // s3.position = new Vector3(boundPoint3.x, boundPoint3.y, boundPoint3.z);
        // s4.position = new Vector3(boundPoint4.x, boundPoint4.y, boundPoint4.z);

           s1.position = Child_AR_Camera.ScreenToWorldPoint(new Vector3(0.5f * (Screen.width - a), 0.5f * (Screen.height - a), 10f));
           s2.position = Child_AR_Camera.ScreenToWorldPoint(new Vector3(0.5f * (Screen.width - a), 0.5f * (Screen.height + a), 10f));
           s3.position = Child_AR_Camera.ScreenToWorldPoint(new Vector3(0.5f * (Screen.width + a), 0.5f * (Screen.height - a), 10f));
           s4.position = Child_AR_Camera.ScreenToWorldPoint(new Vector3(0.5f * (Screen.width + a), 0.5f * (Screen.height + a), 10f));
            //Debug.Log("V_1=" + Child_AR_Camera.pixelHeight);
           // Debug.Log("V_2=" + boundPoint2);
            var screenPos1 = Child_AR_Camera.WorldToScreenPoint(boundPoint1);
            var screenPos2 = Child_AR_Camera.WorldToScreenPoint(boundPoint2);
            var screenPos3 = Child_AR_Camera.WorldToScreenPoint(boundPoint3);
            var screenPos4 = Child_AR_Camera.WorldToScreenPoint(boundPoint4);
            if (DataLevel.Instance.GetCheckLetter()&&!DataLevel.Instance.GetCheckCaptureTexture())
            {
                if ((screenPos1.x < 0 || screenPos1.y < 0 || screenPos2.x < 0 || screenPos2.y < 0 || screenPos3.x < 0 ||
                    screenPos3.y < 0 || screenPos4.x < 0 || screenPos4.y < 0 || screenPos1.x > CPW || screenPos1.y > CPH ||
                    screenPos2.x > CPW || screenPos2.y > CPH || screenPos3.x > CPW || screenPos3.y > CPH ||
                    screenPos4.x > CPW || screenPos4.y > CPH))
                {
                   // Debug.Log("NO FOUND");
                }
                else
                {
                    float d1 = Mathf.Sqrt(Mathf.Pow(screenPos1.x - screenPos2.x, 2) + Mathf.Pow(screenPos1.y - screenPos2.y, 2));
                    float d2 = Mathf.Sqrt(Mathf.Pow(screenPos3.x - screenPos4.x, 2) + Mathf.Pow(screenPos3.y - screenPos4.y, 2));
                    if ((d1 * 100f / (a * Math.Sqrt(2f)) > 90f && d1 * 100f / (a * Math.Sqrt(2f)) < 100f && d2 * 100f / (a * Math.Sqrt(2f)) > 90f && d2 * 100f / (a * Math.Sqrt(2f)) <100f))
                        
                    {
                        if (true||Mathf.Abs(Quaternion.Angle(ARCamera.transform.rotation, target.rotation)) <= 10.0f)
                        {
                            Debug.Log("Found");
                            StartCoroutine(Start_MarkerIsReturned());
                            //DataLevel.Instance.CurrentContent.SetActive(true);
                            
                        }
                       

                        
                    }
                    else
                    {
                      //  Debug.Log("SMALL");
                    }
                }
            }
          //  if (screenPos1.x < 0 || screenPos1.y < 0 || screenPos2.x < 0 || screenPos2.y < 0 || screenPos3.x < 0 ||
          //     screenPos3.y < 0 || screenPos4.x < 0 || screenPos4.y < 0 || screenPos1.x > CPW || screenPos1.y > CPH ||
          //     screenPos2.x > CPW || screenPos2.y > CPH || screenPos3.x > CPW || screenPos3.y > CPH ||
          //     screenPos4.x > CPW || screenPos4.y > CPH)
          // {
          //     countFrame = 0;
          //     if (!MarkerIsOUT&&flag)
          //     {
          //         StartCoroutine(Start_MarkerOutOfBounds());
          //
          //         MarkerIsOUT = true;
          //         MarkerIsIN = false;
          //     }
          // }
          // else
          // {
          //     if (flag&&!MarkerIsIN && Mathf.Abs(Quaternion.Angle(ARCamera.transform.rotation, target.rotation))<=30.0f)
          //     {
          //         StartCoroutine(Start_MarkerIsReturned());
          //
          //         MarkerIsIN = true;
          //         flag = false;
          //     }
          //     countFrame ++;
          //    
          //     
          //     
          //     MarkerIsOUT = false;
          // }
        }
    }

    private void MarkerOutOfBounds()
    {
        // Add action here if marker out of bounds

        Debug.Log("Marker out of bounds!");

        if (ColorDebugMode)
        {
            m_renderer.material.SetInt("_KR", 1);
            m_renderer.material.SetInt("_KG", 0);
        }
    }

    private void MarkerIsReturned()
    {
        // Add action here if marker is visible again
        if (true ||DataLevel.Instance.SetTexture)
        {
            Debug.Log("Marker is returned!");
            RenderTexture CameraOutputTexture = GetComponent<RenderTextureCamera>().GetRenderTexture();
            if (CameraOutputTexture!=null)
            {
                Texture2D FrameTexture = new Texture2D(CameraOutputTexture.width, CameraOutputTexture.height, TextureFormat.RGB24, false);
                RenderTexture.active = CameraOutputTexture;
                FrameTexture.ReadPixels(new Rect(0, 0, CameraOutputTexture.width, CameraOutputTexture.height), 0, 0);
                RenderTexture.active = null;

                FrameTexture.Apply();
                FrameTexture.EncodeToPNG();
                for (int i = 0; i < ImageTarget.GetComponent<ColorDefaultTrackableEventHandler>().ContentGameObject.Length; i++)
                {
                    Debug.Log("material=" + ImageTarget.GetComponent<ColorDefaultTrackableEventHandler>().MaterialContent.name);
                    ImageTarget.GetComponent<ColorDefaultTrackableEventHandler>().ContentGameObject[i].GetComponent<Renderer>().material.SetTexture("_MainTex", FrameTexture);
                    //ImageTarget.GetComponent<ColorDefaultTrackableEventHandler>().MaterialContent.SetTexture("_MainTex", FrameTexture);
                }
               
                MarkerIsIN = true;
                flag = false;
                DataLevel.Instance.SetCheckCaptureTexture(true);
                DataLevel.Instance.ChangedSate(Mark.ar_camera);
                 //DataLevel.Instance.SetTexture = false;
            }
           
        }
        
        if (ColorDebugMode)
        {
            m_renderer.material.SetInt("_KR", 0);
            m_renderer.material.SetInt("_KG", 1);
        }
    }

    private IEnumerator Start_Initialize()
    {
        yield return new WaitForEndOfFrame();
        Initialize();
    }


    private IEnumerator CheckVideoMode()
    {
        var rtc = GetComponent<RenderTextureCamera>();

        while (true)
        {
            yield return new WaitForSeconds(1);
            if (Math.Abs(CPH - Child_AR_Camera.pixelHeight) > Mathf.Epsilon ||
                Math.Abs(CPW - Child_AR_Camera.pixelWidth) > Mathf.Epsilon)
            {
                CPH = Child_AR_Camera.pixelHeight;
                CPW = Child_AR_Camera.pixelWidth;

                StartCoroutine(Start_Initialize());
                if (rtc && rtc.enabled)
                    rtc.RecalculateTextureSize();
            }
            yield return null;
        }
    }


    private IEnumerator Start_MarkerOutOfBounds()
    {
        yield return new WaitForEndOfFrame();
        MarkerOutOfBounds();
    }

    private IEnumerator Start_MarkerIsReturned()
    {
        yield return new WaitForEndOfFrame();
        MarkerIsReturned();
    }

    public void RecalculateRegionSize()
    {
        Start();
	//var imageTargetBehaviour = ImageTarget.GetComponent<ImageTargetBehaviour>();
    //
    //transform.position = ImageTarget.transform.position;
    //transform.localRotation = ImageTarget.transform.localRotation;
	//transform.localScale = new Vector3(imageTargetBehaviour.GetSize().x, 10.0f, imageTargetBehaviour.GetSize().y)/10.0f;
    }

}