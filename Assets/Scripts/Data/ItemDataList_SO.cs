using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fileName是创建的数据容器的默认名称，menuName是创建时点击的目录
[CreateAssetMenu(fileName = "ItemDataList_SO", menuName = "Inventory/ItemDataList_SO")]
public class ItemDataList_SO : ScriptableObject
{
   
   public List<ItemDetails> itemDetailsList;
   
   //这个函数用来给定名字，返回对应的ItemDetails
   public ItemDetails GetItemDetails(ItemNameEnum itemNameEnum)
   {
      return itemDetailsList.Find(i => i.itemName == itemNameEnum);
   }
   
}

[System.Serializable]
public class ItemDetails
{
   public ItemNameEnum itemName;
   public Sprite itemSprite;
}
