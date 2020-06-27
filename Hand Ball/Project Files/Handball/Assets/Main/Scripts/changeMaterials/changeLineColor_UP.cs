using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeLineColor_UP : MonoBehaviour
{
    LineRenderer lineRenderer;

    [SerializeField] [Range(0f, 1f)]public float lerpTime;

    [SerializeField] public Color[] myColor;

    int colorIndex = 0;

    float t = 0;

    int len;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        len = myColor.Length;
    }

    void Update()
    {
        lineRenderer.material.color = Color.Lerp(lineRenderer.material.color, myColor[colorIndex], lerpTime);

        t = Mathf.Lerp(t, 1f, lerpTime);

        if(t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
