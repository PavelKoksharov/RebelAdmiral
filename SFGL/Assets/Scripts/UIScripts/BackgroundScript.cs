using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    public Material mat;
    public Material[] backgrounds;

    private void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat = backgrounds[Random.Range(0, backgrounds.Length)];
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
