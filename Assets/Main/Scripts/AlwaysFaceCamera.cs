using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaceCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 camPos = Camera.main.transform.position;

        transform.LookAt(
            Camera.main.transform.position
            );
    }
}
