using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{

    private GameObject canvas;
    float xFactor = Screen.width / 1125f;
    float yFactor = Screen.height / 2436f;
    // Start is called before the first frame update
    void Start()
    {
        //canvas.transform.localScale
        //Screen.SetResolution(1125, 2436, true);
        // Camera.main.rect = new Rect(0, 0, 1, xFactor / yFactor);
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
