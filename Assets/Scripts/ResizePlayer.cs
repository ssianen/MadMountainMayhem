using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ResizePlayer : MonoBehaviour {

    public GameObject CakeIcon;

    public GameObject PotionIcon;

    void Start() {

    }

    void Update() {

        if (CakeIcon.activeInHierarchy) {
            if(Input.GetKey(KeyCode.E)){
                //Grow the player
                transform.position = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.localScale = new Vector3 (2f, 2f, 2f);
            }

        } 

        if (PotionIcon.activeInHierarchy) {
            if(Input.GetKey(KeyCode.Q)){ 
                //Shrink the player
                transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
                transform.localScale = new Vector3 (0.5f, 0.5f, 0.5f);
            }
        }

        //yet to implement getting back to regular size
        //transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);

    }

   
}


