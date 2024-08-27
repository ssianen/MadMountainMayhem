using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AxePlayerCollision : MonoBehaviour
{

    public GameObject AxeIcon;
    
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        AxeIcon.SetActive(false);
    }

    //Runs every time player collides with rigidbody (of cake or potion)
    void OnTriggerStay(Collider other)
    {
    
        if (other.gameObject.tag == "Player") { 
            
            if ((this.gameObject.tag == "Axe")){

                //Axe icon should appear on HUD/GUI
                AxeIcon.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears

                //play collection sound effect
                audioManager.PlaySFX(audioManager.collecting);
            }

        }
    }
    
}


