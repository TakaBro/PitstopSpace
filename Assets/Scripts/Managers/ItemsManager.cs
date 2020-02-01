using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Containers/Item Manager")]
public class ItemsManager : ScriptableObject
{
    [SerializeField] List<ItemData> itemCollection;

    public ItemData GetRandomItem()
    {
        int rand = Random.Range(0, itemCollection.Count);
        return itemCollection[rand];
    }
}
