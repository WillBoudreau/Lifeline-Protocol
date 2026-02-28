using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public enum CharacterLifeStage { Child, Teen, Adult, Elder }
    [Header("Character Life Stage")]
    public CharacterLifeStage lifeStage;

    [Header("Default Character Stats")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int strength = 10;
    [SerializeField] private int age = 25;
    [SerializeField] private int speed = 5;
    [Header("Current Character Stats")]
    public int currentHealth;
    public int currentStrength;
    public int currentAge;
    public int currentSpeed;
    [Header("Stat Min Ranges")]
    [SerializeField] private int minHealth = 0;
    [SerializeField] private int minStrength = 0;
    [SerializeField] private int minAge = 0;
    [SerializeField] private int minSpeed = 0;
    [Header("Stat Max Ranges")]
    [SerializeField] private int maxHealthRange = 200;
    [SerializeField] private int maxStrengthRange = 20;
    [SerializeField] private int maxAgeRange = 100;
    [SerializeField] private int maxSpeedRange = 10;
    [Header("Age Values")]
    [SerializeField] private int childAge = 13;
    [SerializeField] private int teenAge = 20;
    [SerializeField] private int adultAge = 65;

    /// <summary>
    /// Sets the characters stats based on the characters age
    /// </summary>
    public void SetStats()
    {
        switch (lifeStage)
        {
            case CharacterLifeStage.Child:
                currentHealth = maxHealth / 2;
                currentStrength = strength / 2;
                currentSpeed = speed / 2;
                break;
            case CharacterLifeStage.Teen:
                currentHealth = (int)(maxHealth * 0.75f);
                currentStrength = (int)(strength * 0.75f);
                currentSpeed = (int)(speed * 0.75f);
                break;
            case CharacterLifeStage.Adult:
                currentHealth = maxHealth;
                currentStrength = strength;
                currentSpeed = speed;
                break;
            case CharacterLifeStage.Elder:
                currentHealth = (int)(maxHealth * 0.5f);
                currentStrength = (int)(strength * 0.5f);
                currentSpeed = (int)(speed * 0.5f);
                break;
        }
    }

    #region Setters

    /// <summary>
    /// Sets the character's health to a new value, ensuring it stays within the defined minimum and maximum ranges.
    /// </summary>
    public int SetHealth(int health)
    {
        currentHealth = Mathf.Clamp(health, minHealth, maxHealthRange);
        return currentHealth;
    }

    /// <summary>
    /// Sets the character's strength to a new value, ensuring it stays within the defined minimum and maximum ranges.
    /// </summary>
    public int SetStrength(int strength)
    {
        currentStrength = Mathf.Clamp(strength, minStrength, maxStrengthRange);
        return currentStrength;
    }

    /// <summary>
    /// Sets the character's age to a new value, ensuring it stays within the defined minimum and maximum ranges.
    /// </summary>
    public int SetAge()
    {
        currentAge = Mathf.Clamp(currentAge, minAge, maxAgeRange);
        if(currentAge < childAge)
        {
            lifeStage = CharacterLifeStage.Child;
        }
        else if(currentAge >= childAge && currentAge < teenAge)
        {
            lifeStage = CharacterLifeStage.Teen;
        }
        else if(currentAge >= teenAge && currentAge < adultAge)
        {
            lifeStage = CharacterLifeStage.Adult;
        }
        else if(currentAge >= adultAge)
        {
            lifeStage = CharacterLifeStage.Elder;
        }
        return currentAge;
    }

    /// <summary>
    /// Sets the character's speed to a new value, ensuring it stays within the defined minimum and maximum ranges.
    /// </summary>
    public int SetSpeed(int speed)
    {
        currentSpeed = Mathf.Clamp(speed, minSpeed, maxSpeedRange);
        return currentSpeed;
    }

    #endregion
}
