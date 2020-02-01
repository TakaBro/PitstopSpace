using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField] ItemData itemData;

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
}
