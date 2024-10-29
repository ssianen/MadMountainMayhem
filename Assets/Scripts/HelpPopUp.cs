using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpPopUp : MonoBehaviour
{

    public GameObject ControlsAndAbilities;

    // Start is called before the first frame update
    void Start()
    {
        ControlsAndAbilities.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)){ //to open the help menu
            ControlsAndAbilities.SetActive(true);
        } else if (Input.GetKeyDown(KeyCode.C)) { //to close the help menu
            ControlsAndAbilities.SetActive(false);
        }
    }
}

