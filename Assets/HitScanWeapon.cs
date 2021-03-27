using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScanWeapon
{
    int damage;
    Boolean isBurst = false;
    GameObject parent;
    public double offsetx;
    public double offsety;
    public double offsetz;
    public Quaternion lookdir;
    public int cooldown;
    public double cooldowntime;
            //cooldown is current time until able to fire.
    public RaycastHit lastHit;
    public float Hitcheck;
    public Boolean hitreg = false;
            //use this to register a hit, changed to true when a hit is landed and changed to false by a gamemanager when the hit is
            //registered and damage is dealt, value should be checked every frame by game manager.
    


    public void newHitScanWeapon()
    {
        //test purposes only
        parent = null;
        offsetx = 0;
        offsety = 0;
        offsetz = 0;
        lookdir = Quaternion.identity;
    }
    public void newHitScanWeapon(double offsetx,double offsety,double offsetz)
    {
        parent = null;
        offsetx = 0;
        offsety = 0;
        offsetz = 0;
        Quaternion lookdir = Quaternion.identity;
    }
    public void newHitScanWeaponMirror(HitScanWeapon other)
    {
        this.parent = other.parent;
        this.lookdir = other.lookdir;
        this.damage = other.damage;
        //TODO: modify xyz offset so new Mirror is on the other side of the ship (mirrored across 0,0,0?)
        this.offsetx = other.offsetx;
        this.offsety = other.offsety;
        this.offsetz = other.offsetz;

    }
    public void Fire()
    {
        if (cooldowntime == 0) 
        {
            if(isBurst)
            {
            this.FireOnce();
                //Invoke("FireOnce", 0.3);
                //Invoke("FireOnce", 0.6);
                //startCooldown(1);
                //TODO
                Debug.Log("BURST WEAPON NOT IMPLEMENTED, DEFAULTED TO SINGLE");
                this.startCooldown(1);
            }
        else
        {
            this.FireOnce();
            this.startCooldown(1);
        }
        }
        //ADD DAMAGE DEALING METHOD
    }
    public void FireOnce()
    {
        if(cooldown <= 0)
        {
            //update lookdir here and convert to vector3 for raycast
            Vector3 gunpos = new Vector3((float)(parent.transform.position.x + this.offsetx), (float)(parent.transform.position.y+this.offsety), (float)parent.transform.position.z);
            gunpos.x = (float)(gunpos.x + offsetx);
            gunpos.y = (float)(gunpos.y + offsety);
            gunpos.z = (float)(gunpos.z + offsetz);
            this.hitreg = Physics.Raycast(gunpos, parent.transform.forward, Hitcheck ,2000, QueryTriggerInteraction.Collide);
        }
    }

    public void startCooldown(double boostmultiplier) //boost 0 is gay, uses boost 1 instead.
    {
        if (boostmultiplier != 0)
        {
            cooldowntime = (double)(cooldown * boostmultiplier);
        }
        else
        {
            cooldowntime = (double)cooldown;
        }
           
    }
}
