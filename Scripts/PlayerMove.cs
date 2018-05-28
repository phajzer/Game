using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMove : MonoBehaviour {
    [Header("Settings")]
    public float lookSensivity = 100.0f;
    public float moveSensivity = 100.0f;
    public float clampAngle = 80.0f;
    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    [Header("FireSettings")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Rigidbody rb;
 

    void Start ()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;

        rb = GetComponent<Rigidbody>();
      
    }
 
    void Update ()
    {
        float leftX = CrossPlatformInputManager.GetAxis("HorizontalLeft");
        float leftY = -CrossPlatformInputManager.GetAxis("VerticalLeft");

        float rightX = CrossPlatformInputManager.GetAxis("HorizontalRight");
        float rightZ = CrossPlatformInputManager.GetAxis("VerticalRight");

        rotY += leftX * lookSensivity * Time.deltaTime;
        rotX += leftY * lookSensivity * Time.deltaTime;
 
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
 
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        Vector3 mov = new Vector3(rightX, 0.0f, rightZ);
        rb.AddRelativeForce(mov * moveSensivity);

        if (Input.GetKeyDown("w"))
        {
            Fire();
        }
    }

    private void Fire()
    {
       
        var bullet = (GameObject)Instantiate(bulletPrefab,
            firePoint.position,
            firePoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        Destroy(bullet, 20.0f);
    }
}
