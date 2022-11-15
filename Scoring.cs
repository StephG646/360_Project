using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static int score;
    public static int lives;
    public static int level;
    
    // Start is called before the first frame update
    void InitializeGame()
    {
        score = 0;
        lives = 3;
        level = 1;
    }


    void Start()
    {
        InitializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 200, 30), "Score:    " + score);
        GUI.Box(new Rect(Screen.width - 200, 10, 200, 30), "Lives:    " + lives);

        

        if (GameState.state == GameState.GameOver)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 50), "Game Over, Try Again"))
            {
                InitializeGame();
                GameState.state = GameState.PressStart;
            }
        }
    //Level Display
        GUI.Box (new Rect (Screen.width/2 - 60, 10, 120, 30), "Level:   " + Scoring.level);
    }
}
