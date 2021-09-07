using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySetting : MonoBehaviour
{
    public float ratito = 0.85f;

    void Start()
    {
        Screen.SetResolution((int)(Screen.width * ratito), (int)(Screen.height * ratito), true);
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;
        SetQuality(0); 
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
}
