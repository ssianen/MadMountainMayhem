using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ResizePlayer : MonoBehaviour {

    public GameObject CakeIcon;

    public GameObject PotionIcon;

    bool resized = false;
    bool hasShrunk = false;

    bool hasGrown = false;


    Vector3 shrinkVector = new Vector3(0.5f, 0.5f, 0.5f);
    Vector3 growVector = new Vector3(2.0f, 2.0f, 2.0f);
    Vector3 regularVector = new Vector3(1.0f, 1.0f, 1.0f);

    void Start() {
        

    }

    void Update() {

        if (CakeIcon.activeInHierarchy) {
            if(Input.GetKey(KeyCode.E) && resized == false && hasShrunk == false && hasGrown == false){
                
                //Grow from regular to large
                transform.position = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.localScale = growVector;
                
                resized = true;
                hasShrunk = false;
                hasGrown = true;
            } 

            if (Input.GetKey(KeyCode.E) && resized == true && hasShrunk == false && hasGrown == true) {
                
                //Grow from small to regular 
                transform.localScale = regularVector;
                
                hasShrunk = false;
                hasGrown = true;
                resized = false;
            }

        } 

        if (PotionIcon.activeInHierarchy) {
            if(Input.GetKey(KeyCode.Q) && resized == True && hasShrunk == false && hasGrown == true){ 
                
                //Shrink from large to regular
                transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
                transform.localScale = shrinkVector;

                hasShrunk = true;
                resized = true;
            } 
            if (Input.GetKey(KeyCode.Q) && resized == false && hasShrunk == false && hasGrown == false) {
                
                //Shrink from regular to small 
                transform.localScale = regularVector;
                
                hasShrunk = true;
                hasGrown = false;
                resized = false;
            }
        }

    }

   
}


