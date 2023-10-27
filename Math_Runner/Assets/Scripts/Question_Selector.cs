using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class Question_Selector : MonoBehaviour
{
    public GameObject Left;
    public GameObject Middle;
    public GameObject Right;

    public TMP_Text UI_Question;
    public TMP_Text UI_Left;
    public TMP_Text UI_Middle;
    public TMP_Text UI_Right;

    public GameObject Score_object;

    private const int section_lenght = 50;
    public int platform_number;

    public GameObject player;
    public int player_platform;

    public int correct_answer;

    public TextAsset jsonFile;
    public string questionTheme = "Broekregning";
    public int questionId;
    private MathQuestionsContainer questionsContainer;

    [Serializable]
    public class MathQuestion
    {
        public int id;
        public string theme;
        public string question;
        public string correct_answer;
        public string[] wrong_answers;
    }

    [Serializable]
    public class MathQuestionsContainer
    {
        public MathQuestion[] math_questions;
    }


    // Start is called before the first frame update
    void Start()
    {

        if (jsonFile != null)
        {
            questionsContainer = JsonUtility.FromJson<MathQuestionsContainer>(jsonFile.text);
        }
        else
        {
            Debug.LogError("JSON file is not assigned.");
        }

  
        platform_number = (int)((transform.position.z - 25) / section_lenght);

        correct_answer = Random.Range(1, 4);

        Left.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        Middle.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        Right.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

        if (correct_answer == 1)
        {
            Left.GetComponent<Renderer>().material.SetColor("_Color", Color.green);

        }
        else if (correct_answer == 2)
        {
            Middle.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }
        else if(correct_answer == 3)
        {
            Right.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
        }

        Left.SetActive(true);
        Middle.SetActive(true);
        Right.SetActive(true);

    }
    void Update()
    {

        player_platform = player.GetComponent<LevelDistance>().player_platform;
        if (player_platform == platform_number)
        {
            FixedUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (player_platform == platform_number)
        {
            questionId = platform_number;
            Debug.Log("FixedUpdate kører nu i platform: " + platform_number);
            MathQuestion question = GetQuestionById(questionId);

            UI_Question.text = question.question;

            if (correct_answer == 1)
            {
                UI_Left.text = question.correct_answer;

                UI_Middle.text = question.wrong_answers[0];
                UI_Right.text = question.wrong_answers[1];
            }
            else if (correct_answer == 2)
            {
                UI_Middle.text = question.correct_answer;

                UI_Left.text = question.wrong_answers[0];
                UI_Right.text = question.wrong_answers[1];
            }

            else if (correct_answer == 3)
            {
                UI_Right.text = question.correct_answer;

                UI_Left.text = question.wrong_answers[0];
                UI_Middle.text = question.wrong_answers[1];
            }
        }
        
    }

    public void Answer_question(int pos)
    {
        if (pos == correct_answer)
        {
            Score_object.GetComponent<LevelDistance>().Distanc_Run += 500;
        }
        else
        {
            Score_object.GetComponent<LevelDistance>().Distanc_Run -= 500;
        }

        Left.SetActive(false);
        Middle.SetActive(false);
        Right.SetActive(false);

    }
    public MathQuestion GetQuestionById(int id)
    {
        foreach (MathQuestion question in questionsContainer.math_questions)
        {
            if (question.id == id)
            {
                return question;
            }
        }
        return null; // Question with the specified ID was not found
    }
}