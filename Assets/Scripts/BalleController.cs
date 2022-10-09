//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalleController : MonoBehaviour
{
    [SerializeField] private GameObject cible;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("cible"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
            
            Destroy(this.gameObject);
            
            Destroy(collision.gameObject,1f);
            Instantiate(cible, new Vector3(Random.Range(-50f,50f),Random.Range(2f,6f),Random.Range(-50f,50f)),Quaternion.identity).GetComponent<Renderer>().material.color = Color.red;

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
