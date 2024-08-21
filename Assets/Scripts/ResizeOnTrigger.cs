using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Adapted from FMark92 on Unity: https://discussions.unity.com/t/script-for-making-a-character-grow-and-shrink-like-in-alice-in-wonderland/680929/4

public class ResizeOnTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("grow")) //this should be when a certain key is hit to activate cake power
        {
            GetComponent<PlayerSizing>().grow();
        }
        if (other.gameObject.CompareTag("shrink")) //this should be when a certain key is hit to activate potion power
        {
            GetComponent<PlayerSizing>().shrink();
        }
 
    }
}


///change this per key 