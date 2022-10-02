using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCube : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform monTransform;
    [SerializeField] private GameObject monPrefab;
    [SerializeField] private float radius;
    [SerializeField] private float nbCubes;
    [SerializeField] private float X;
    [SerializeField] private float Y;
    [SerializeField] private float Z;
    
    
    void Start()
    {
        for(var i=0; i<nbCubes;i++)
        {
            Instantiate(monPrefab,new Vector3(radius * Mathf.Cos(i*2*Mathf.PI/nbCubes)+X,radius * Mathf.Sin(i*2*Mathf.PI/nbCubes)+Y,Z+0f),Quaternion.identity);
           
        }

    }

    // Update is called once per frame
    void Update()
    {
        monTransform.position = new Vector3(X, Y, Z);
    }
}
