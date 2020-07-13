using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float range = 150;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        RaycastHit rHit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out rHit, range))
        {
            print("Hit something: " + rHit.transform.name);
        }
    }
}