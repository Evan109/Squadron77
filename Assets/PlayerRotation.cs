using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

    public GameObject mainAimObj;
    public float rotateSpeed = 1;
    public Constrain constrainX;
    public Constrain constrainY;
    public Constrain constrainZ;


    // Use this for initialization
    void Start()
    {
        constrainX.value = constrainX.active ? 0 : 1;
        constrainY.value = constrainY.active ? 0 : 1;
        constrainZ.value = constrainZ.active ? 0 : 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (mainAimObj != null)
        {
            var thisPos = this.transform.position;
            var targetPos = mainAimObj.transform.position;
            var vectorToTarget = targetPos - thisPos;
            var thisRotate = this.transform.rotation;
            var targetRotate = Quaternion.LookRotation(vectorToTarget);
            var newRotate = Quaternion.Lerp(thisRotate, targetRotate, rotateSpeed * Time.deltaTime).eulerAngles;
            this.transform.eulerAngles = new Vector3(
                newRotate.x * constrainX.value,
                newRotate.y * constrainY.value,
                newRotate.z * constrainZ.value
            );
        }
    }
}

[System.Serializable]
public class Constrain
{
    public bool active;
    [HideInInspector]
    public float value;
}