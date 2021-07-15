using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinSprite : MonoBehaviour
{
    public List<Sprite> skin = new List<Sprite>();
    public ItemType type;

    public MainMenu mm;
    public SpriteRenderer sr;
    public Image im;

    public bool wait = true;

    void OnEnable()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        if (sr == null)
            im = gameObject.GetComponent<Image>();
        mm = MainMenu.Instance;
        if (!wait)
        {
            UpdateSkin();
        } else { StartCoroutine(HoldUp()); }
    }
    public void UpdateSkin()
    {
        if (type == ItemType.Char)
        {
            if (sr != null) { sr.sprite = skin[mm.charEquiped]; } else { im.sprite = skin[mm.charEquiped]; }
        }
        if (type == ItemType.Lion)
        {
            if (sr != null) { sr.sprite = skin[mm.lionEquiped]; } else { im.sprite = skin[mm.lionEquiped]; }
        }
        if (type == ItemType.Ball)
        {
            if (sr != null) { sr.sprite = skin[mm.ballEquiped]; } else { im.sprite = skin[mm.ballEquiped]; }
        }
    }

    IEnumerator HoldUp()
    {
        yield return new WaitForSeconds(0.0001f);
        wait = false;
        UpdateSkin();
    }
}
