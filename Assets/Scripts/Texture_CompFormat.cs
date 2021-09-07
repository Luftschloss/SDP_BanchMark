using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Texture_CompFormat : MonoBehaviour
{

    public GameObject[] TextureRoot;

    private void Awake()
    {
        SetRootActive(0);
    }

    public void SetRootActive(int index)
    {
        for (int i = 0; i < TextureRoot.Length; i++)
        {
            TextureRoot[i].SetActive(i == index);
        }
    }
}
