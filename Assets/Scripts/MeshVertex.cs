using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshVertex : MonoBehaviour
{
    public int Vertexs = 0;
    // Start is called before the first frame update
    void Start()
    {
        List<Vector3> vector3s = new List<Vector3>(Vertexs);
        List<int> vs = new List<int>();

        for(int i = 0; i < Vertexs; i++)
        {
            float x = Random.Range(-5.5f, 5.5f);
            float y = Random.Range(-2.5f, 3.5f);
            float z = Random.Range(-2.5f, 2.5f);

            vector3s.Add(new Vector3(x, y , z));
            
            vs.Add(i);
        }

        int j = Vertexs % 3;

        if(j == 1)
        {
            vs.Add(0);
            vs.Add(1);
        }
        else if(j == 2)
        {
            vs.Add(0);
        }

        Mesh mesh = new Mesh()
        {
            vertices = vector3s.ToArray(),
            triangles = vs.ToArray(),
        };

        mesh.RecalculateNormals();

        this.gameObject.transform.position = Vector3.zero;
        this.gameObject.AddComponent<MeshFilter>().mesh = mesh;
        this.gameObject.AddComponent<MeshRenderer>().material = Resources.Load<Material>("New Material");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
