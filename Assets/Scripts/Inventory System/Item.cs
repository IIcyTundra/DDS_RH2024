using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Item")]
public class Item : ScriptableObject, IUseable
{
    public string ItemName;
    public Sprite ItemIcon;
    public EffectType ItemType;
    public bool IsStackable;
    public int MaxStack;
    public int CurrentStack;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    } 
}
