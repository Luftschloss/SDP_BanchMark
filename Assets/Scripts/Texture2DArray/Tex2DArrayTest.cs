using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Tex2DArrayTest : MonoBehaviour
{
    public Texture2D[] textures;

    public Material[] ComMats;

    public Material[] T2DMats;

    public bool IsT2D;

    void Start()
    {
        if(IsT2D)
        {
            Texture2DArray texArr = new Texture2DArray(textures[0].width, textures[0].height, textures.Length, textures[0].format, true, false);

            // 结论 //
            // Graphics.CopyTexture耗时(单位:Tick): 5914, 8092, 6807, 5706, 5993, 5865, 6104, 5780 //
            // Texture2DArray.SetPixels耗时(单位:Tick): 253608, 255041, 225135, 256947, 260036, 295523, 250641, 266044 //
            // Graphics.CopyTexture 明显快于 Texture2DArray.SetPixels 方法 //
            // Texture2DArray.SetPixels 方法的耗时大约是 Graphics.CopyTexture 的50倍左右 //
            // Texture2DArray.SetPixels 耗时的原因是需要把像素数据从cpu传到gpu, 原文: Call Apply to actually upload the changed pixels to the graphics card //
            // 而Graphics.CopyTexture只在gpu端进行操作, 原文: operates on GPU-side data exclusively //
            // 考虑使用Graphics.CopyTexture来复制Texture还有一个好处是可不勾选源纹理为可读写的也行。

            for (int i = 0; i < textures.Length; i++)
            {
                for (int j = 0; j < textures[i].mipmapCount; j++)
                {
                    Graphics.CopyTexture(textures[i], 0, j, texArr, i, j);
                    
                }
                T2DMats[i].SetFloat("_Index", i);
                ComMats[i].mainTexture = textures[i];
            }
            texArr.wrapMode = TextureWrapMode.Clamp;
            texArr.filterMode = FilterMode.Bilinear;
            foreach (var mat in T2DMats)
            {
                mat.SetTexture("_TexArr", texArr);
            }
        }
        int idx = 0;
        foreach (var mr in GetComponentsInChildren<MeshRenderer>())
        {
            mr.material = IsT2D ? T2DMats[idx] : ComMats[idx];
            idx++;
            idx %= 5;
        }
    }
}