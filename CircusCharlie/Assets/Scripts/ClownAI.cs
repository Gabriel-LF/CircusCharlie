using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAI : MonoBehaviour
{
    public GameObject myProjectile;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Throw());
    }

    IEnumerator Throw()
    {
        yield return new WaitForSeconds(3f);
        myProjectile.SetActive(true);
    }
}
