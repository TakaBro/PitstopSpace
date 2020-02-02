using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class HangarSlotComponent : MonoBehaviour
{
    public Vector2 Position { get => transform.localPosition; set => transform.localPosition = value; }
    public SlotCode hangarCode;
    public SlotStatus status;
    public SpriteRenderer itemSprite;

    public ItemData materialNeeded;
    [SerializeField] UnityEvent onSlotFixed;
    [SerializeField] UnityEvent onSlotMissed;

    public void UpdateItemSprite()
    {
        itemSprite.sprite = materialNeeded?.sprite ?? null;
    }

    public void ClearSlot()
    {
        materialNeeded = null;
        itemSprite.sprite = null;
        itemSprite.color = Color.white;
        status = SlotStatus.NOT_PRESENT;
    }

    public void FixPart(ItemData item)
    {
        if (status == SlotStatus.DEFECTIVE)
        {
            if (item == materialNeeded)
            {
                status = SlotStatus.FIXED;
                onSlotFixed.Invoke();
                itemSprite.color = new Color(0.3f, 0.7f, 0.3f);
            }
            else
            {
                status = SlotStatus.MISSED;
                onSlotMissed.Invoke();
                itemSprite.color = new Color(0.7f, 0.3f, 0.3f);
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