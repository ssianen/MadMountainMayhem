using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Courtesy of Claire!

public class LoadingCardCube : MonoBehaviour
{
    // public variables
    public float spd = 100f;

    void FixedUpdate()
    {
        transform.rotation = Quaternion.AngleAxis(Time.time * spd, transform.right);
        transform.rotation = Quaternion.AngleAxis(Time.time * spd * 0.9f, transform.forward);
    }

}
