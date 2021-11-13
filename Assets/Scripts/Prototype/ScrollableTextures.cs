using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollableTextures : MonoBehaviour
{
    // Start is called before the first frame update
    public float scrollX;
    public float scrollY;
    // Update is called once per frame
    void Update()
    {
        float offsetX = Time.time * scrollX;
        float offsetY = Time.time * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offsetX,offsetY);
    }
}
