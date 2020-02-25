using GameDevToolbelt;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
    [SerializeField] int timer = 0;
    [SerializeField] int fixedShips = 0;
    [SerializeField] int missedShips = 0;
    [SerializeField] int lifes = 3;
    [SerializeField] int points = 0;

    public Action<int> onTimerChange;
    public Action<int> onFixedShipsChange;
    public Action<int> onMissedShipsChange;
    public Action<int> onLifesChange;
    public Action<int> onPointsChange;
    public Action onLifeDepleted;
    [SerializeField] ScriptableEvent onGameLost;
    

    public int Points
    {
        get => points;
    }
    public void Reset()
    {
        timer = 0;
        fixedShips = 0;
        missedShips = 0;
        lifes = 3;
        points = 0;

        onTimerChange(timer);   
        onFixedShipsChange(fixedShips);
        onMissedShipsChange(missedShips);
        onLifesChange(lifes);
        onPointsChange(points);
    }

    public void SetTimer(int value)
    {
        timer = value;
        onTimerChange(timer);
    }

    public void CountTimer(int value)
    {
        if(timer > value)
        {
            timer = value;
            onTimerChange(timer);
        }

    }

    public void IncrementFixedShips()
    {
        fixedShips += 1;
        onFixedShipsChange(fixedShips);
    }

    public void IncrementMissedShips()
    {
        missedShips += 1;
        onMissedShipsChange(missedShips);
    }

    public void DecreaseLife()
    {
        lifes--;
        onLifesChange(lifes);
        if(lifes <= 0)
        {
            //onLifeDepleted();
            onGameLost.TriggerEvent();
            Debug.Log("Lost The Game");
        }
    }

    public void AddPoints(int partsFixed)
    {
        points += partsFixed * timer;
        onPointsChange(points);
    }
}
