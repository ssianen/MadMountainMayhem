using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgePlayerCollision : MonoBehaviour
{
    public GameObject brokenBridge;
    public GameObject fixedBridge;
    public GameObject fixMeSign; 
    public Text woodCountText; 

     void Start() {
        fixMeSign.SetActive(true); 
        brokenBridge.SetActive(true);
        fixedBridge.SetActive(false);
    }

     void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player") { 
            
            if ((this.gameObject.tag == "Bridge" && string.Equals(woodCountText.text, "20"))){

                fixMeSign.SetActive(false);
                brokenBridge.SetActive(false); //broken bridge in scene disappears

                fixedBridge.SetActive(true);
            }

        }
    }
    
}
