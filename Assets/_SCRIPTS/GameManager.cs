using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager singleton;

    void Awake() {
        if (singleton == null) {
            singleton = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        UIManager.singleton.GameStart();
        ScoreManager.singleton.startScore();
        GameObject.Find("PlatformSpawner").GetComponent<Spawner>().StartSpawningPlatforms();
    }

    public void EndGame() {
        UIManager.singleton.GameOver();
        ScoreManager.singleton.stopScore();
    }
}
