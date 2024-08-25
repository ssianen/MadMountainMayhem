using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AxeCollision : MonoBehaviour
{

    public GameObject AxeIcon;
    

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
            }

        }
    }
    
}


