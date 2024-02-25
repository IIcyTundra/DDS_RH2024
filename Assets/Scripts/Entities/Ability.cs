using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hertzole.ScriptableValues;



[CreateAssetMenu(fileName = "New Ability", menuName = "Abilities/Ability")]
public class Ability : ScriptableObject, IUseable
{
    public string AbilityName;
    public Sprite AbilityIcon;
    public EffectType AbilityType;
    public float AbilityCost;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }   
}
