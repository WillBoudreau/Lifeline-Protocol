using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine.UI;


public class ObstacleBehaviour : MonoBehaviour
{
    private enum ObstacleType {AirLeak, Fire, EngineRunOff, Hallucination};
    [SerializeField] private ObstacleType obstacleType;
    [Header("Best Traits and Skills")]
    [SerializeField] private List<string> bestTraits = new List<string>();
    [SerializeField] private List<string> bestSkills = new List<string>();
    [Header("Obstacle Properties")]
    public float timeToFix;
    public float damagePerSecond;
    public bool isFixed;
    public bool isHallucination;
    public float timeSpentFixing = 0f;
    [Header("References")]
    [SerializeField] private Image fixImage;
    private void Start()
    {
        SetObstacleType();
        fixImage.fillAmount = 0f;
    }

   /// <summary>
   /// Sets the stats for the obstacle based on the obstacle type
   /// </summary>
   private void SetStats()
    {
        switch (obstacleType)
        {
            case ObstacleType.AirLeak:
                bestTraits.Add("Engineer");
                bestSkills.Add("Repair");
                timeToFix = 10f;
                damagePerSecond = 5f;
                isHallucination = false;
                break;
            case ObstacleType.Fire:
                bestTraits.Add("Firefighter");
                bestSkills.Add("Extinguish");
                timeToFix = 8f;
                damagePerSecond = 10f;
                isHallucination = false;
                break;
            case ObstacleType.EngineRunOff:
                bestTraits.Add("Mechanic");
                bestSkills.Add("Repair");
                timeToFix = 12f;
                damagePerSecond = 7f;
                isHallucination = false;
                break;
            case ObstacleType.Hallucination:
                bestTraits.Add("Psychologist");
                bestSkills.Add("Calm");
                timeToFix = 15f;
                damagePerSecond = 0f;
                isHallucination = true;
                break;
        }
    }
    /// <summary>
    /// Sets the obstacle type
    /// </summary>
    public void SetObstacleType()
    {
        ObstacleType randomType = (ObstacleType)Random.Range(0, System.Enum.GetValues(typeof(ObstacleType)).Length);
        obstacleType = randomType;
        SetStats();
    }
    /// <summary>
    /// Fixes the obstacle, setting isFixed to true
    /// </summary>
    public IEnumerator FixObstacle()
    {
        StartCoroutine(DisplayFixProgress());
        while (timeSpentFixing < timeToFix)
        {
            timeSpentFixing += Time.deltaTime;
            yield return null;
        }
        isFixed = true;
        Destroy(gameObject);
    }
    /// <summary>
    /// Whn fixing the obstacle display the fix image to show progress
    /// </summary>
    private IEnumerator DisplayFixProgress()
    {
        while (timeSpentFixing < timeToFix)
        {
            timeSpentFixing += Time.deltaTime;
            fixImage.fillAmount = timeSpentFixing / timeToFix;
            yield return null;
        }
        fixImage.fillAmount = 0f;
    }
    /// <summary>
    /// When the player is not interacting with the obstacle reset it 
    /// </summary>
    public void ResetObstacle()
    {
        StopAllCoroutines();
        fixImage.fillAmount = 0f;
        isFixed = false;
        timeSpentFixing = 0f;
    }
}
