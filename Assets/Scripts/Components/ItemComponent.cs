using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField] ItemData itemData;

    public Vector2 Position { get => transform.localPosition; set => transform.localPosition = value; }
    public bool IsFilled { get => itemData != null; }

    private void Start()
    {
        if (itemData)
        {
            GetComponent<SpriteRenderer>().sprite = itemData.sprite;
        }
    }
    public void SetData(ItemData data)
    {
        itemData = data;
        GetComponent<SpriteRenderer>().sprite = itemData.sprite;
    }


    public ItemData ConsumeItem()
    {
        ItemData data = itemData;
        itemData = null;
        Enable(false);
        return data;
    }

    public void Enable(bool value)
    {
        GetComponent<SpriteRenderer>().enabled = value;
    }

    public void MoveTo(Vector2 target, float delta)
    {
        Position = target;
    }
}
