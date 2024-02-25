using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> inventory;
    public int space = 20;

    private void OnAwake()
    {
        if(inventory == null)
            inventory = new List<Item>();
    }

    public void Add(Item item)
    {
        if (inventory.Count >= space)
        {
            Debug.Log("Not enough room.");
        }
        if(item.IsStackable)
        {
            if(inventory.Contains(item))
            {
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i] == item)
                    {
                        if (inventory[i].CurrentStack < inventory[i].MaxStack)
                        {
                            inventory[i].CurrentStack++;
                            return;
                        }
                    }
                }
            }
        }
        else
        {
            inventory.Add(item);
        }
        
    }

    public void Remove(Item item)
    {
        if (item.IsStackable) { item.CurrentStack--;}
        inventory.Remove(item);
    }

    public void UseItem(Item item)
    {
        item.Use();
    }

    public void RemoveAt(int index)
    {
        inventory.RemoveAt(index);
    }

    public void Clear()
    {
        inventory.Clear();
    }

}
    
