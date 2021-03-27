using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter
{
    //usage
    //Fighter name = Fighter.newFighter("Attack", 1, 1, 1);
    //name.method(input)

    public string type;
    public int ult1;
    public int ult2;
    public int ult3;
    public int Barrier;
    public int Shield;
    public Boolean ShieldActive;
    public int Armor;
    public int Hull;
    public double damagemuliplier;
    public double resistancemultiplier;
    public double heat;
    public double systemhealth;
    
    //constructors
    public void newFighter()
    {
        this.type = "Attack";
        this.ult1 = 1;
        this.ult1 = 2;
        this.ult1 = 3;
        
    }
    public void newFighter(string type,int ult1, int ult2, int ult3)
    {
        if(type == "Attack" || type == "Defense" || type == "Support")
        {
            this.type = type;
        }
        else
        {
            this.type = "Attack";
        }
        this.ult1 = ult1;
        this.ult2 = ult2;
        this.ult3 = ult3;
    }
    //getters
    public string getType()
    {
        return this.type;
    }
    public int getATKUlt()
    {
        return this.ult1;
    }
    public int getDEFUlt()
    {
        return this.ult2;
    }
    public int getSUPUlt()
    {
        return this.ult3;
    }
    public int[] getHealth()
    {
        int[] rt = { this.Hull, this.Armor, this.Shield, this.Barrier };
        return rt;
    }
    public Boolean getShieldStatus()
    {
        return ShieldActive;
    }
    //setters
    public Boolean applyDamage(int amount)
    {
        //returns if damage applied kills, modifies values in accordance with damage.
        int left = amount;
        if(this.Barrier >= left && this.Barrier != 0)
        {
            this.Barrier -= left;
            left = 0;
        }
        else
        {
            left = left - Barrier;
            Barrier = 0;
        }
        if (ShieldActive)
        {
            if (this.Shield >= left && this.Shield != 0)
            {
                this.Shield -= left;
                left = 0;
            }
            else
            {
                left = left - this.Shield;
                this.Shield = 0;
            }
        }
        if (this.Armor >= left && this.Armor != 0)
        {
            this.Armor -= left;
            left = 0;
        }
        else
        {
            left = left - this.Armor;
            this.Armor = 0;
        }
        if (this.Hull >= left && this.Hull != 0)
        {
            this.Barrier -= left;
            left = 0;
        }
        else
        {
            this.Hull = 0;
            return false;
            //kills Fighter.
        }
        return true;
    }
    public void newUlt(string ulttype,int ultnumber)
    {
        if (ulttype == "Attack") this.ult1 = ultnumber;
        if (ulttype == "Defense") this.ult2 = ultnumber;
        if (ulttype == "Support") this.ult3 = ultnumber;
    }
    public void newUltSet(int ult1,int ult2,int ult3)
    {
        this.ult1 = ult1;
        this.ult2 = ult2;
        this.ult3 = ult3;
    }
    public void fightertype(string type)
    {
        if (type == "Attack") this.type = type;
        if (type == "Defense") this.type = type;
        if (type == "Support") this.type = type;
    }

}
