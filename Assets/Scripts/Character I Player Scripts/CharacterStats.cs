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
    [Header("Stat Growth Rates")]
    [SerializeField] private float childGrowthRate = 0.5f;
    [SerializeField] private float teenGrowthRate = 0.75f;
    [SerializeField] private float adultGrowthRate = 1.0f;
    [SerializeField] private float elderGrowthRate = 0.5f;

    /// <summary>
    /// Sets the characters stats based on the characters age
    /// </summary>
    public void SetStats()
    {
        SetAge();
        switch (lifeStage)
        {
            case CharacterLifeStage.Child:
                currentHealth = SetHealth((int)(maxHealth * childGrowthRate));
                currentStrength = SetStrength((int)(strength * childGrowthRate));
                currentSpeed = SetSpeed((int)(speed * childGrowthRate));
                break;
            case CharacterLifeStage.Teen:
                currentHealth = SetHealth((int)(maxHealth * teenGrowthRate));
                currentStrength = SetStrength((int)(strength * teenGrowthRate));
                currentSpeed = SetSpeed((int)(speed * teenGrowthRate));
                break;
            case CharacterLifeStage.Adult:
                currentHealth = SetHealth((int)(maxHealth * adultGrowthRate));
                currentStrength = SetStrength((int)(strength * adultGrowthRate));
                currentSpeed = SetSpeed((int)(speed * adultGrowthRate));
                break;
            case CharacterLifeStage.Elder:
                currentHealth = SetHealth((int)(maxHealth * elderGrowthRate));
                currentStrength = SetStrength((int)(strength * elderGrowthRate));
                currentSpeed = SetSpeed((int)(speed * elderGrowthRate));
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
