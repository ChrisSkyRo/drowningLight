using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    private void Awake() {
        target = GameObject.Find("Angel").GetComponent<Transform>();
    }

    private void LateUpdate() {
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    }
}
