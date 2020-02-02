using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class HangarComponent : MonoBehaviour
{
    [SerializeField] List<HangarSlotComponent> slots;
    [SerializeField] SpaceshipComponent spaceship;
    [SerializeField] SpaceshipManager spaceshipManager;
    [SerializeField] ItemsManager itemsManager;
    float originalTimer;
    bool timerRunning;

    [SerializeField] UnityEvent onShipDocked;
    [SerializeField] UnityEvent onShipRepaired;
    [SerializeField] UnityEvent onShipReleased;

    private void Start()
    {
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
            originalTimer -= Time.deltaTime;
    }

    void ResetTimer()
    {
        originalTimer = spaceshipManager.repairInitialTimer;
        timerRunning = true;
    }

    public void DockShip(SpaceshipData shipData)
    {
        Debug.Log($"Preparing to dock {shipData.name}");
        spaceship.ResetShip(shipData);

        foreach (SlotCode slot in shipData.slots)
        {
            if (Random.Range(1, 11) < 3)
                spaceship.CreateDefects(slot, itemsManager.GetRandomItem());
        }

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
            }
            else
            {
                slotComponent.materialNeeded = null;
            }
                
        }

        ResetTimer();
        onShipDocked.Invoke();
    }

    public void OnSlotStatChanged()
    {
        StartCoroutine(CheckShip());
    }

    public IEnumerator CheckShip()
    {
        if (!slots.Exists(s => s.status == SlotStatus.DEFECTIVE))
        {
            onShipRepaired.Invoke();
            Debug.Log($"Ship repaired. New ship arriving in 5");
            yield return new WaitForSecondsRealtime(2);
            Debug.Log($"New ship arriving...");
            spaceship.gameObject.SetActive(false);
            DockShip(spaceshipManager.GetRandomSpaceship());
        }
        
    }

    public IEnumerator ReleaseShip()
    {
        onShipReleased.Invoke();
        Debug.Log($"Repair time ended. New ship arriving in 5");
        yield return new WaitForSecondsRealtime(2);
        Debug.Log($"New ship arriving...");
        spaceship.gameObject.SetActive(false);
        DockShip(spaceshipManager.GetRandomSpaceship());
    }

}
