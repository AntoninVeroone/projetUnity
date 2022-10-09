using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject balle;
    [SerializeField] private GameObject cible;
    [SerializeField] private float impulsion;
    [SerializeField] private float speed;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        for (var i = 0; i < 50; i++)
        {
            Instantiate(cible, new Vector3(Random.Range(-50f, 50f), Random.Range(2f, 6f), Random.Range(-50f, 50f)),
                Quaternion.identity).GetComponent<Renderer>().material.color = Color.red;
        }
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

        /*Quaternion.Euler(
            0f,
            cameraTransform.eulerAngles.y + 90f,
            cameraTransform.eulerAngles.x + 90f));*/
        //balleInstance.GetComponent<Renderer>().material.color = Color.grey;
        Rigidbody balleRigidbody = balleInstance.GetComponent<Rigidbody>();
        balleRigidbody.AddForce(cameraTransform.forward * (1000f * impulsion));
    }

    private void PlayerRotate()
    {
        playerTransform.eulerAngles += new Vector3(0f, Input.GetAxis("Mouse X"), 0f);

        cameraTransform.eulerAngles += new Vector3(
            Input.GetAxis("Mouse Y") * -1f,
            0f,
            0f);
    }

    private void PlayerMove()
    {
        var move = Quaternion.Euler(
                       0f,
                       playerTransform.eulerAngles.y,
                       0f) *
                   new Vector3(
                       Input.GetAxis("Horizontal"),
                       0f,
                       Input.GetAxis("Vertical")) * (speed * Time.deltaTime);

        //playerTransform.position += move;
        rb.MovePosition(playerTransform.position + move);
    }


    private void FixedUpdate()
    {
        PlayerMove();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotate();

        if (Input.GetButtonDown("Jump")) rb.AddForce(playerTransform.up * 20000f);

        if (Input.GetButtonDown("Fire1")) SpawnBalle();
    }
}