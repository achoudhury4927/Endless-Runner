using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager singleton;

    public GameObject logoPanel;
    public GameObject gameOverPanel;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public GameObject tap;

    void Awake() {
        if (singleton == null) {
            singleton = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart() {
        
        tap.SetActive(false);
        logoPanel.GetComponent<Animator>().Play("PanelUp");
   }

    public void GameOver() {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Reset() {
        
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
