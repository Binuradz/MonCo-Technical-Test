using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDeck", menuName = "ScriptableObjects/PlayerDeckSO")]
public class PlayerDeckSO : ScriptableObject
{
    [SerializeField] private List<CardSO> deck = new List<CardSO>();

    public void AddCard(CardSO card)
    {
        if (card != null && !deck.Contains(card))
        {
            deck.Add(card);
        }
        else
        {
            Debug.LogWarning("Card is null or already exists in the player's cards.");
        }
    }

    public void RemoveCard(CardSO card)
    {
        if (card != null && deck.Contains(card))
        {
            deck.Remove(card);
        }
        else
        {
            Debug.LogWarning("Card is null or does not exist in the player's cards.");
        }
    }

    public List<CardSO> GetPlayerCards()
    {
        return new List<CardSO>(deck);
    }
}