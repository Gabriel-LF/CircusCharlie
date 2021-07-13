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

    void Start()
    {
        preview = transform.parent.gameObject.transform.GetChild(1).gameObject;

        foreach (Skin skin in itemList)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(transform);
            button.gameObject.GetComponent<Image>().sprite = skin.icon;
            if (type == ItemType.Char)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.charEquiped = skin.id; UpdateSkin(); });
            if (type == ItemType.Lion)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.lionEquiped = skin.id; UpdateSkin(); });
            if (type == ItemType.Horse)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.horseEquiped = skin.id; UpdateSkin(); });
            if (type == ItemType.Ball)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.ballEquiped = skin.id; UpdateSkin(); });
            if (type == ItemType.Rope)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.ropeEquiped = skin.id; UpdateSkin(); });
            if (type == ItemType.Swing)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.swingEquiped = skin.id; UpdateSkin(); });
            if (type == ItemType.Platform)
                button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.platformEquiped = skin.id; UpdateSkin(); });
        }
    }

    public void UpdateSkin()
    {
        preview.SetActive(false); preview.SetActive(true);
        myButton.SetActive(false); myButton.SetActive(true);
    }
}
