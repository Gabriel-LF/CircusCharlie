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

    public bool imortal;
    public Transform horse;
    public bool freeHorse = false;

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
            StartCoroutine(Death());
        }
    }
    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Hazard") && !imortal)
        {
            StartCoroutine(Death());
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

    IEnumerator Death()
    {
        Play(death);

        freeHorse = true;
        gameObject.GetComponent<PlayerMove>().dontMove = true;
        gameObject.GetComponent<PlayerAnimation>().anim.SetTrigger("Death");
        gameObject.GetComponent<jump>().anim.SetTrigger("Death");
        imortal = true;
        yield return new WaitForSeconds(3);
        if (currentScore > MainMenu.Instance.maxScore)
        {
            MainMenu.Instance.maxScore = currentScore;
            MainMenu.Instance.scoreText.text = (MainMenu.Instance.maxScore.ToString()+ "m");
            PlayerPrefs.SetInt("MaxScore", MainMenu.Instance.maxScore);
        }
        imortal = false;
        freeHorse = false;
        LevelManager.Instance.Restart();
        DifficultyScaler.Instance.Reset();
    }

    public void Die()
    {
        if(!imortal)
        StartCoroutine(Death());
    }

    public void Play(AudioClip clip)
    {
        audios.clip = clip;
        audios.Play();
    }
}
