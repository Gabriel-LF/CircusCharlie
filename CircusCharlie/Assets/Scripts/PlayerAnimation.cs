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

    public bool horseStage;

    public bool swingStage;

    public void UpdateAnim()
    {
        if (menuStage)
        {
            anim.SetTrigger("Idle");
        }
        if (fireStage)
        {
            lion.SetActive(true);
            anim.SetTrigger("Mount");
        }
        else { lion.SetActive(false); }
    }
}
