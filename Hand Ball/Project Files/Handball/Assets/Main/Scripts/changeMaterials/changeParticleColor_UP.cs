using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeParticleColor_UP : MonoBehaviour
{
    TrailRenderer trailRenderer;

    [SerializeField] [Range(0f, 1f)]public float lerpTime;

    [SerializeField] public Color[] myColor;

    int colorIndex = 0;

    float t = 0;

    int len;

    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
        len = myColor.Length;
    }

    void Update()
    {
        trailRenderer.material.color = Color.Lerp(trailRenderer.material.color, myColor[colorIndex], lerpTime);

        t = Mathf.Lerp(t, 1f, lerpTime);

        if(t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
