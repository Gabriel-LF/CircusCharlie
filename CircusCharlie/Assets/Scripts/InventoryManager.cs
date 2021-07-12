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

    public GameObject myButton;

    void Start()
    {
        preview = transform.parent.gameObject.transform.GetChild(1).gameObject;

        foreach (Skin skin in itemList)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(transform);
            button.gameObject.GetComponent<Image>().sprite = skin.icon;
            button.gameObject.GetComponent<Button>().onClick.AddListener(delegate { MainMenu.Instance.ballEquiped = skin.id; UpdateSkin(); });
        }
    }

    public void UpdateSkin()
    {
        preview.SetActive(false); preview.SetActive(true);
        myButton.SetActive(false); myButton.SetActive(true);
    }
}
