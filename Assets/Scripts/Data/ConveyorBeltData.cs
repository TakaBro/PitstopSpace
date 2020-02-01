using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Data/Conveyor Belt")]
public class ConveyorBeltData : ScriptableObject
{
    public float moveDelay;
    public List<Vector2> positions;

    public Vector2 LastPosition()
    {
        return positions[positions.Count -1];
    }
}
