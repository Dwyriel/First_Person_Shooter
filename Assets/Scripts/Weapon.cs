using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float range = 150;
    [SerializeField] float damage = 15f;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        muzzleFlash.Play(); //todo make it better
        Raycasting();
    }

    private void Raycasting()
    {
        RaycastHit rHit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out rHit, range))
        {
            print("Hit something: " + rHit.transform.name); 
            EnemyHealth target;
            if ((target = rHit.transform.GetComponent<EnemyHealth>()) != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}