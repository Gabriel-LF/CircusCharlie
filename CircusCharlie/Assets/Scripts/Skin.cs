using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Char, Lion, Rope, Horse, Ball, Swing, Platform
}

[CreateAssetMenu(fileName = "New Skin", menuName = "Skin")]
public class Skin : ScriptableObject
{
    public new string name;
    public ItemType type;
    public Sprite icon;
    public int id;

    public bool unlocked;
}
