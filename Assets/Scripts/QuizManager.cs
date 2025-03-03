using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsandAnswers> QnA;
    private List<QuestionsandAnswers> selectedQuestions;
    public GameObject[] options;
   // public int currentQuestion;

    public TMP_Text QuestionTxt;

    public int currentQuestionIndex = 0;

    public GameObject Quizpanel;
    public GameObject overPanel;
    public TMP_Text scoreKeep;

    public int totalQuestions = 0;

    public int totalScore = 0;

    public void Start()
    {
        overPanel.SetActive(false);

        SelectRandomQuestions();

        generateQuestion();
       // totalQuestions = QnA.Count;
    }

    public void SelectRandomQuestions()
    {
        List<QuestionsandAnswers> shuffledList = new List<QuestionsandAnswers>(QnA);
        for (int i = 0; i < shuffledList.Count; i++)
        {
            QuestionsandAnswers temp = shuffledList[i];
            int randomIndex = UnityEngine.Random.Range(i, shuffledList.Count);
            shuffledList[i] = shuffledList[randomIndex];
            shuffledList[randomIndex] = temp;
        }

        selectedQuestions = shuffledList.GetRange(0, Mathf.Min(5, shuffledList.Count));
    }

    public void Retry()
    {
        //QnA.Clear();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Correct()
    {
        // totalScore += 1;
        // if (QnA.Count > 0)
        // {
        //  QnA.RemoveAt(currentQuestion);
        // if (QnA.Count > 0)
        // {
        //
        // generateQuestion();
        //}
        //  else
        //  {
        //     GameOver();
        //  }
        // }
        totalScore++;
        NextQuestion();
    }

    public void wrongAnswer()
    {
        //if (QnA.Count > 1)
        // {
        //    QnA.RemoveAt(currentQuestion);
        //  if ( QnA.Count > 0)
        // {
        //     generateQuestion();
        // }
        // else
        //{
        //   GameOver();
        // }
        // }
        NextQuestion();
    }

    public void NextQuestion()
    {
        currentQuestionIndex++;
        if (currentQuestionIndex < selectedQuestions.Count)
        {
            generateQuestion();
        }
        else
        {
            GameOver();
        }
    }
    public void GameOver()
    {
        overPanel.SetActive(true);
        Quizpanel.SetActive(false);
        scoreKeep.text = totalScore + "/" + selectedQuestions.Count;
    }

    void SetAnswers()
    {
        for (int i =0; i<options.Length; i++)
        {
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = selectedQuestions[currentQuestionIndex].Answers[i];
            //options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = QnA[currentQuestion].Answers[i];

            //if (QnA[currentQuestion].CorrectAnswer == i+1)
            if (selectedQuestions[currentQuestionIndex].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {

        //if (QnA.Count > 0)
        if (currentQuestionIndex < selectedQuestions.Count)
        {


            //currentQuestion = UnityEngine.Random.Range(0, QnA.Count);
            //QuestionTxt.text = QnA[currentQuestion].Question;
            QuestionTxt.text = selectedQuestions[currentQuestionIndex].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Done with all Questions");
            GameOver();
        }

        
    }
}
