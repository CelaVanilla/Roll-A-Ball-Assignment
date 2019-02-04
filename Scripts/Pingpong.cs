using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pingpong : MonoBehaviour
{
    void Update()
    {

        transform.position = new Vector3(Mathf.PingPong(Time.time, 1), -29, transform.position.z);
    }
}
