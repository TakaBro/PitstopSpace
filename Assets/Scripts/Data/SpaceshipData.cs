using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Data/Spaceship" )]
public class SpaceshipData : ScriptableObject
{
    public List<SlotCode> slots;
    public Sprite sprite;
}