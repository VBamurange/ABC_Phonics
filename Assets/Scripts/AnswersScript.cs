using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswersScript : MonoBehaviour
{

    public bool isCorrect = false;
    public QuizManager quizManager;

    public void Answer()
    {
        if(isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.Correct();

        }
        else
        {
            Debug.Log("Answer is incorrect");
            quizManager.wrongAnswer();
        }
    }
}
