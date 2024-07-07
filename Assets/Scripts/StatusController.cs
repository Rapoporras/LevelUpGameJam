using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatusController : MonoBehaviour
{
    // Referencias a los componentes Image de las barras de energía y vida
    public Image energyBar;
    public Image healthBar;
    public Image hordaBar;
    public TextMeshProUGUI hordaText;
    public TextMeshProUGUI energyText;
    public TextMeshProUGUI healthText;
    // Valores máximos de energía y vida
    public int maxEnergy = 300;
    public int maxHealth = 4;
    public int maxHorda = 4;
    // Valores actuales de energía y vida
    [SerializeField][Range(0, 100)] private int currentEnergy;
    [SerializeField][Range(0, 4)] private int currentHealth;
    [SerializeField][Range(0, 4)] private int currentHorda;

    void Start()
    {
        // Inicializa la energía y vida actuales al máximo al comienzo del juego
        SetInitialValues();
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        // Si la energía llega a 0, el juego termina
        if (currentHealth <= 0)
        {
            GameManager.instance.gameOver = true;
        }
    }
    public void SetInitialValues()
    {

        currentEnergy = maxEnergy;
        currentHealth = maxHealth;
        currentHorda = 1;
        UpdateEnergy();
        UpdateHealth();
        UpdateHorda();
    }

    public void RestarEnergia(int cantidad)
    {
        // Restar la cantidad de energia especificada
        currentEnergy -= cantidad;
        // Actualizar la barra de energia
        UpdateEnergy();
    }

    public void SumarEnergia(int cantidad)
    {
        // Sumar la cantidad de energia especificada
        currentEnergy += cantidad;
        // Actualizar la barra de energia
        UpdateEnergy();
    }

    public void RestarVida(int cantidad)
    {
        // Restar la cantidad de vida especificada
        currentHealth -= cantidad;
        // Actualizar la barra de vida
        UpdateHealth();
    }

    public void SumarVida(int cantidad)
    {
        // Sumar la cantidad de vida especificada
        currentHealth += cantidad;
        // Actualizar la barra de vida
        UpdateHealth();
    }
    public void SumarHorda(int cantidad)
    {
        // Sumar la cantidad de vida especificada
        currentHorda = cantidad;
        // Actualizar la barra de vida
        UpdateHorda();
    }

    public void RestarHorda(int cantidad)
    {
        // Restar la cantidad de vida especificada
        currentHorda -= cantidad;
        // Actualizar la barra de vida
        UpdateHorda();
    }

    // Llama a esta función para actualizar la energía
    private void UpdateEnergy()
    {
        // Actualiza el valor de la energía actual
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
        UpdateEnergyBar();
        energyText.text = currentEnergy.ToString();
    }

    // Llama a esta función para actualizar la vida
    private void UpdateHealth()
    {
        // Actualiza el valor de la vida actual
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
        healthText.text = currentHealth.ToString();
    }
    private void UpdateHorda()
    {
        Debug.Log("UpdateHorda");
        // Actualiza el valor de la vida actual
        currentHorda = Mathf.Clamp(currentHorda, 0, maxHorda);
        UpdateHordaBar();
        hordaText.text = currentHorda.ToString();
    }

    private void UpdateHordaBar()
    {
        if (hordaBar != null)
        {
            hordaBar.fillAmount = (float)currentHorda / maxHorda;
        }
    }

    // Función para actualizar el fill amount del sprite de la barra de energía
    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            energyBar.fillAmount = (float)currentEnergy / maxEnergy;
        }
    }

    // Función para actualizar el fill amount del sprite de la barra de vida
    private void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }
    public int GetEnergy()
    {
        return currentEnergy;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public int GetHorda()
    {
        return currentHorda;
    }
}