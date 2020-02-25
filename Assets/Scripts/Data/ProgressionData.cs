using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Data/Progression Data")]
public class ProgressionData : ScriptableObject
{
    [SerializeField] List<ProgressionLevel> levels;

    public ProgressionLevel GetCurrentLevel(int points)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            if (i + 1 == levels.Count)
                return levels[i];
            if (points < levels[i + 1].startingPoint)
                return levels[i];
        }
        return levels[0];
    }
}

[System.Serializable]
public class ProgressionLevel
{
    [Tooltip("Should be at least 1")]
    public int minDefects;
    [Space][Tooltip("If higher than ship slots, the maximum defects will be the number of ship slots")]
    public int maxDefects;
    [Space][Tooltip("Defines when the level starts")]
    public int startingPoint;
    public string id;
}