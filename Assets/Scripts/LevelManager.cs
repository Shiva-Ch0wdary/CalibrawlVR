using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private List<List<Question>> levels = new List<List<Question>>();
    public GameObject[] levelPanels;
    int currentLevel = -1;

    StageTeleport stageTeleport;

    void InitializeQuestions()
    {
        // Level 1
        List<Question> level1Questions = new List<Question>
        {
            new Question("A projectile is launched at an angle of 45 degrees to the horizontal. What is the shape of its trajectory?", 
                            new string[] { "Parabola", "Circle", "Line", "Hyperbola"}, 0),
            new Question("In projectile motion, the range is the horizontal distance traveled by the projectile. Which of the following factors affects the range?",
                            new string[] { "Launch Distance", "Friction", "Air resistance", "Initial velocity"}, 3),
            new Question("If the launch angle of a projectile is 90 degrees, what can be said about its range?",
                            new string[] { "Maximum", "Minimum", "Zero", "Infinite"}, 2)
        };

        // Level 2
        List<Question> level2Questions = new List<Question>
        {
            // Add your level 2 questions here
            new Question(" A ball is launched at an angle of 45 degrees to the ground with an initial speed of 15 m/s. What is the time of flight?", 
                            new string[] { "1.5 s", "2.0 s", "2.3 s", "3.0 s"}, 1),
            new Question("If a projectile is launched vertically upward, what is its acceleration at the highest point of its trajectory?", 
                            new string[] { "9.8 m/s² downward", "9.8 m/s² upward", "0 m/s²", "Unpredictable"}, 0),
            new Question("A cannonball is fired horizontally from the top of a cliff with an initial speed of 40 m/s. What is the range of the projectile?", 
                            new string[] { "40 m", "80 m", "120 m", "160 m"}, 2)
        };

        // Level 3
        List<Question> level3Questions = new List<Question>
        {
            // Add your level 3 questions here
            new Question("A projectile is launched at an angle of 30 degrees with an initial speed of 25 m/s. What is the horizontal component of its initial velocity?", 
                            new string[] { "12.5 m/s", "1.7 m/s", "22.5 m/s", "35.3 m/s"}, 2),
            new Question("If a projectile is launched at an angle of 60 degrees and hits the ground after 4 seconds, what is the initial speed of the projectile?", 
                            new string[] { " 10 m/s", "20 m/s", "30 m/s", "40 m/s"}, 2),
            new Question("Two projectiles are launched at the same angle A and B but with 10m/s and 5m/s initial speeds. Which one experiences a greater change in velocity during the flight?",
                            new string[] {"A","B","Both","Cannot determine"},0 )
        };

        // Add levels to the list
        levels.Add(level1Questions);
        levels.Add(level2Questions);
        levels.Add(level3Questions);
    }

    void Start()
    {
        stageTeleport = GetComponent<StageTeleport>();
        InitializeQuestions();
        LoadLevel();

    }

    // Update is called once per frame
    public void LoadLevel()
    {
        currentLevel = currentLevel + 1;
        if(currentLevel >= levels.Count)
        {
            Debug.Log("You have completed all the levels!");
            return;
        }
        levelPanels[currentLevel].SetActive(true);
        levelPanels[currentLevel].GetComponent<QuestionAnswer>().InitializeLevel(levels[currentLevel]);
        stageTeleport.TeleportToStage(currentLevel);
    }
}

public class Question
{
    public string questionText;
    public string[] options;
    public int correctOptionIndex;

    public Question(string questionText, string[] options, int correctOptionIndex)
    {
        this.questionText = questionText;
        this.options = options;
        this.correctOptionIndex = correctOptionIndex;
    }
}
