using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MoveHP : MonoBehaviour
{
    public GameObject aclone;

    // Update is called once per frame
    void Update()
    {
        transform.Translate((-1*Vector3.forward) * 400 * Time.deltaTime);
    }
}
