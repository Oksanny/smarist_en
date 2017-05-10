using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class FixedWidthCamera : MonoBehaviour
{
    public float screenWidth = 600;

    private Camera camera;

    private float size;
    private float ratio;
    private float screenHeight;

    void Awake()
    {
        camera = GetComponent<Camera>();
        ratio = (float)Screen.height / (float)Screen.width;
        screenHeight = screenWidth * ratio;
        size = screenHeight / 200;
        camera.orthographicSize = size;
    }

    void Update()
    {
        camera = GetComponent<Camera>();
        ratio = (float)Screen.height / (float)Screen.width;
        screenHeight = screenWidth * ratio;
        size = screenHeight / 200;
        camera.orthographicSize = size;
    }
}