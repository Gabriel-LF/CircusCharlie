using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingType : MonoBehaviour
{
    public Transform rope;
    public GameObject hanger;
    public Animator anim;
    public bool stopped;

    public void SetType(int i)
    {
        if (i == 0)
        {
            rope.localEulerAngles = new Vector3(0, 0, 0);
            stopped = true;
        }
        if (i == 1)
        {
            rope.localEulerAngles = new Vector3(0, 0, 45);
            anim.SetTrigger("Right");
            stopped = false;
        }
        if (i == 2)
        {
            rope.localEulerAngles = new Vector3(0, 0, -45);
            anim.SetTrigger("Left");
            stopped = false;
        }
    }

    public void RopeRelease()
    {
        StartCoroutine(Timer());
        hanger.layer = 2;
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        hanger.layer = 0;
    }

    public void SlowDown()
    {
        StartCoroutine(SlowTimer());
    }
    IEnumerator SlowTimer()
    {
        anim.speed = 0.5f;
        yield return new WaitForSeconds(2);
        anim.speed = 1f;
    }
}
