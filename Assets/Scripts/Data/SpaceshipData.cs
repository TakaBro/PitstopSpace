using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Data/Spaceship" )]
public class SpaceshipData : ScriptableObject
{
    //public float height;
    public List<Slots> slots;
    public Sprite sprite;
}

[Serializable]
public class Slots
{
    public int id;
    public bool enable;
}