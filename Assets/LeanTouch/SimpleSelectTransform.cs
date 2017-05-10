using UnityEngine;

// This script allows you to transform the GameObject selected by SimpleSelect
public class SimpleSelectTransform : SimpleSelect
{
	public bool AllowTranslate = true;

	public bool AllowRotate = true;

	public bool AllowScale = true;
    public Camera Camera;
	protected virtual void Update()
	{
		// Make sure we have something selected
		if (SelectedGameObject != null)
		{
			// Make sure the main camera exists
			if (Camera != null)
			{
				if (AllowTranslate == true)
				{
					Translate(SelectedGameObject.transform, Lean.LeanTouch.DragDelta);
				}

				if (AllowRotate == true)
				{
					Rotate(SelectedGameObject.transform, Lean.LeanTouch.TwistDegrees);
				}

				if (AllowScale == true)
				{
					Scale(SelectedGameObject.transform, Lean.LeanTouch.PinchScale);
				}
			}
		}
	}

	public void Translate(Transform transform, Vector2 screenPositionDelta)
	{
	    //float y = transform.position.y;
		// Screen position of the transform
	    if (screenPositionDelta.x!=0||screenPositionDelta.y!=0)
	    {
            Debug.Log("Translate");
            Debug.Log("Camera=" + Camera.name);
            Debug.Log("screenPositionDelta=" + screenPositionDelta);
	    }
       
		var screenPosition = Camera.WorldToScreenPoint(transform.position);
			
		// Add the deltaPosition
		screenPosition += (Vector3)screenPositionDelta;
			
		// Convert back to world space
		transform.position = Camera.ScreenToWorldPoint(screenPosition);
       // transform.position=new Vector3(transform.position.x,y,transform.position.z);
	}

	public void Rotate(Transform transform, float angleDelta)
	{
		transform.rotation *= Quaternion.Euler(0.0f,angleDelta,0.0f);
	}

	public void Scale(Transform transform, float scale)
	{
		// Make sure the scale is valid
		if (scale > 0.0f)
		{
			// Grow the local scale by scale
			transform.localScale *= scale;
		}
	}
}