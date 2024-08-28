using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WoodCountManager : MonoBehaviour
{
    public Text woodCountText;
    public static int totalChopped;

    void Update(){
        woodCountText.text = totalChopped.ToString();
    }


}