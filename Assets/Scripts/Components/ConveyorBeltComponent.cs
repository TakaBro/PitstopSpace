using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConveyorBeltComponent : MonoBehaviour
{
    [SerializeField] ConveyorBeltData data;
    [SerializeField] ItemComponent itemComponent;
    [SerializeField] UnityEvent onTimeReached;
    List<ItemComponent> items;
    float timer;

    public void Update()
    {
        if (TimeReached(data.moveDelay))
        {
            Debug.Log("Move");
            onTimeReached.Invoke();
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
}
