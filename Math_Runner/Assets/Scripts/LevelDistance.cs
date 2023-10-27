using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    private const int section_lenght = 50;
    public TMP_Text Distance_Display;
    public int Distanc_Run;
    public bool adding_Distance = false;

    public GameObject player;
    public int player_platform;


    void Update()
    {
        player_platform = (int)((player.transform.position.z - 25) / section_lenght);
        if (adding_Distance == false)
        {
            adding_Distance = true;
            StartCoroutine(Adding_Dis());
        }
    }

    IEnumerator Adding_Dis()
    {
        Distanc_Run += 1;
        Distance_Display.text = Distanc_Run.ToString();
        yield return new WaitForSeconds(0.25f);
        adding_Distance = false;
    }
}
