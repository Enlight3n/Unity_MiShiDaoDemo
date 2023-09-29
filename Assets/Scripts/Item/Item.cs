using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemNameEnum itemName;

    public void ItemPickUp()
    {
        //将物品添加到场景中
        ItemManager.Instance.ItemAdd(itemName);
        //隐藏物体
        gameObject.SetActive(false);
    }
}
