using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public class PrintTrail : MonoBehaviour
{
    [SerializeField]
    GameObject primitive;

    List<TrailRenderer> _trails;

    [SerializeField]
    Camera camera;

    [SerializeField]
    Transform spawnPoint;

    private void Awake()
    {
        _trails = new List<TrailRenderer>();
    }


    public void PrintMiniature()
    {
        GameObject[] trails = GameObject.FindGameObjectsWithTag("Trail");
        if (trails.Length>0)
        {

            GameObject printObj = Instantiate(primitive, spawnPoint.position, spawnPoint.rotation);
            printObj.SetActive(false);

            //CombineInstance[] combine = new CombineInstance[trails.Length];

            Mesh mesh = printObj.GetComponent<MeshFilter>().mesh;

            for (int i = 0; i < trails.Length; i++)
            {
                trails[i].GetComponent<TrailRenderer>().BakeMesh(mesh, camera);
                //combine[i].mesh = mesh;
            }
            //printObj.GetComponent<MeshFilter>().mesh = new Mesh();
            //printObj.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
            printObj.AddComponent<BoxCollider>();
            printObj.SetActive(true);
        }
    }
}

