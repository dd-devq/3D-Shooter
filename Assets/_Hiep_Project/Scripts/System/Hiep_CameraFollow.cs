using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiep_CameraFollow : MonoBehaviour
{
    public Transform target;
    private Transform trans;
    public float speed = 2;
    private Vector3 offset;

    private void Awake()
    {
        trans = transform;
        offset = trans.position - target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPos = target.position + offset;
        trans.position = Vector3.Lerp(trans.position, targetPos, Time.deltaTime * speed);
    }
}
