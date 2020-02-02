using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class HangarSlotComponent : MonoBehaviour
{
    public Vector2 Position { get => transform.localPosition; set => transform.localPosition = value; }
    public SlotCode hangarCode;
    public SlotStatus status;

    public ItemData materialNeeded;
    [SerializeField] UnityEvent onSlotFixed;
    [SerializeField] UnityEvent onSlotMissed;


    public void FixPart(ItemData item)
    {
        if (status == SlotStatus.DEFECTIVE)
        {
            if (item == materialNeeded)
            {
                status = SlotStatus.FIXED;
                onSlotFixed.Invoke();
            }
            else
            {
                status = SlotStatus.MISSED;
                onSlotMissed.Invoke();
            }
        }
        else
        {
            status = SlotStatus.MISSED;
            onSlotMissed.Invoke();
        }
        
    }
}

public enum SlotCode { A, B, C, D, E, F, G, H, I, J, K, L}
public enum SlotStatus { NOT_PRESENT, REGULAR, DEFECTIVE, FIXED, MISSED }