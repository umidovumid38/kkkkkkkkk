using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public float Sensitivity = 200;
    public Transform Player;
    public Transform Pivot;
    public float MinY = -25;
    public float MaxY = 50;

    private float YRotation;

    private void Update()
    {
        float X = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float Y = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        YRotation -= Y;
        YRotation = Mathf.Clamp(YRotation, MinY, MaxY);

        Pivot.position = Player.position;
        transform.localRotation = Quaternion.Euler(YRotation,0,0);
        Pivot.Rotate(X * Vector3.up);
    }
}
