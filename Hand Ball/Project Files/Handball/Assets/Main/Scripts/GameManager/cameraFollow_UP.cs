using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow_UP : MonoBehaviour
{
    
    public bool zoomActive;
    public bool zoomTarget = false;

    public float speed;

    public Vector3[] target;

    private Camera cam;


    void Start()
    {
        cam = Camera.main;
        cam.transform.position = Vector3.MoveTowards(cam.transform.position, target[0], speed);
    }


    void Update()
    {
        if (!zoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, speed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, target[0], speed);
        }
        if(zoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, speed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, target[1], speed);
        }

        if (zoomTarget)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3, speed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, target[2], speed);
        }
    }
}
