using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int state;
    public const int PressStart = 1;
    public const int StartingPlay = 2;
    public const int GamePlay = 3;
    public const int Dying = 4;
    public const int GameOver = 5;
    public const int NextLevel = 6;

    // Start is called before the first frame update
    void Start()
    {
        state = PressStart;   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
