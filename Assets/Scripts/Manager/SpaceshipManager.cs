using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Managers/Spaceships Manager")]
public class SpaceshipManager : ScriptableObject
{
    [SerializeField] List<SpaceshipData> spaceshipOptions;
    public float repairInitialTimer = 5f;

    public SpaceshipData GetRandomSpaceship()
    {
        int random = Random.Range(0, 2);
        Debug.Log(spaceshipOptions[random].name);
        return spaceshipOptions[random];

    }
}
