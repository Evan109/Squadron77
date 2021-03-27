using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPWobble : MonoBehaviour
{
    public GameObject shipobj;
    double Xin = 0;
    double Yin = 0;
    double Zin = 0;
    double Rollin = 0;
    double activeRoll = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Translate((Vector3.right) * (int)(Math.Cos(Xin) * 2) * Time.deltaTime);
        transform.Translate((Vector3.up) * (int)(Math.Cos(Yin) * 4) * Time.deltaTime);
        transform.Translate((Vector3.forward) * (int)(Math.Cos(Zin) * 6) * Time.deltaTime);
        transform.Rotate(0, 0,(float)(Rollin/10));
        Xin -= 0.015;
        Yin += 0.02;
        Zin += 0.006;
        Rollin = (Math.Cos(activeRoll));
        activeRoll += 0.04;

    }
}
