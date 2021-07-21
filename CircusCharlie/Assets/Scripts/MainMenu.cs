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

        charEquiped = PlayerPrefs.GetInt("charEquiped");
        lionEquiped = PlayerPrefs.GetInt("lionEquiped");
        horseEquiped = PlayerPrefs.GetInt("horseEquiped");
        ballEquiped = PlayerPrefs.GetInt("ballEquiped");
        ropeEquiped = PlayerPrefs.GetInt("ropeEquiped");
        swingEquiped = PlayerPrefs.GetInt("swingEquiped");
        platformEquiped = PlayerPrefs.GetInt("platformEquiped");

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

        PlayerPrefs.SetInt("charEquiped", charEquiped);
        PlayerPrefs.SetInt("lionEquiped", lionEquiped);
        PlayerPrefs.SetInt("horseEquiped", horseEquiped);
        PlayerPrefs.SetInt("ballEquiped", ballEquiped);
        PlayerPrefs.SetInt("ropeEquiped", ropeEquiped);
        PlayerPrefs.SetInt("swingEquiped", swingEquiped);
        PlayerPrefs.SetInt("platformEquiped", platformEquiped);
    }

    public void StartGame()
    {
        player.GetComponent<PlayerMove>().dontMove = false;
        currentCoinText.text = collectedCoins.ToString();
    }

    public void DoubleReward()
    {
        collectedCoins = collectedCoins * 2;
        player.GetComponent<PlayerProgress>().Restart();
    }
}
