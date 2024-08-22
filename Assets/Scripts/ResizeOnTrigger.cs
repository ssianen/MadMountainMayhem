using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

//Adapted from FMark92 on Unity: https://discussions.unity.com/t/script-for-making-a-character-grow-and-shrink-like-in-alice-in-wonderland/680929/4

public class ResizeOnTrigger : MonoBehaviour {

    // void OnTriggerEnter(Collider other)
    // {
    //     if (other.gameObject.CompareTag("grow")) //this should be when a certain key is hit to activate cake power
    //     {
    //         GetComponent<PlayerSizing>().grow();
    //     }
    //     if (other.gameObject.CompareTag("shrink")) //this should be when a certain key is hit to activate potion power
    //     {
    //         GetComponent<PlayerSizing>().shrink();
    //     }
    //     if (other.gameObject.CompareTag("normal_size")) //this should be when a certain key is hit to activate potion power
    //     {
    //         GetComponent<PlayerSizing>().originalSize();
    //     }
 
    // }


    private void OnTriggerExit(Collider other){ //after the collision, the abilities are acquired
        if(other.gameObject.tag == "Player") {
            if(Input.GetKey(KeyCode.E)){
                //call the function that allows the player to grow
                GetComponent<PlayerSizing>().grow();
            }
            if(Input.GetKey(KeyCode.Q)){
                //call the function that allows the player to shrink
                GetComponent<PlayerSizing>().shrink();
            }

        }
        
    } 
   
}


