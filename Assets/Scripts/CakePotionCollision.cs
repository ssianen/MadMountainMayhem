using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CakePotionCollision : MonoBehaviour
{

    public GameObject CakeIcon;

    public GameObject PotionIcon;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    

    void Start() {
        CakeIcon.SetActive(false);
        PotionIcon.SetActive(false);
    }

    //Runs every time player collides with rigidbody (of cake or potion)
    void OnTriggerStay(Collider other)
    {
    
        if (other.gameObject.tag == "Player") { 
            
            if (this.gameObject.tag == "Cake") { 

                //Cake icon should appear on HUD/GUI
                CakeIcon.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears

                //play collection sound effect
                audioManager.PlaySFX(audioManager.collecting);
                // Add an if here so it only plays the sound effect in level/scene 1 when first collected


            } 
            if ((this.gameObject.tag == "Potion")){

                //Potion icon should appear on HUD/GUI
                PotionIcon.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears

                //play collection sound effect
                audioManager.PlaySFX(audioManager.collecting);
                // Add an if here so it only plays the sound effect in level/scene 1 when first collected
            } 

        }
    }
    
}


