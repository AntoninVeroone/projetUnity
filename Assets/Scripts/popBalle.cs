using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popBalle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private GameObject balle;
    [SerializeField] private GameObject cible;
    [SerializeField] private float impulsion;
    [SerializeField] private float vitesseGeneration;
    [SerializeField] private float speed;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        for (var i = 0; i < 50; i++)
        {
            Instantiate(cible, new Vector3(Random.Range(-50f,50f),Random.Range(2f,6f),Random.Range(-50f,50f)),Quaternion.identity).GetComponent<Renderer>().material.color = Color.red;
        }
        //Coroutine maCoroutine = StartCoroutine(BalleSpawn());
    }

    private void SpawnBalle()
    {
        GameObject balleInstance = Instantiate(
            balle,
            cameraTransform.position,
            Quaternion.Euler(
                0f, 
                cameraTransform.eulerAngles.y + 90f,
                cameraTransform.eulerAngles.x + 90f));

        Rigidbody balleRigidbody = balleInstance.GetComponent<Rigidbody>();
        balleRigidbody.AddForce(cameraTransform.forward * 1000f * impulsion);
    }


    /*private IEnumerator BalleSpawn()
    {
        SpawnBalle();
        yield return new WaitForSeconds(2f);


        //spawn de balle chaque seconde
        while (true)
        {
            SpawnBalle();
            yield return new WaitForSeconds(1 / vitesseGeneration);
        }
    }*/

    // Update is called once per frame
    void Update()
    {
        var tempPos = cameraTransform.position;
        Cursor.visible = true;
        cameraTransform.position += Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0) * new Vector3(
            Input.GetAxis("Horizontal"),
            0f,
            Input.GetAxis("Vertical")) * speed * Time.deltaTime;
        
        cameraTransform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y") * -1f,
            Input.GetAxis("Mouse X"),
            0f);
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnBalle();
        }
        
    }
}