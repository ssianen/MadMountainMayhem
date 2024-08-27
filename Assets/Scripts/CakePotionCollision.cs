using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CakePotionCollision : MonoBehaviour
{

    public GameObject CakeIcon;
    public GameObject EGrowGUI;

    public GameObject PotionIcon;
    public GameObject QShrinkGUI;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    

    void Start() {
        CakeIcon.SetActive(false);
        EGrowGUI.SetActive(false);
        PotionIcon.SetActive(false);
        QShrinkGUI.SetActive(false);
    }

    //Runs every time player collides with rigidbody (of cake or potion)
    void OnTriggerStay(Collider other)
    {
    
        if (other.gameObject.tag == "Player") { 

            // Create a temporary reference to the current scene.
            Scene currentScene = SceneManager.GetActiveScene();

            // Retrieve the name of this scene.
            string curSceneName = currentScene.name;
            
            if (this.gameObject.tag == "Cake") { 

                //Cake icon should appear on HUD/GUI
                CakeIcon.SetActive(true);
                EGrowGUI.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears

                if (curSceneName == "final-platformer") 
                {
                    //play collection sound effect
                    audioManager.PlaySFX(audioManager.collecting);
                }

            } 
            if ((this.gameObject.tag == "Potion")){

                //Potion icon should appear on HUD/GUI
                PotionIcon.SetActive(true);
                QShrinkGUI.SetActive(true);
                this.gameObject.SetActive(false); //item in scene disappears

                if (curSceneName == "final-platformer") 
                {
                    //play collection sound effect
                    audioManager.PlaySFX(audioManager.collecting);
                }                
            } 
        }
    }
}


