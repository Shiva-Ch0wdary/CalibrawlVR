using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    List<Question> questions;
    List<int> answerOptions;
    int currentQuestion = -1;
    public Button[] currentOptions;
    public TextMeshProUGUI questionText;
    ColorBlock defaultColors;
    public GameObject questionPanel;
    public GameObject scorePanel;

    void Init()
    {
        defaultColors = currentOptions[0].colors;
        defaultColors.normalColor = new Color(20f / 255f, 20f / 255f, 20f / 255f, 160f / 255f);
        defaultColors.highlightedColor = new Color(20f / 255f, 20f / 255f, 20f / 255f, 190f / 255f);
        defaultColors.pressedColor = new Color(75f / 255f, 100f / 255f, 255f / 255f, 160f / 255f);
        defaultColors.selectedColor = new Color(75f / 255f, 100f / 255f, 255f / 255f, 160f / 255f);
        questionPanel.SetActive(false);
        scorePanel.SetActive(false);
    }

    public void InitializeLevel(List<Question> que)
    {
        Init();
        questions = que;
        answerOptions = new List<int>();
        Debug.Log("hehehehe");
        questionPanel.SetActive(true);
        loadQuestion();
    }

    public void loadQuestion()
    {
        currentQuestion = currentQuestion + 1;
        if (currentQuestion >= questions.Count)
        {
            Debug.Log("No more questions");
            questionPanel.SetActive(false);
            int score = 0;
            for(int i = 0; i < questions.Count; i++)
            {
                if (questions[i].correctOptionIndex == answerOptions[i])
                {
                    score = score + 1;
                }
                else
                {
                    Debug.Log("Incorrect answer for question " + i);
                }
            }
            scorePanel.GetComponentInChildren<TextMeshProUGUI>().text = "Score: \n" + score + " / " + questions.Count;
            scorePanel.SetActive(true);
            return;
        }
        questionText.text = questions[currentQuestion].questionText;
        for(int i = 0; i < questions[currentQuestion].options.Length; i++)
        {
            currentOptions[i].colors = defaultColors;
            currentOptions[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestion].options[i];
            switch (i)
            {
                case 0:
                    currentOptions[i].onClick.AddListener(() => OnButtonClick(0));
                    break;
                case 1:
                    currentOptions[i].onClick.AddListener(() => OnButtonClick(1));
                    break;
                case 2:
                    currentOptions[i].onClick.AddListener(() => OnButtonClick(2));
                    break;
                case 3:
                    currentOptions[i].onClick.AddListener(() => OnButtonClick(3));
                    break;
            }
        }

    }

    void OnButtonClick(int index)
    {
        //currentOptions[index].Select();
        int correctIndex = questions[currentQuestion].correctOptionIndex;
        Debug.Log("selected " + questions[currentQuestion].options[index]);
        answerOptions.Add(index);
        var greenColor = new Color(75 / 255f, 255 / 255f, 100 / 255f, 160 / 255f);

        if (questions[currentQuestion].correctOptionIndex == index)
        {
            Debug.Log("Correct");
            var tempColors = currentOptions[index].colors;
            tempColors.selectedColor = greenColor;
            currentOptions[index].colors = tempColors;
        }
        else
        {
            Debug.Log("Incorrect");
            var tempColors = currentOptions[correctIndex].colors;
            tempColors.normalColor = greenColor;
            currentOptions[correctIndex].colors = tempColors;
        }
    }
}
