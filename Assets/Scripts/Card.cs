using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private CardSO cardData;

    [Header("Card Details")]
    [SerializeField] private TextMeshProUGUI t_Name;
    [SerializeField] private TextMeshProUGUI t_Health;
    [SerializeField] private TextMeshProUGUI t_Ability;
    [SerializeField] private TextMeshProUGUI t_Damage;
    [SerializeField] private TextMeshProUGUI t_Description;
    [SerializeField] private Image i_Icon;

    void OnEnable()
    {
        GameplayEvents.OnHeal += GainHealth;
    }
    void OnDisable()
    {
        GameplayEvents.OnHeal -= GainHealth;
    }

    public void Initialize(CardSO _cardData)
    {
        if (_cardData == null)
        {
            Debug.LogError("Card data is not assigned in the inspector.");
            return;
        }
        cardData = _cardData;
        cardData.Initialize(gameObject);
        UpdateCardUI();
    }

    public void ExecuteAbility()
    {
        if (cardData.AbilityInstance != null)
        {
            cardData.AbilityInstance.Execute();
        }
        else
        {
            Debug.LogWarning("Ability instance is not initialized.");
        }
    }

    void UpdateCardUI()
    {
        if (cardData == null)
        {
            Debug.LogError("Card data is not assigned.");
            return;
        }

        t_Name.text = cardData.Name;
        t_Ability.text = cardData.Ability != null ? cardData.Ability.abilityName : "No Ability";
        t_Damage.text = cardData.Damage.ToString();
        t_Health.text = cardData.Health.ToString();
        t_Description.text = cardData.Ability != null ? cardData.Ability.description : "No Description";
        i_Icon.sprite = cardData.Ability != null ? cardData.Ability.icon : null;
    }

    public void OnCardSelected()
    {
        GameplayEvents.CardClicked(this);
    }

    public CardSO GetCardData()
    {
        return cardData;
    }

    void GainHealth(Card _card)
    {
        int healthGain = _card.cardData.Damage;
        cardData.Health += healthGain;
        Debug.Log($"Gained {healthGain} health. New Health: {cardData.Health}");
        UpdateCardUI();
    }
}
