using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameplayEvents
{
    public static event System.Action<Card> OnCardClicked;

    public static event System.Action<Card> OnAttack;
    public static event System.Action<int> OnSummon;
    public static event System.Action<Card> OnHeal;

    public static void CardClicked(Card card)
    {
        OnCardClicked?.Invoke(card);
    }

    public static void Attack(Card card)
    {
        OnAttack?.Invoke(card);
    }
    public static void Summon(int count)
    {
        OnSummon?.Invoke(count);
    }
    public static void Heal(Card card)
    {
        OnHeal?.Invoke(card);
    }
}