using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePong : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(0, 50, 0) * Time.deltaTime);
        transform.position = new Vector3(Mathf.PingPong(Time.time, 3), transform.position.y, transform.position.z);
    }
}
