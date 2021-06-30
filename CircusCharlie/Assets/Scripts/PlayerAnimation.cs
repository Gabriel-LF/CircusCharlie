using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    public bool fireStage;
    public GameObject lion;

    public void UpdateAnim()
    {
        if(fireStage)
        {
            lion.SetActive(true);
            anim.SetTrigger("Mount");
        }
        else { lion.SetActive(false); }
    }
}
