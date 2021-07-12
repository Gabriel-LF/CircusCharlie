using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabsController : MonoBehaviour
{
    public List<GameObject> tab = new List<GameObject>();

    public void ChangeTab(int i)
    {
        foreach (GameObject tab in tab)
        {
            tab.SetActive(false);
        }
        tab[i].SetActive(true);
    }
}
