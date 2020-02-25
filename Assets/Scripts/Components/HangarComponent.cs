﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class HangarComponent : MonoBehaviour
{
    [SerializeField] List<HangarSlotComponent> slots;
    [SerializeField] SpaceshipComponent spaceship;
    [SerializeField] SpaceshipManager spaceshipManager;
    [SerializeField] ItemsManager itemsManager;
    [SerializeField] GameData gameData;
    [SerializeField] ProgressionData ProgressionData;
    float originalTimer;
    bool timerRunning;

    [SerializeField] UnityEvent onShipDocked;
    [SerializeField] UnityEvent onShipRepaired;
    [SerializeField] UnityEvent onShipReleased;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        gameData.Reset();
        DockShip(spaceshipManager.GetRandomSpaceship());
    }

    private void Update()
    {
        CountTimer();
        if (originalTimer < 0 && timerRunning)
        {
            timerRunning = false;
            Debug.Log("Time Limit Reached");
            StartCoroutine(ReleaseShip());
        }
    }

    void CountTimer()
    {
        if(timerRunning)
        {
            originalTimer -= Time.deltaTime;
            gameData.CountTimer((int)originalTimer + 1);
        }

    }

    public void StopTimer()
    {
        timerRunning = false;
    }

    void ResetTimer()
    {
        originalTimer = spaceshipManager.repairInitialTimer;
        gameData.SetTimer((int)originalTimer + 1);
        timerRunning = true;
    }

    public void DockShip(SpaceshipData shipData)
    {
        Debug.Log($"Preparing to dock {shipData.name}");
        spaceship.ResetShip(shipData);

        SetupShipDefects(shipData);

        foreach (HangarSlotComponent slotComponent in slots)
        {
            if (shipData.slots.Contains(slotComponent.hangarCode))
                slotComponent.status = SlotStatus.REGULAR;
            else
                slotComponent.status = SlotStatus.NOT_PRESENT;

            if (spaceship.problems.Exists(p => p.slot == slotComponent.hangarCode))
            {
                slotComponent.status = SlotStatus.DEFECTIVE;
                slotComponent.materialNeeded = spaceship.problems.Find(p => p.slot == slotComponent.hangarCode).item;
                //slotComponent.itemSprite.sprite = slotComponent.materialNeeded.sprite;
            }
            else
            {
                slotComponent.materialNeeded = null;
                //slotComponent.itemSprite.sprite = null;
            }
                
        }

        ResetTimer();
        onShipDocked.Invoke();
    }

    public void SetupShipDefects (SpaceshipData shipData)
    {
        ProgressionLevel level = ProgressionData.GetCurrentLevel(gameData.Points);
        Debug.Log($"Current Level : {level.id}");
        int clampedMaxDefects = Mathf.Clamp(level.maxDefects, level.minDefects, shipData.slots.Count);
        int totalDefects = Random.Range(level.minDefects, clampedMaxDefects);

        List<SlotCode> defects = new List<SlotCode>();

        while (defects.Count < totalDefects)
        {
            SlotCode slot = shipData.slots[Random.Range(0, shipData.slots.Count)];
            if (defects.Contains(slot))
                continue;
            defects.Add(slot);
        }

        foreach (SlotCode slot in defects)
        {
                spaceship.CreateDefects(slot, itemsManager.GetRandomItem());
        }
    }

    public void OnSlotStatChanged()
    {
        StartCoroutine(CheckShip());
    }

    public void CountFixes()
    {
        int totalFixes = 0;
        foreach (var slot in slots)
        {
            if (slot.status == SlotStatus.FIXED)
                totalFixes++;
        }
        gameData.AddPoints(totalFixes);
    }

    public IEnumerator CheckShip()
    {
        if (!slots.Exists(s => s.status == SlotStatus.DEFECTIVE))
        {
            CountFixes();
            onShipRepaired.Invoke();
            StopTimer();
            Debug.Log($"Ship repaired. New ship arriving in 2");
            yield return new WaitForSecondsRealtime(2);
            Debug.Log($"New ship arriving...");
            spaceship.gameObject.SetActive(false);
            DockShip(spaceshipManager.GetRandomSpaceship());
        }
        
    }

    public IEnumerator ReleaseShip()
    {
        onShipReleased.Invoke();
        StopTimer();
        Debug.Log($"Repair time ended. New ship arriving in 2");
        yield return new WaitForSecondsRealtime(2);
        Debug.Log($"New ship arriving...");
        spaceship.gameObject.SetActive(false);
        DockShip(spaceshipManager.GetRandomSpaceship());
    }

}
