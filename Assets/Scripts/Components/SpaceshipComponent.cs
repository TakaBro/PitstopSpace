using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpaceshipComponent : MonoBehaviour
{
    [SerializeField] SpaceshipData spaceshipData;
    [SerializeField] UnityEvent onShipReset;
    public List<ShipDefect> problems;
    

    public void ResetShip(SpaceshipData data)
    {
        spaceshipData = data;
        GetComponent<SpriteRenderer>().sprite = spaceshipData.sprite;
        transform.position = new Vector2(0, -10);
        problems = new List<ShipDefect>();

        onShipReset.Invoke();
    }

    public void CreateDefects(SlotCode slot, ItemData item)
    {
        problems.Add(new ShipDefect() {slot = slot, item = item });
    }
}

public class ShipDefect
{
    public SlotCode slot;
    public ItemData item;
}
