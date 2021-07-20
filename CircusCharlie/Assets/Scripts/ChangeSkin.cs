using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSkin : MonoBehaviour
{
    public AnimatorOverrideController[] skins;
    public ItemType type;
    public MainMenu mm;

    public bool wait = true;

    void OnEnable()
    {
        //mm = MainMenu.Instance;
        if (!wait)
        {
            UpdateSkin();
        }
        else { StartCoroutine(HoldUp()); }
    }

    public void UpdateSkin()
    {
        if (type == ItemType.Char)
            GetComponent<Animator>().runtimeAnimatorController = skins[mm.charEquiped] as RuntimeAnimatorController;
        if (type == ItemType.Lion)
            GetComponent<Animator>().runtimeAnimatorController = skins[mm.lionEquiped] as RuntimeAnimatorController;
        if (type == ItemType.Horse)
            GetComponent<Animator>().runtimeAnimatorController = skins[mm.horseEquiped] as RuntimeAnimatorController;
    }

    IEnumerator HoldUp()
    {
        yield return new WaitForSeconds(0.001f);
        wait = false;
        UpdateSkin();
    }
}
