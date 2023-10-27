using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer_Question : MonoBehaviour
{
    public int answer_pos; 

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<Question_Selector>().Answer_question(answer_pos);
    }
}
