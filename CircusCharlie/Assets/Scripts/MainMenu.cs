using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance;
    public int maxScore;
    public Text scoreText;
    public int totalCoins;
    public int collectedCoins;
    public Text coinText, currentCoinText;

    public GameObject player;

    public int charEquiped;
    public int lionEquiped;
    public int horseEquiped;
    public int ballEquiped;
    public int ropeEquiped;
    public int swingEquiped;
    public int platformEquiped;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        maxScore = PlayerPrefs.GetInt("MaxScore");
        totalCoins = PlayerPrefs.GetInt("totalCoins");

        UpdateUI();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        PlayerPrefs.SetInt("totalCoins", totalCoins);

        scoreText.text = (maxScore.ToString() + "m");
        coinText.text = totalCoins.ToString();
    }

    public void StartGame()
    {
        player.GetComponent<PlayerMove>().dontMove = false;
    }
}
