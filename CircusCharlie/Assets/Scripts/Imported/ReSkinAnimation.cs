using UnityEngine;
using System.Collections;

public class ReSkinAnimation : MonoBehaviour
{

    public Texture2D spriteSheet;
    [SerializeField]
    private Sprite[] subSprites;
    [SerializeField]
    private string currentSpriteName;
    [SerializeField]
    private string newSpriteName;
    [SerializeField]
    private string currentSpriteNumber;

    void Start()
    {
        if (spriteSheet == null) return;
        currentSpriteName = GetComponent<SpriteRenderer>().sprite.name.Substring(0, GetComponent<SpriteRenderer>().sprite.name.IndexOf('_'));
        newSpriteName = spriteSheet.name.Substring(0, spriteSheet.name.IndexOf('_'));

        if (currentSpriteName == newSpriteName) return;
        subSprites = Resources.LoadAll<Sprite>("Char_Alt 1");

    }

    void LateUpdate()
    {
        if (spriteSheet == null) return;
        if (currentSpriteName == spriteSheet.name) return;

        currentSpriteNumber = GetComponent<SpriteRenderer>().sprite.name.Substring(GetComponent<SpriteRenderer>().sprite.name.IndexOf('_') + 1);//(GetComponent<SpriteRenderer>().sprite.name.Length - GetComponent<SpriteRenderer>().sprite.name.IndexOf('_')+1)));

        GetComponent<SpriteRenderer>().sprite = subSprites[int.Parse(currentSpriteNumber)];
    }
}