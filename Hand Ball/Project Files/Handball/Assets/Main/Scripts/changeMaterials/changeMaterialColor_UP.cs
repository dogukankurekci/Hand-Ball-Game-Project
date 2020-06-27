using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeMaterialColor_UP : MonoBehaviour
{
    MeshRenderer meshRenderer;

    [SerializeField] [Range(0f, 1f)]public float lerpTime;

    [SerializeField] public Color[] myColor;

    int colorIndex = 0;

    float t = 0;

    int len;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        len = myColor.Length;
    }

    void Update()
    {
        meshRenderer.material.color = Color.Lerp(meshRenderer.material.color, myColor[colorIndex], lerpTime);

        t = Mathf.Lerp(t, 1f, lerpTime);

        if(t > .9f)
        {
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
