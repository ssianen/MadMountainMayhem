using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CakePotionCollisionTest : MonoBehaviour
{
    //Runs every time player collides with rigidbody (of cake or potion)
    void OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.tag == "Cake") {
            //Cake icon should appear on HUD/GUI

            //Cake object "disappears" from scene
        } else if ((other.gameObject.tag == "Potion")){
            //Potion icon should appear on HUD/GUI

            //Potion object "disappears" from scene

        }
    }

   
    
}
