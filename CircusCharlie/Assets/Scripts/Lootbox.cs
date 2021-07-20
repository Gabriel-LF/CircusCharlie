using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lootbox : MonoBehaviour
{
    public Skin[] skins;
    private int rng;

    public Image icon;
    public Image preview;
    public Text skinName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenBox()
    {
        rng = Random.Range(0,skins.Length);
        icon.gameObject.SetActive(true);
        icon.sprite = skins[rng].icon;
        preview.sprite = skins[rng].preview;
        skinName.text = skins[rng].name;
        skins[rng].unlocked = true;
    }

    public void LockEverything()
    {
        foreach(Skin skin in skins)
        {
            skin.unlocked = false;
        }
    }
}
