using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : PlayersControlled
{
    private void Start()
    {
        healthbar.OnInit(100);
        OnInit();
    }
    public override void OnInit()
    {
        base.OnInit();
    }

    public override void DealDamage(float damage)
    {
        base.DealDamage(damage);
    }

}
