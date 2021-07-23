using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
    public List<Skin> itemList = new List<Skin>();
    public Button buttonPrefab;
    private GameObject preview;
    public ItemType type;
    public GameObject myButton;
    public Text myName;

    public List<Button> buttonList = new List<Button>();
    private bool wait = true;

    void Start()
    {
        preview = transform.parent.gameObject.transform.GetChild(1).gameObject;
        myName = transform.parent.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();

        foreach (Skin skin in itemList)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(transform, false);
            button.gameObject.GetComponent<Image>().sprite = skin.icon;
            buttonList.Add(button);
            if (type == ItemType.Char)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.charEquiped = skin.id; UpdateSkin(skin.name); });
                myName.text = itemList[MainMenu.Instance.charEquiped].name;
            }   
            if (type == ItemType.Lion)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.lionEquiped = skin.id; UpdateSkin(skin.name); });
                myName.text = itemList[MainMenu.Instance.lionEquiped].name;
            } 
            if (type == ItemType.Horse)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.horseEquiped = skin.id; UpdateSkin(skin.name); });
                myName.text = itemList[MainMenu.Instance.horseEquiped].name;
            }
            if (type == ItemType.Ball)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.ballEquiped = skin.id; UpdateSkin(skin.name); });
                myName.text = itemList[MainMenu.Instance.ballEquiped].name;
            } 
            if (type == ItemType.Rope)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.ropeEquiped = skin.id; UpdateSkin(skin.name); });
                myName.text = itemList[MainMenu.Instance.ropeEquiped].name;
            } 
            if (type == ItemType.Swing)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.swingEquiped = skin.id; UpdateSkin(skin.name); });
                myName.text = itemList[MainMenu.Instance.swingEquiped].name;
            } 
            if (type == ItemType.Platform)
            {
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.platformEquiped = skin.id; UpdateSkin(skin.name); });
                myName.text = itemList[MainMenu.Instance.platformEquiped].name;
            }

            if (skin.unlocked == false) { button.interactable = false; } else { button.interactable = true; }

            wait = false;
        }
    }

    void OnEnable()
    {
        if(!wait)
        {
            int i = 0;
            foreach (Skin skin in itemList)
            {
                if (skin.unlocked == false) { buttonList[i].interactable = false; } else { buttonList[i].interactable = true; }
                i++;
            }
        }
    }

    public void UpdateSkin(string name)
    {
        preview.SetActive(false); preview.SetActive(true);
        myButton.SetActive(false); myButton.SetActive(true);
        myName.text = name;
    }
}
