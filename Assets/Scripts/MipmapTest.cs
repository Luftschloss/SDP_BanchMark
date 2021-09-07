using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MipmapTest : MonoBehaviour
{
    public Texture2D[] Mipmaps;



    private void Start()
    {
        Texture2D mipmapTex = new Texture2D(512, 512, TextureFormat.RGBA32, true);
        for (int i = 0; i < Mipmaps.Length; i++)
        {
            Graphics.CopyTexture(Mipmaps[i], 0, 0, mipmapTex, 0, i);
        }
        mipmapTex.wrapMode = TextureWrapMode.Clamp;
        mipmapTex.filterMode = FilterMode.Bilinear;
        foreach (var mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.material.mainTexture = mipmapTex;
        }
    }
}
