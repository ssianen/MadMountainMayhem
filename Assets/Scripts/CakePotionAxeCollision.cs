using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Adapted from https://discussions.unity.com/t/does-any-know-how-to-hide-and-show-2d-sprites-in-unity-5-by-using-a-2d-boxcollider-set-to-trigger-when-player-collides-with-the-boxcollider/142839

public class CakePotionAxeCollision : MonoBehaviour
{
    public GameObject CakeIcon; //check to see if these have to correspond with something?

    public GameObject PotionIcon;

    public GameObject AxeIcon;
    

    void Start() {
        CakeIcon.SetActive(false);
        PotionIcon.SetActive(false);
        AxeIcon.SetActive(false);
    }

    //Runs every time player collides with rigidbody (of cake or potion)
    void OnTriggerStay(Collider other)
    {
    
        if (other.gameObject.tag == "Player") { 
            
            if (this.gameObject.tag == "Cake") { 

                //Cake icon should appear on HUD/GUI
                CakeIcon.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears; causing the player to also disappear


            } else if ((this.gameObject.tag == "Potion")){

                //Potion icon should appear on HUD/GUI
                PotionIcon.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears; causing the player to also disappear

            } else if ((this.gameObject.tag == "Axe")){

                //Axe icon should appear on HUD/GUI
                AxeIcon.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears; causing the player to also disappear
            }

        }
    }
    
}


