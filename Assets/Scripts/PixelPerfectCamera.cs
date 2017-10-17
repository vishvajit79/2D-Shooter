using UnityEngine;
using System.Collections;

public class PixelPerfectCamera : MonoBehaviour
{
    //Script will work if the camera projection is orthographic 
    //Native resolution is set to 240 * 160
    //This script was referenced from lynda tutorial

    public static float pixelsToUnits = 1f;
    public static float scale = 1f;

    public Vector2 nativeResolution = new Vector2(240, 160);

    void Awake()
    {
        var camera = GetComponent<Camera>();

        if (camera.orthographic)
        {
            scale = Screen.height / nativeResolution.y;
            pixelsToUnits *= scale;
            camera.orthographicSize = (Screen.height / 2.0f) / pixelsToUnits;
        }
    }

}


