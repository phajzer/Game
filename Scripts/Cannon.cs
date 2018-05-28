using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    [Header("Settings")]
    
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        
         var target = GameObject.Find("Ship(Clone)").transform;
        
         
        float distanceToPLayer = Vector3.Distance(transform.position, target.position);
        if(distanceToPLayer <= range)
        {
            Vector3 rot = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(rot);
            
            partToRotate.rotation = lookRotation;
            if(fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;
            }

            fireCountdown -= Time.deltaTime;

        }
        
	}
    
    void Shoot()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab,
             firePoint.position,
             firePoint.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        Destroy(bullet, 20.0f);

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
