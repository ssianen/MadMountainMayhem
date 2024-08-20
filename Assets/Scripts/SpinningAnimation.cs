using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningAnimation : MonoBehaviour
{

    public float speed = 100f;

    void FixedUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(Time.time * speed, transform.up); // have to separate from frame rate in game development 
    }
}
