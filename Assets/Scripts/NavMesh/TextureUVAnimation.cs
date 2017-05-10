using UnityEngine;
using System.Collections;

public class TextureUVAnimation :
    MonoBehaviour 
{
    
 	public float uvOffsetSpeedX = 0.0f; 
    public float uvOffsetSpeedY = 0.0f;
    Vector2 offset;
	
	public bool pingPong;
	
    bool _pause = false;

	// Use this for initialization
	void Start () 
    {
        offset = new Vector2( 0.0f, 0.0f );
	}

    public bool pause
    {
        set { _pause = value; }
        get { return _pause; }
    }
	
	private float dirX = 1f;
	private float dirY = 1f;
	
	public float minX = -1f; 
	public float maxX = 1f;
	
	public float minY = -1f; 
	public float maxY = 1f;
	
	
	// Update is called once per frame
	void Update () 
    {
        if (_pause)
            return;

        // build offset        
		if(pingPong) {
	        offset = new Vector2( offset.x + dirX * Time.deltaTime * uvOffsetSpeedX,
	                              offset.y + dirY * Time.deltaTime * uvOffsetSpeedY);
		
			if(offset.x > maxX) {
				offset.x = 2 * maxX - offset.x;
				dirX = -dirX;
			} else 
			if(offset.x < minX) {
				offset.x = 2 * minX - offset.x;
				dirX = -dirX;
			}

			if(offset.y > maxY) {
				offset.y = 2 * maxY - offset.y;
				dirY = -dirY;
				
			} else 
			if(offset.y < minY) {
				offset.y = 2 * minY - offset.y;
				dirY = -dirY;
			}
		} else {
	        offset = new Vector2( offset.x + Time.deltaTime * uvOffsetSpeedX,
	                              offset.y + Time.deltaTime * uvOffsetSpeedY);
			
			if(offset.x > maxX) {
				offset.x = offset.x - maxX + minX;
			} else 
			if(offset.x < minX) {
				offset.x = offset.x + maxX - minX;
			}
			
			if(offset.y > maxY) {
				offset.y = offset.y - maxY + minY;
			} else 
			if(offset.y < minY) {
				offset.y = offset.y + maxY - minY;
			}
		}
		   
        if(GetComponent<Renderer>())
            GetComponent<Renderer>().material.SetTextureOffset ("_MainTex", offset);       
	}
}