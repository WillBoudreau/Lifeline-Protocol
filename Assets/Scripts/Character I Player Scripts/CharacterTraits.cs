using System.Collections.Generic;
using UnityEngine;

public class CharacterTraits : MonoBehaviour
{
    [Header("Character Trait Settings")]
    [SerializeField] private int maxTraits = 3;
    [SerializeField] private int maxSkills = 3;
    [Header("Current Character Trait Settings")]
    public List<string> currentTraits = new List<string>();
    public List<string> currentSkills = new List<string>();
    [Header("Possible Character Trait Settings")]
    public List<string> possibleTraits = new List<string>() {"Crew", "Passenger", "Engineer", "Scientist", "Doctor", "Security", "Pilot", "Communications", "Navigator", "Technician"};
    public List<string> possibleSkills = new List<string>() {"Repair", "Medical", "Combat", "Piloting", "Navigation", "Communication", "Technical", "Survival", "Leadership", "Stealth"};

    /// <summary>
    /// Sets the chracters traits based on the characters previous traits and skills
    /// This is too avoid too much repetition in the traits and skills of the characters
    /// </summary>
    public void SetTraits(List<string> previousTraits, List<string> previousSkills)
    {
        currentTraits.Clear();
        currentSkills.Clear();

        // Add traits and skills from the previous character
        currentTraits.AddRange(previousTraits);
        currentSkills.AddRange(previousSkills);

        // Add new traits and skills based on the possible traits and skills
        while (currentTraits.Count < maxTraits)
        {
            string newTrait = possibleTraits[Random.Range(0, possibleTraits.Count)];
            if (!currentTraits.Contains(newTrait))
            {
                currentTraits.Add(newTrait);
            }
        }

        while (currentSkills.Count < maxSkills)
        {
            string newSkill = possibleSkills[Random.Range(0, possibleSkills.Count)];
            if (!currentSkills.Contains(newSkill))
            {
                currentSkills.Add(newSkill);
            }
        }
    }
}
