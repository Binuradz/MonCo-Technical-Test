using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class A_Attack : MonoBehaviour, IAbility
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int EnergyCost { get; set; }
    public Sprite Icon { get; set; }

    // Initialize the ability with the provided data
    public void Initialize(AbilitySO abilityData)
    {
        Name = abilityData.abilityName;
        Description = abilityData.description;
        EnergyCost = abilityData.energyCost;
        Icon = abilityData.icon;
    }

    // Execute the attack ability
    public void Execute()
    {
        Debug.Log($"Executing attack ability: {Name}");
        GameplayEvents.Attack(GetComponent<Card>());
    }
}