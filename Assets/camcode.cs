using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camcode : MonoBehaviour
{
    public Camera ViveCamera;
    public Camera OtherCamera;
    public Transform Source;
    public Transform Destination;

    //public static Quaternion rotate;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPositionInSourceSpace = Source.InverseTransformPoint(ViveCamera.transform.position);
        Quaternion cameraRotationInSourceSpace = Quaternion.Inverse(Source.rotation) * ViveCamera.transform.rotation;

        OtherCamera.transform.position = Destination.TransformPoint(cameraPositionInSourceSpace);
        OtherCamera.transform.rotation = (Destination.rotation * cameraRotationInSourceSpace);
        OtherCamera.transform.rotation = Quaternion.FromToRotation(Vector3.up, -Vector3.up);
        //OtherCamera.transform.rotation = ViewScript.rotate;
    }
}