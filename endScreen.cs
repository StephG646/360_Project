using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScreen : MonoBehaviour
{
    public Texture backGroundTexture;

    private void OnGUI()
    {
        GUI.DrawTexture(
            new Rect(
                0,0,Screen.width,Screen.height),
                backGroundTexture);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
