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

    public void UpdateAnim()
    {
        ObjectPooler.Instance.SpawnFromPool("Confete", new Vector3(player.position.x + 1, player.position.y, player.position.z), Quaternion.Euler(0, 0, 0));
        if (menuStage)
        {
            anim.SetTrigger("Idle");
        }
        if (fireStage)
        {
            lion.SetActive(true);
            anim.SetTrigger("Mount");
        } else { lion.SetActive(false); }
        if (monkeyStage)
        {
            anim.SetTrigger("Walk");
            gameObject.GetComponent<jump>().jumpSpeed = gameObject.GetComponent<jump>().monkeyJumpSpeed;
        } else { gameObject.GetComponent<jump>().jumpSpeed = gameObject.GetComponent<jump>().defaultJumpSpeed; }
        if (horseStage)
        {
            horse.SetActive(true);
            anim.SetTrigger("HorseMount");
        } else { horse.SetActive(false); }
        if (ballStage)
        {
            anim.SetTrigger("Walk");
            player.position = new Vector2(player.position.x, 1.6f);
            gameObject.GetComponent<jump>().hasBall = true;
            ball.SetActive(true);
        } else { player.localPosition = new Vector2(player.localPosition.x, 0.2f); ball.SetActive(false); }
    }
}
