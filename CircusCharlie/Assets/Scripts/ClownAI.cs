using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownAI : MonoBehaviour
{
    public GameObject myProjectile;
    [SerializeField] float cooldown;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Throw());
    }

    IEnumerator Throw()
    {
        yield return new WaitForSeconds(Random.Range(cooldown - 1,cooldown + 2));
        myProjectile.SetActive(true);
        yield return new WaitForSeconds(cooldown);
        myProjectile.transform.localPosition = new Vector3(0, 0, 0);
        StartCoroutine(Throw());
    }
}
