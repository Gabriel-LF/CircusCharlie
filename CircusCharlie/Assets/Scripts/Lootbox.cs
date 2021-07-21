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
    public Text skinName, coins;

    public Button buy;
    public Sprite moneyBag;

    // Start is called before the first frame update
    void Start()
    {
        LoadProgress();
    }

    // Update is called once per frame
    public void UpdateUI()
    {
        if(MainMenu.Instance.totalCoins < 100) { buy.interactable = false; } else { buy.interactable = true; }
        MainMenu.Instance.UpdateUI();
        coins.text = MainMenu.Instance.totalCoins.ToString();
    }

    public void OpenBox()
    {
        MainMenu.Instance.totalCoins -= 100;
        rng = Random.Range(0,skins.Length);
        icon.gameObject.SetActive(true);
        icon.sprite = skins[rng].icon;
        if(skins[rng].unlocked == false)
        {
            preview.sprite = skins[rng].preview;
            skinName.text = skins[rng].name;
            skins[rng].unlocked = true;
            PlayerPrefsX.SetBool(skins[rng].name, true);
        } else {
            MainMenu.Instance.totalCoins += 50;
            preview.sprite = moneyBag;
            skinName.text = ("50 Coins");
        }
        UpdateUI();
    }

    public void LockEverything()
    {
        foreach(Skin skin in skins)
        {
            skin.unlocked = false;
        }
    }

    public void LoadProgress()
    {
        foreach (Skin skin in skins)
        {
            skin.unlocked = PlayerPrefsX.GetBool(skin.name);
        }
    }

    public void WatchAd()
    {
        MainMenu.Instance.totalCoins += 20;
        UpdateUI();
    }
}
