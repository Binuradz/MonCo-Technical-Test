using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public static Hand Instance { get; private set; }
    [SerializeField] private int startingHandSize = 5;
    [SerializeField] private PlayerDeckSO playerDeck;
    List<CardSO> playerCardsCache;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnEnable()
    {
        GameplayEvents.OnSummon += DrawCards;
    }
    void OnDisable()
    {
        GameplayEvents.OnSummon -= DrawCards;
    }
    void Start()
    {
        DrawInitialHand();
    }

    public void DrawInitialHand()
    {
        DrawCards(startingHandSize);
    }
    public void DrawCards(int numberOfCards)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            GameObject card = PoolManager.Instance.cardsPool.GetObject();
            card.transform.SetParent(transform);
            card.transform.localScale = Vector3.one;
            card.transform.localPosition = Vector3.zero;
            CardSO cardData = GetRandomCardFromDeck();
            if (cardData != null)
            {
                card.GetComponent<Card>().Initialize(cardData);
            }
            else
            {
                Debug.LogWarning("No valid card data found for drawing.");
            }
        }
    }

    CardSO GetRandomCardFromDeck()
    {
        if(playerCardsCache == null || playerCardsCache.Count == 0)
        {
            playerCardsCache = playerDeck.GetPlayerCards();
        }
        if (playerCardsCache.Count == 0)
        {
            Debug.LogWarning("No cards available in the player's deck.");
            return null;
        }

        int randomIndex = Random.Range(0, playerCardsCache.Count);
        return playerCardsCache[randomIndex];
    }
}
