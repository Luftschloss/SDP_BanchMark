using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OtherAA_RT : MonoBehaviour
{
    UniversalAdditionalCameraData universalAdditionalCameraData;

    void Start()
    {
        universalAdditionalCameraData = GetComponent<UniversalAdditionalCameraData>();
    }

    public void SetCamAA(int index)
    {
        int quality = index - 2;
        index = Mathf.Clamp(index, 0, 2);
        universalAdditionalCameraData.antialiasing = (AntialiasingMode)index;
        quality = Mathf.Clamp(quality, 0, 10);
        universalAdditionalCameraData.antialiasingQuality = (AntialiasingQuality)quality;
    }

    public void SetDepth(bool open)
    {
        universalAdditionalCameraData.requiresDepthTexture = open;
    }

    public void SetOpaque(bool open)
    {
        universalAdditionalCameraData.requiresColorTexture = open;
    }
}