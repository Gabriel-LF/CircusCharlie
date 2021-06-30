using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public int maxScore;
    public Text scoreText;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        maxScore = PlayerPrefs.GetInt("MaxScore");
        scoreText.text = (maxScore.ToString() + "m");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        player.GetComponent<PlayerMove>().dontMove = false;
    }
}
