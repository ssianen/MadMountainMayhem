using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopping : MonoBehaviour
{
    public GameObject AxeIcon;

    public GameObject AxeOnPlayer;
    AudioManager audioManager;

     private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start() {   
        AxeOnPlayer.SetActive(false);

    }

    void Update() {

        //Chopping (when the axe is unlocked)
        if (AxeIcon.activeInHierarchy && Input.GetKeyDown(KeyCode.X)) { //Can't be large when trying to chop wood, right? how are players supposed to know that though?

            //axe appears on player as if holding it
            AxeOnPlayer.SetActive(true);

        }
    }

    //Runs every time axe collides with rigidbody of tree
    void OnTriggerStay(Collider other)
    {

        //play sound effect 
        audioManager.PlaySFX(audioManager.chopping);

        // tree slowly fades

    }
}
