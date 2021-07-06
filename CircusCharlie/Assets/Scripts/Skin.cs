using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class Skin : ScriptableObject
{
    public new string name;
    public string type;
    public Sprite icon;

    public bool unlocked;
    public bool equiped;
}
