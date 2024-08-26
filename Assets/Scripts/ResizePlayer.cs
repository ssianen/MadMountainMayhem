using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ResizePlayer : MonoBehaviour {

    public GameObject CakeIcon;

    public GameObject PotionIcon;
    

    private bool smallSized = false;
    private bool regularSized = true;
    private bool largeSized = false;


    private Vector3 smallVector = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 regularVector = new Vector3(1.0f, 1.0f, 1.0f);
    private Vector3 largeVector = new Vector3(2.0f, 2.0f, 2.0f);

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {   

    }

    void Update() {

        //Growing (when just the cake is unlocked)
        if (CakeIcon.activeInHierarchy && Input.GetKeyDown(KeyCode.E) && !PotionIcon.activeInHierarchy) {

            if (regularSized) { 
                
                //Grow from regular to large
                transform.position = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.localScale = largeVector;

                regularSized = false;
                largeSized = true;

                //Play sound
                audioManager.PlaySFX(audioManager.growing);
            }
        } 
        
        //Shrinking (when just the potion is unlocked)
        else if (PotionIcon.activeInHierarchy && Input.GetKeyDown(KeyCode.Q) && !CakeIcon.activeInHierarchy) { 

            if (regularSized) { 
                    
                //Shrink from regular to small 
                transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
                transform.localScale = smallVector;

                regularSized = false;
                smallSized = true;

                //Play sound
                audioManager.PlaySFX(audioManager.shrinking);
            } 

        } else if (CakeIcon.activeInHierarchy && PotionIcon.activeInHierarchy){

            if (Input.GetKeyDown(KeyCode.E)) {
                
                if (regularSized) { 

                    //Grow from regular to large
                    transform.position = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);
                    transform.localScale = largeVector;

                    regularSized = false;
                    largeSized = true;

                    //Play sound
                    audioManager.PlaySFX(audioManager.growing);

                } else if (smallSized) {

                    //Grow from small to regular 
                    transform.localScale = regularVector;
                    
                    smallSized = false;
                    regularSized = true;

                    //Play sound
                    audioManager.PlaySFX(audioManager.growing);

                }

            } else if (Input.GetKeyDown(KeyCode.Q)) {

                if (regularSized) { 

                    //Shrink from regular to small 
                    transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    transform.localScale = smallVector;

                    regularSized = false;
                    smallSized = true;

                    //Play sound
                    audioManager.PlaySFX(audioManager.shrinking);


                } else if (largeSized) {

                    //Shrink from small to regular 
                    transform.localScale = regularVector;
                    
                    largeSized = false;
                    regularSized = true;

                    //Play sound
                    audioManager.PlaySFX(audioManager.shrinking);


                }
            }  

        }
    }
}




