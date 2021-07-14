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

    void Start()
    {
        preview = transform.parent.gameObject.transform.GetChild(1).gameObject;
        myName = transform.parent.gameObject.transform.GetChild(2).gameObject.GetComponent<Text>();

        foreach (Skin skin in itemList)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(transform);
            button.gameObject.GetComponent<Image>().sprite = skin.icon;
            if (type == ItemType.Char)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.charEquiped = skin.id; UpdateSkin(skin.name); });
            if (type == ItemType.Lion)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.lionEquiped = skin.id; UpdateSkin(skin.name); });
            if (type == ItemType.Horse)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.horseEquiped = skin.id; UpdateSkin(skin.name); });
            if (type == ItemType.Ball)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.ballEquiped = skin.id; UpdateSkin(skin.name); });
            if (type == ItemType.Rope)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.ropeEquiped = skin.id; UpdateSkin(skin.name); });
            if (type == ItemType.Swing)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.swingEquiped = skin.id; UpdateSkin(skin.name); });
            if (type == ItemType.Platform)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.platformEquiped = skin.id; UpdateSkin(skin.name); });
        }
    }

    public void UpdateSkin(string name)
    {
        preview.SetActive(false); preview.SetActive(true);
        myButton.SetActive(false); myButton.SetActive(true);
        myName.text = name;
    }
}
