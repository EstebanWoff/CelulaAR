using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public TMP_Text questionText;
    public TMP_Text scoreText;
    public TMP_Text tiempoText;
    public Button[] answerButtons;

    private int currentQuestion = 0;
    private int score = 0;
     public float tiempoFinal ;
     public Button volver;

    private List<Question> questions = new List<Question>() {
        new Question("¿Cuál es la función principal del aparato de Golgi en una célula?", new List<string>() {"Producir energía para la célula", "Almacenar agua y nutrientes", "Empaquetar y enviar proteínas y lípidos", "Desintoxicar la célula"}, 2),
        new Question("¿Qué función tiene el centriolo en una célula?", new List<string>() {" Producir lípidos", "Almacenar calcio", "Mantener la forma de la célula", "Desintoxicar la célula"}, 2),
        new Question("¿Cuál es la función principal del nucleo en una célula?", new List<string>() {"Desintoxicar la célula", "Producir energía para la célula", "Controlar las actividades de la célula","Almacenar agua y nutrientes"}, 2),
        new Question("¿Qué función tiene la mitocondria en una célula?", new List<string>() {"Producir hormonas importantes", "Convertir el alimento en energía", "Controlar las actividades de la célula", "Producir ribosomas"}, 1),
        new Question("¿Cuál es la función principal del retículo endoplásmico rugoso?", new List<string>() {"Almacenar calcio", "Transportar agua y nutrientes", "Producir proteínas", "Regular el metabolismo de la célula"}, 2)
    };

    void Start()
    {
        ShowQuestion();
        tiempoFinal = PlayerPrefs.GetFloat("TiempoFinal");

        // Luego puedes utilizar la variable recibida en esta escena
        Debug.Log("El valor recibido es: " + tiempoFinal);

        tiempoText.text = "Tiempo Prueba Anterior: " + tiempoFinal.ToString("F2");
        volver.gameObject.SetActive(false);
    }

    void ShowQuestion()
    {
        Question question = questions[currentQuestion];
        questionText.text = question.question;

        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.answers[i];
            int answerIndex = i;
            answerButtons[i].onClick.RemoveAllListeners();
            answerButtons[i].onClick.AddListener(() =>
            {
                if (answerIndex == question.correctAnswer)
                {
                    score++;
                    scoreText.text = "Respuestas Correctas: " + score;
                    answerButtons[answerIndex].GetComponent<Image>().color = Color.green;
                }
                else
                {
                    answerButtons[answerIndex].GetComponent<Image>().color = Color.red;
                    answerButtons[question.correctAnswer].GetComponent<Image>().color = Color.green;
                }
                DisableButtons();
                Invoke("NextQuestion", 1.5f);
            });
        }

        ResetButtonColors();
    }

    void NextQuestion()
    {
        currentQuestion++;
        if (currentQuestion < questions.Count)
        {
            ShowQuestion();
        }
        else
        {
            ShowScore();
        }
    }

    void ShowScore()
    {
        questionText.text = "Puntuación final: " + (score*tiempoFinal).ToString("F2");
        tiempoText.gameObject.SetActive(false);
        volver.gameObject.SetActive(true);
        foreach (Button button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }
        scoreText.gameObject.SetActive(false);
    }

    void ResetButtonColors()
    {
        foreach (Button button in answerButtons)
        {
            button.GetComponent<Image>().color = Color.white;
            button.interactable = true;
        }
    }

    void DisableButtons()
    {
        foreach (Button button in answerButtons)
        {
            button.interactable = false;
        }
    }
}

public class Question
{
    public string question;
    public List<string> answers;
    public int correctAnswer;

    public Question(string question, List<string> answers, int correctAnswer)
    {
        this.question = question;
        this.answers = answers;
        this.correctAnswer = correctAnswer;
    }
}