using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{
    public int currentScore;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = (int)gameObject.transform.position.x;
        scoreText.text = (currentScore.ToString() + "m");
    }

    public void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Finish"))
        {
            LevelManager.Instance.LoadLevel();
            LevelManager.Instance.playerPosition = gameObject.transform.position.x;
        }
        if (hit.gameObject.CompareTag("Hazard"))
        {
            StartCoroutine(Death());
        }
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(3);
        if (currentScore > MainMenu.Instance.maxScore)
        {
            MainMenu.Instance.maxScore = currentScore;
            MainMenu.Instance.scoreText.text = (MainMenu.Instance.maxScore.ToString()+ "m");
            PlayerPrefs.SetInt("MaxScore", MainMenu.Instance.maxScore);
        }  
        LevelManager.Instance.Restart();
    }
}