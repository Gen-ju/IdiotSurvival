using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float _RotSpeed = 5f;
    Rigidbody _RigidBody;
    // Start is called before the first frame update
    void Start()
    {
        _RigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rot = new Vector3(0, Time.deltaTime * _RotSpeed, 0);
        //transform.eulerAngles = rot;
        Quaternion q = Quaternion.Euler(rot);
        _RigidBody.MoveRotation(_RigidBody.rotation * q);
    }
}
