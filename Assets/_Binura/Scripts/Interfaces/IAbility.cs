using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    public string Name { get; set; }

    public string Description { get; set; }

    public int EnergyCost { get; set; }

    public Sprite Icon { get; set; }

    public void Initialize(AbilitySO abilityData)
    {
        Name = abilityData.abilityName;
        Description = abilityData.description;
        EnergyCost = abilityData.energyCost;
        Icon = abilityData.icon;
    }

    public void Execute();
}
