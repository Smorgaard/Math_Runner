using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question_Selector : MonoBehaviour
{
    public GameObject Left;
    public GameObject Middle;
    public GameObject Right;

    public TMP_Text UI_Left;
    public TMP_Text UI_Middle;
    public TMP_Text UI_Right;

    private const int section_lenght = 50;
    public int platform_number;

    public GameObject player;
    public int player_platform;

    public int correct_answer;

    

    // Start is called before the first frame update
    void Start()
    {
        platform_number = (int)((transform.position.z - 25) / section_lenght);
        Debug.Log("float "+ ((transform.position.z - 25) / section_lenght) + "\nint " + platform_number);

        correct_answer = Random.Range(1, 4);
        if (correct_answer == 1)
        {
            Left.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            Middle.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Right.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if (correct_answer == 2)
        {
            Middle.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            Left.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Right.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else if(correct_answer == 3)
        {
            Right.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

            Left.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Middle.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        else
        {
            Left.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Middle.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            Right.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }

    }
    void Update()
    {
        player_platform = player.GetComponent<LevelDistance>().player_platform;
        if (player_platform == platform_number)
        {
            if (correct_answer == 1)
            {
                UI_Left.text = "Correct answer";

                UI_Middle.text = "Wrong answer";
                UI_Right.text = "Wrong answer";
            }
            else if (correct_answer == 2)
            {
                UI_Middle.text = "Correct answer";

                UI_Left.text = "Wrong answer";
                UI_Right.text = "Wrong answer";
            }

            else if (correct_answer == 3)
            {
                UI_Right.text = "Correct answer";

                UI_Left.text = "Wrong answer";
                UI_Middle.text = "Wrong answer";
            }
        }
    }
}