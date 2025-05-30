using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button btn_execute;
    [SerializeField] private Button btn_viewDetails;

    [Header("Details Panel")]
    [SerializeField] private GameObject detailsPanel;
    [SerializeField] private Card detailsCard;

    [SerializeField] private TextMeshProUGUI detail_type;
    [SerializeField] private TextMeshProUGUI detail_name;

    void OnEnable()
    {
        GameplayEvents.OnCardClicked += HandleCardClicked;
        btn_viewDetails.onClick.AddListener(ShowDetailsPanel);
    }
    void OnDisable()
    {
        GameplayEvents.OnCardClicked -= HandleCardClicked;
        btn_viewDetails.onClick.RemoveListener(ShowDetailsPanel);
    }
    private void HandleCardClicked(Card card)
    {
        btn_execute.onClick.RemoveAllListeners();

        btn_execute.onClick.AddListener(card.ExecuteAbility);
        UpdateDetailsPanel(card);
    }
    void ShowDetailsPanel()
    {
        detailsPanel.SetActive(true);
    }

    public void UpdateDetailsPanel(Card card)
    {
        CardSO cardData = card.GetCardData();
        if (cardData == null)
        {
            Debug.LogError("Card data is not assigned.");
            return;
        }
        detailsCard.Initialize(cardData);
        detail_type.text = cardData.Ability != null ? cardData.Ability.abilityType.ToString() : "No Type";
        detail_name.text = cardData.Ability != null ? cardData.Ability.abilityName : "No Ability";
    }
}
