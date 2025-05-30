using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Card")]
public class CardSO : ScriptableObject
{
    public string Name;
    public int Health;
    public int Damage;

    public AbilitySO Ability; // Reference to the ability associated with the card
    public IAbility AbilityInstance; // Instance of the ability

    public void Initialize(GameObject card)
    {
        if (Ability != null)
        {
            // Initialize the ability with the card's data
            AbilityInstance = Ability.Initialize(card);
        }
        else
        {
            Debug.LogWarning("Ability is not assigned for this card.");
        }
    }
}
