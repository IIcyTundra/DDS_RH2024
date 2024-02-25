using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Abilities", menuName = "Abilities/Ability List")]
public class Abilities : ScriptableObject
{
    public List<Ability> AbilitiesList;
    public int space;

    public void Add(Ability ability)
    {
        
        if (AbilitiesList.Count >= space && AbilitiesList.Contains(ability))
            return;
        else
            AbilitiesList.Add(ability);
    }

    public void Remove(Ability ability)
    {
        AbilitiesList.Remove(ability);
    }

    public void UseAbility(Ability ability)
    {
        ability.Use();
    }
}
