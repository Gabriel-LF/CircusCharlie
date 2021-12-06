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
        yield return new WaitForSeconds(Random.Range(2,4));
        myProjectile.SetActive(true);
        yield return new WaitForSeconds(3f);
        myProjectile.transform.localPosition = new Vector3(0, 0, 0);
        StartCoroutine(Throw());
    }
}
