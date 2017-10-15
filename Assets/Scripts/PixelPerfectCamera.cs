using UnityEngine;
using System.Collections;

//Script will work if the camera projection is orthographic 
//Native resolution is set to 240 * 160
//This script was referenced from lynda tutorial
public class PixelPerfectCamera : MonoBehaviour {

    void Start()
    {
        // Switch to 1024 x 768 fullscreen
        Screen.SetResolution(1024, 768, true);
    }

}
