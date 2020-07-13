﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        hitPoints = hitPoints - damage;
        if(hitPoints <= 0f)
        {
            Destroy(this.gameObject); //todo change later
        }
    }
}
