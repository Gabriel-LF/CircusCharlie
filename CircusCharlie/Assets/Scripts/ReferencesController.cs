using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReferencesController : MonoBehaviour
{
    public GameObject anim;

    void OnCollisionEnter2D(Collision2D hit)
    {
        if (hit.gameObject.CompareTag("Player"))
        {
            anim.GetComponent<Animator>().SetTrigger("Pula");
        }
    }
}
