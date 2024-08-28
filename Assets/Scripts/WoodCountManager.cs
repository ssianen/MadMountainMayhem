using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodCountManager : MonoBehaviour
{
    public Text woodCountText;
    public static int totalChopped;
    public GameObject axeOnPlayer;

    void Update(){
        woodCountText.text = totalChopped.ToString();

	if (totalChopped == 20) {
		axeOnPlayer.SetActive(false);
	}
    }

}