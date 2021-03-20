using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapBlock : MonoBehaviour
{
    public float degreesPerInterval = 15.0f;

    private float rotX;
    private float rotY;
    private float rotZ;

    public void SnappableBlock()
    {
        rotX = Mathf.Round(transform.localRotation.eulerAngles.x / degreesPerInterval) * degreesPerInterval;
        rotY = Mathf.Round(transform.localRotation.eulerAngles.y / degreesPerInterval) * degreesPerInterval;
        rotZ = Mathf.Round(transform.localRotation.eulerAngles.z / degreesPerInterval) * degreesPerInterval;

        Debug.Log(transform.localRotation.eulerAngles);
        Debug.Log("x: " + rotX + ", y: " + rotY + ", z: " + rotZ);
        transform.localRotation.eulerAngles.Set(rotX, rotY, rotZ);
        //transform.localRotation.eulerAngles.Set(rotX, rotY, rotZ);
        //transform.localRotation = transform.localRotation.eulerAngles + Quaternion.Euler(rotX, rotY, rotZ);
        Debug.Log(transform.localRotation.eulerAngles);
    }
}
