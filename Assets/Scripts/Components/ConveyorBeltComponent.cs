using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConveyorBeltComponent : MonoBehaviour
{
    [SerializeField] ItemsManager itemsManager;
    [SerializeField] ConveyorBeltData data;
    [SerializeField] ItemComponent itemComponent;
    [SerializeField] Transform itemContainer;
    [SerializeField] UnityEvent onTimeReached;
    [SerializeField] List<ItemComponent> items;

    float timer;
    
    Dictionary<Vector2, Vector2> positionPairs;
    private void Start()
    {
        InitializePositionPairs();
        foreach (Vector2 position in data.positions)
        {
            ItemComponent item = Instantiate(itemComponent, itemContainer);
            item.Position = position;
            items.Add(item);
        }
    }

    public void Update()
    {
        if (TimeReached(data.moveDelay))
        {
            Debug.Log("Move");
            onTimeReached.Invoke();
            MoveItems();
        }
    }

    public void InitializePositionPairs()
    {
        positionPairs = new Dictionary<Vector2, Vector2>();
        for (int i = 0; i < data.positions.Count; i++)
        {
            if (i+1 == data.positions.Count)
            {
                positionPairs.Add(data.positions[i], data.positions[0]);
            }
            else
            {
                positionPairs.Add(data.positions[i], data.positions[i+1]);
            }
        }
    }

    private bool TimeReached(float delay)
    {
        timer += Time.deltaTime;
        if (timer < delay)
        {
            return false;
        }
        else
        {
            timer = 0;
            return true;
        }
    }

    void MoveItems()
    {
        foreach (ItemComponent item in items)
        {
            Vector2 target;
            positionPairs.TryGetValue(item.Position, out target);
            item.MoveTo(target, data.moveDelay);
            if (item.Position == data.LastPosition())
            {
                item.Enable(false);
                if (!item.IsFilled)
                {
                    item.SetData(itemsManager.GetRandomItem());
                }
            }
            if (item.Position == data.positions[0])
            {
                item.Enable(true);
            }
        }
    }
}
