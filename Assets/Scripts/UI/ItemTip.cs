using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemTip : MonoBehaviour
{
   public Text itemNameText;

   public void UpdateItemName(ItemNameEnum itemName)
   {
      switch (itemName)
      {
         case ItemNameEnum.Key:
            itemNameText.text = "信箱钥匙";
            break;
         case ItemNameEnum.Mail:
            itemNameText.text = "一张船票";
            break;
      }
   }
}
