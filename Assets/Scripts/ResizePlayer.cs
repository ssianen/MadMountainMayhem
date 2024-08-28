using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ResizePlayer : MonoBehaviour {

    public GameObject CakeIcon;
    public GameObject PotionIcon;
    
    //highlights to indicate current size on GUI icon
    public GameObject NowSmall;
    public GameObject NowReg;
    public GameObject NowLarge;
    

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
        NowSmall.SetActive(false);
        NowReg.SetActive(true);
        NowLarge.SetActive(false);

    }

    void Update() {

        //Growing (when just the cake is unlocked)
        if (CakeIcon.activeInHierarchy && Input.GetKeyDown(KeyCode.E) && !PotionIcon.activeInHierarchy) {

            if (regularSized) { 
                
                //Grow from regular to large
                transform.position = new Vector3 (transform.position.x, transform.position.y + 1.0f, transform.position.z);
                transform.localScale = largeVector;

                regularSized = false;
                NowReg.SetActive(false);

                largeSized = true;
                NowLarge.SetActive(true);

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
                NowReg.SetActive(false);

                smallSized = true;
                NowSmall.SetActive(true);

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
                    NowReg.SetActive(false);

                    largeSized = true;
                    NowLarge.SetActive(true);

                    //Play sound
                    audioManager.PlaySFX(audioManager.growing);

                } else if (smallSized) {

                    //Grow from small to regular 
                    transform.localScale = regularVector;
                    
                    smallSized = false;
                    NowSmall.SetActive(false);

                    regularSized = true;
                    NowReg.SetActive(true);

                    //Play sound
                    audioManager.PlaySFX(audioManager.growing);

                }

            } else if (Input.GetKeyDown(KeyCode.Q)) {

                if (regularSized) { 

                    //Shrink from regular to small 
                    transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
                    transform.localScale = smallVector;

                    regularSized = false;
                    NowReg.SetActive(false);

                    smallSized = true;
                    NowSmall.SetActive(true);

                    //Play sound
                    audioManager.PlaySFX(audioManager.shrinking);


                } else if (largeSized) {

                    //Shrink from small to regular 
                    transform.localScale = regularVector;
                    
                    largeSized = false;
                    NowLarge.SetActive(false);

                    regularSized = true;
                    NowReg.SetActive(true);

                    //Play sound
                    audioManager.PlaySFX(audioManager.shrinking);


                }
            }  

        }
    }

    public int GetSize() {
        if (smallSized) {
            return 1;
        } else if (regularSized) {
            return 2;
        } else if (largeSized) {
            return 3;
        }
        return 0;
    }
}




