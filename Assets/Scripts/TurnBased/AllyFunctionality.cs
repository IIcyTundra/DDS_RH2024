using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AllyFunctionality : MonoBehaviour
{
    [SerializeField] private Player PlayerChar;
    [SerializeField] private Image PlayerIcon;
    [SerializeField] private TextMeshProUGUI HealthText, AbilityText;
    private void OnEnable()
    {
        PlayerChar.EntityHealth.OnValueChanged += UpdateHealthText;
        PlayerIcon.sprite = PlayerChar.EntityIcon;

    }

    private void OnDisable()
    {
        PlayerChar.EntityHealth.OnValueChanged -= UpdateHealthText;
    }

    public void OnAttack()
    {

    }

    public void OnBlock()
    {

    }


    private void UpdateHealthText(float previousValue, float newValue)
    {
        AbilityText.text = "Health: " + newValue;
    }
}
