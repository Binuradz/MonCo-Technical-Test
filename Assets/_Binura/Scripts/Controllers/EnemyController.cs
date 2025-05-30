using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] int hp = 50;

    [Header("Display Settings")]
    TextMeshPro healthText;

    private void Awake()
    {
        InitializeHealthText();
    }

    void OnEnable()
    {
        GameplayEvents.OnAttack += TakeDamage;
    }

    void OnDisable()
    {
        GameplayEvents.OnAttack -= TakeDamage;
    }

    public void TakeDamage(Card card)
    {
        int damage = card.GetCardData().Damage;
        hp -= damage;
        UpdateHealthText();

        if (hp <= 0)
        {
            Die();
        }
    }
    void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + hp;
        }
    }
    void Die()
    {
        Debug.Log("Enemy has died.");
        Destroy(gameObject); 
    }

    void InitializeHealthText()
    {
        if (healthText == null)
        {
            GameObject healthTextObject = new GameObject("HealthText");
            healthTextObject.transform.SetParent(transform);
            healthText = healthTextObject.AddComponent<TextMeshPro>();
        }
        healthText.text = "HP: " + hp;
        healthText.fontSize = 6;
        healthText.GetComponent<RectTransform>().sizeDelta = new Vector2(2, 1);
        healthText.color = Color.red;
        healthText.alignment = TextAlignmentOptions.Center;
        healthText.transform.localPosition = new Vector3(0, 1.5f, 0); // Adjust position above the enemy
    }
}
