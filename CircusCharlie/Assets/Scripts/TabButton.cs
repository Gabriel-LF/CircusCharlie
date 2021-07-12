using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabButton : MonoBehaviour
{
    public int tabNumber;
    public TabsController tab;

    public void OnClick()
    {
        tab.ChangeTab(tabNumber);
    }
}
