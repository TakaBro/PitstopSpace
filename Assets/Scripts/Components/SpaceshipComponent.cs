using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipComponent : MonoBehaviour
{
    [SerializeField] SpaceshipData spaceshipData;

    private void Start()
    {
        if (spaceshipData)
        {
            GetComponent<SpriteRenderer>().sprite = spaceshipData.sprite;
        }
    }
    public void SetData(SpaceshipData data)
    {
        spaceshipData = data;
        GetComponent<SpriteRenderer>().sprite = spaceshipData.sprite;
    }
}
