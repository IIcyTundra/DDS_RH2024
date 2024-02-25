using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hertzole.ScriptableValues;
[CreateAssetMenu(fileName = "New Entity", menuName = "Entity")]
public class Entity : ScriptableObject
{
    
    public string EntityName;
    public Sprite EntityIcon;
    public float MaxHealth;
    public ScriptableFloat EntityHealth;
    public float EntityAttack;
    [Range(0,1)] public float EntityDefense;
    public bool IsEnemy;

    public void OnEnable()
    {
        if(EntityHealth.DefaultValue == 0 || EntityHealth.Value <= MaxHealth)
        {
            EntityHealth.Value = MaxHealth;
        }
    }


    public void Heal(float amount)
    {
        if (EntityHealth.Value + amount > MaxHealth)
            EntityHealth.Value = MaxHealth;
        else
            EntityHealth.Value += amount;  
    }

    public void TakeDamage(float amount)
    {
        EntityHealth.Value -= amount * EntityDefense;
        if (EntityHealth.Value <= 0)
        {
            Die();
        }
    }


    public virtual void Die()
    {
       
    }
}
