using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using System.Threading;

public class PlayerProgress : MonoBehaviour
{
    public int currentScore;
    public Text scoreText;

    public bool imortal;
    public Transform horse;
    public bool freeHorse = false;

    public int deathCount;
    public GameObject[] deathScreen;
    public int doubledCoins;
    public Text[] coinText;

    public Transform safeSpot;

    public AudioSource audios;
    public AudioClip death, stage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentScore = (int)gameObject.transform.position.x;
        scoreText.text = (currentScore.ToString() + "m");

        if (freeHorse)
            horse.Translate(Vector2.right * Time.deltaTime * 4);

        if (imortal) { gameObject.layer = 2; } else { gameObject.layer = 0; }
    }

    public void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.CompareTag("Finish"))
        {
            Play(stage);
            ObjectPooler.Instance.SpawnFromPool("Confete", new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, 0));
            LevelManager.Instance.playerPosition = gameObject.transform.position.x;
            DifficultyScaler.Instance.LevelUp();
            LevelManager.Instance.LoadLevel();  
        }
        if (hit.gameObject.CompareTag("Hazard") && !imortal)
        {
            StartCoroutine(Death(hit.gameObject.name));
        }
        if (hit.gameObject.CompareTag("Rope") && gameObject.GetComponent<jump>().isSwinging == false)
        {
            imortal = true;
            gameObject.GetComponent<PlayerAnimation>().currentSwing = hit.gameObject;
            safeSpot = hit.transform;
            transform.SetParent(hit.transform, false);
            gameObject.GetComponent<jump>().isSwinging = true;
            gameObject.GetComponent<PlayerAnimation>().anim.SetTrigger("Swing");
            if (hit.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<SwingType>().stopped == true)
                hit.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<SwingType>().anim.SetTrigger("GoRight");
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Hazard") && !imortal)
        {
            StartCoroutine(Death(hit.gameObject.name));
        }
        if (hit.gameObject.CompareTag("Jumper"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10, ForceMode2D.Impulse);
        }
        if (hit.gameObject.tag == "ball")
        {
            hit.gameObject.SetActive(false);
            gameObject.GetComponent<jump>().hasBall = true;
            gameObject.GetComponent<PlayerAnimation>().ball.SetActive(true);
        }
    }

    IEnumerator Death(string name)
    {
        Debug.Log(name + " me matou!");
        Play(death);
        deathCount++;

        freeHorse = true;
        gameObject.GetComponent<PlayerMove>().dontMove = true;
        gameObject.GetComponent<PlayerAnimation>().anim.SetTrigger("Death");
        gameObject.GetComponent<jump>().anim.SetTrigger("Death");
        imortal = true;
        yield return new WaitForSeconds(3);
        Time.timeScale = 0;
        if (deathCount == 1)
            deathScreen[0].SetActive(true);
        if (deathCount >= 2)
        {
            deathScreen[1].SetActive(true);
            doubledCoins = MainMenu.Instance.collectedCoins * 2;
            coinText[0].text = MainMenu.Instance.collectedCoins.ToString();
            coinText[1].text = doubledCoins.ToString();
        }
    }

    public void Die()
    {
        if(!imortal)
            StartCoroutine(Death("Cai de cu"));
    }

    public void Play(AudioClip clip)
    {
        audios.clip = clip;
        audios.Play();
    }

    public void Restart()
    {
        if (currentScore > MainMenu.Instance.maxScore)
        {
            MainMenu.Instance.maxScore = currentScore;
            MainMenu.Instance.scoreText.text = (MainMenu.Instance.maxScore.ToString() + "m");
            PlayerPrefs.SetInt("MaxScore", MainMenu.Instance.maxScore);
        }
        imortal = false;
        freeHorse = false;

        LevelManager.Instance.camera.player = LevelManager.Instance.player.transform;

        deathCount = 0;
        deathScreen[0].SetActive(false);
        deathScreen[1].SetActive(false);
        Time.timeScale = 1;
        MainMenu.Instance.totalCoins += MainMenu.Instance.collectedCoins;
        MainMenu.Instance.collectedCoins = 0;
        MainMenu.Instance.UpdateUI();

        LevelManager.Instance.Restart();
        DifficultyScaler.Instance.Reset();
        MainMenu.Instance.gameObject.GetComponent<adsUnity>().ShowBanner();
    }

    public void Revive()
    {
        StartCoroutine(RemoveImortal());
        freeHorse = false;
        deathScreen[0].SetActive(false);
        Time.timeScale = 1;
        gameObject.GetComponent<PlayerMove>().dontMove = false;
        gameObject.GetComponent<PlayerAnimation>().lion.GetComponent<Animator>().SetTrigger("Revived");
        gameObject.GetComponent<PlayerAnimation>().UpdateAnim();

        if (gameObject.GetComponent<PlayerAnimation>().swingStage)
        {
            transform.position = safeSpot.position;
            imortal = false;
        }
    }

    IEnumerator RemoveImortal()
    {
        yield return new WaitForSeconds(3);
        imortal = false;
    }
}
