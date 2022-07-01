using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
    public Material waterMat;
    private float offset;
    public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
       offset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        offset += Time.deltaTime * scrollSpeed;
        waterMat.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }
}
