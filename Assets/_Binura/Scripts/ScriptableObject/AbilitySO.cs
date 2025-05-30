using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAbility", menuName = "Data/Ability")]
public class AbilitySO : ScriptableObject
{
    public AbilityType abilityType;
    public string abilityName;
    public string description;
    public int energyCost;
    public Sprite icon;

    /* Some extra fields that can be used to customize the ability at scale.
        public AnimationClip animationOverride; // Optional: Animation for the ability
        public AudioClip sfxOverride; // Optional: Sound effect for the ability
        public GameObject vfxOverride; // Optional: Particle effect for the ability
     */

     public IAbility Initialize(GameObject card)
     {
        IAbility ability = null;
         switch (abilityType)
        {
            case AbilityType.Attack:
                ability = card.AddComponent<A_Attack>();
                ability.Initialize(this);
                return ability;
            case AbilityType.Heal:
                ability = card.AddComponent<A_Heal>();
                ability.Initialize(this);
                return ability;
            case AbilityType.Summon:
                ability = card.AddComponent<A_Summon>();
                ability.Initialize(this);
                return ability;
            default:
                Debug.LogError($"Ability type {abilityType} is not implemented.");
                return null;
        }
     }
}