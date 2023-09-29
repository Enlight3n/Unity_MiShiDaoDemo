using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用ItemManager来管理持有的物品
/// </summary>
public class ItemManager : SingletonMonobehaviour<ItemManager>
{
    public ItemDataList_SO itemData;

    public ItemDetails itemDetails;
    
    //用itemNameList来当作物品栏，存的是物品的名字
    public List<ItemNameEnum> itemNameList = new List<ItemNameEnum>();
    
    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    private void OnItemUsedEvent(ItemNameEnum itemName)
    {
        var index = GetItemIndex(itemName);
        
        itemNameList.RemoveAt(index);

        if (itemNameList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null,-1);
        }
    }
    
    
    // ItemAdd函数用来将对应名称的物体添加到物品栏中
    public void ItemAdd(ItemNameEnum itemName)
    {
        if (!itemNameList.Contains(itemName))
        {
            //物品栏添加新的物品
            itemNameList.Add(itemName);

            itemDetails = itemData.GetItemDetails(itemName);
            
            
            //调用事件来更新UI，传入根据itemName找到的itemDetails，以及次序号（用来标明第几个）
            EventHandler.CallUpdateUIEvent(itemData.GetItemDetails(itemName),itemNameList.Count - 1);
        }
    }

    private int GetItemIndex(ItemNameEnum itemName)
    {
        for (int i = 0; i < itemNameList.Count; i++)
        {
            if (itemNameList[i] == itemName)
            {
                return i;
            }
        }

        return -1;
    }
}
