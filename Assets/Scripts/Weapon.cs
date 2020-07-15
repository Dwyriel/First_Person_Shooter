using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float range = 150;
    [SerializeField] float damage = 15f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;

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
            CreateHitImpart(rHit);
            EnemyHealth target;
            if ((target = rHit.transform.GetComponent<EnemyHealth>()) != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void CreateHitImpart(RaycastHit hit)
    {
        var vfx = Instantiate(hitEffect, hit.point, Quaternion.Euler(hit.normal));
        Destroy(vfx, .1f);
    }
}