using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AxePlayerCollision : MonoBehaviour
{

    public GameObject AxeIcon;
    public GameObject AxeSign;
    public GameObject XChopGUI;
    
    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {
        AxeIcon.SetActive(false);
        XChopGUI.SetActive(false);
        AxeSign.SetActive(true);
    }

    //Runs every time player collides with rigidbody (of cake or potion)
    void OnTriggerStay(Collider other)
    {
    
        if (other.gameObject.tag == "Player") { 
            
            if ((this.gameObject.tag == "AxeOnGround")){

                //Axe icon should appear on HUD/GUI
                AxeIcon.SetActive(true);
                XChopGUI.SetActive(true);

                //item in scene disappears
                this.gameObject.SetActive(false); 
                AxeSign.SetActive(false);

                //play collection sound effect
                audioManager.PlaySFX(audioManager.collecting);
            }

        }
    }
    
}


