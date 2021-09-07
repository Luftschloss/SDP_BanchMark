using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T3DTest : MonoBehaviour
{
    public GameObject[] t2dGos;
    private Vector3 startPos;
    [Range(1,10)]
    private float maxDistance = 5;
    Transform camTF;
    Vector3 dir;

    private void Awake()
    {
        SetT2DActive(0);
        camTF = Camera.main.transform;
        startPos = camTF.position;
        dir = camTF.forward;
    }

    public void SetT2DActive(int index)
    {
        for (int i = 0; i < t2dGos.Length; i++)
        {
            t2dGos[i].SetActive(i == index);
        }
    }

    public void SetDistanceToGo(float value)
    {
        camTF.position = startPos - dir * maxDistance * value;
    }
}
