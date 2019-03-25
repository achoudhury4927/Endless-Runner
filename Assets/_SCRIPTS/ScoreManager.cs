using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager singleton;
    private int score;
    public int point;
    void Awake(){
        if (singleton == null) {
            singleton = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        point = 10;
        PlayerPrefs.SetInt("highScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore() {
        score += point;
    }

    public void startScore() {
        InvokeRepeating("incrementScore", 0.1f, 0.5f);
    }

    public void stopScore() {
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore")) {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
