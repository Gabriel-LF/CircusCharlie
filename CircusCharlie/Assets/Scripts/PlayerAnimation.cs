using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    public bool menuStage;

    public bool fireStage;
    public GameObject lion;

    public bool monkeyStage;

    public bool ballStage;
    public Transform player;
    public GameObject ball;

    public bool horseStage;
    public GameObject horse;

    public bool swingStage;
    public GameObject currentSwing;

    public bool clownStage;

    public bool bonusStage;
    public GameObject bonusStuff, bonusMonkey;

    public void UpdateAnim()
    {
        ObjectPooler.Instance.SpawnFromPool("Confete", new Vector3(player.position.x + 1, player.position.y, player.position.z), Quaternion.Euler(0, 0, 0));
        if (menuStage)
        {
            anim.SetTrigger("Idle");
            gameObject.GetComponent<PlayerMove>().speed = 3; gameObject.GetComponent<jump>().defaultJumpSpeed = 9;
        }
        if (fireStage)
        {
            lion.SetActive(true);
            anim.SetTrigger("Mount");
            gameObject.GetComponent<PlayerMove>().speed = 3; gameObject.GetComponent<jump>().defaultJumpSpeed = 9;
        } else { lion.SetActive(false); }
        if (monkeyStage)
        {
            anim.SetTrigger("Walk");
            gameObject.GetComponent<jump>().jumpSpeed = gameObject.GetComponent<jump>().monkeyJumpSpeed;
            gameObject.GetComponent<PlayerMove>().speed = 3; gameObject.GetComponent<jump>().defaultJumpSpeed = 9;
        } else { gameObject.GetComponent<jump>().jumpSpeed = gameObject.GetComponent<jump>().defaultJumpSpeed; }
        if (horseStage)
        {
            horse.SetActive(true);
            anim.SetTrigger("HorseMount");
            gameObject.GetComponent<PlayerMove>().onHorse = true;
            gameObject.GetComponent<PlayerMove>().speed = 3; gameObject.GetComponent<jump>().defaultJumpSpeed = 9;
        } else { horse.SetActive(false); gameObject.GetComponent<PlayerMove>().onHorse = false; }
        if (ballStage)
        {
            anim.SetTrigger("Walk");
            player.position = new Vector2(player.position.x, 1.6f);
            gameObject.GetComponent<jump>().hasBall = true;
            ball.SetActive(true);
            gameObject.GetComponent<PlayerMove>().speed = 3; gameObject.GetComponent<jump>().defaultJumpSpeed = 9;
        } else { player.localPosition = new Vector2(player.localPosition.x, 0.2f); ball.SetActive(false); }
        if (clownStage)
        {
            anim.SetTrigger("Walk");
            gameObject.GetComponent<PlayerMove>().speed = 3; gameObject.GetComponent<jump>().defaultJumpSpeed = 9;
        }
        if (bonusStage)
        {
            lion.SetActive(true);
            anim.SetTrigger("Mount");
            gameObject.GetComponent<PlayerMove>().speed = 5;
            gameObject.GetComponent<jump>().defaultJumpSpeed = 10.5f;
            bonusMonkey.SetActive(true); bonusStuff.SetActive(true);
        } else { gameObject.GetComponent<PlayerMove>().speed = 3; gameObject.GetComponent<jump>().defaultJumpSpeed = 9; bonusMonkey.SetActive(false); bonusStuff.SetActive(false); }
    }

    void Update()
    {
        if (gameObject.GetComponent<jump>().isSwinging)
        {
            anim.SetFloat("SwingState", currentSwing.transform.rotation.z);
        }
    }
}
