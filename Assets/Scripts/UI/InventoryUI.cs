using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
/// <summary>
/// 用来管理物品栏的UI
/// </summary>
public class InventoryUI : MonoBehaviour
{
   //获取左右按钮
   public UnityEngine.UI.Button LeftButton, RightButton;

   //表征当前显示物品的序号，没有就是-1
   public int currentIndex;

   public SlotUI slotUI;

   private void OnEnable()
   {
       EventHandler.UpdateUIEvent += OnUpdateUIEvent;
   }

   private void OnDisable()
   {
       EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
   }

   //这个方法用来根据物品栏的信息来更新界面的显示
   private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
   {
       //如果物品栏信息是空的，那么不显示图片
       if (itemDetails == null)
       {
           slotUI.SetEmpty();
           currentIndex = -1;
           LeftButton.interactable = false;
           RightButton.interactable = false;
       }
       else //物品栏不空，根据传入的新物品的信息，来设置UI显示
       {
           currentIndex = index;
           slotUI.SetItem(itemDetails);
       }
   }
   
   
   /// <summary>
   /// ----------------------处理物品栏切换----------------------
   /// </summary>
   
   //按下左边按钮
   public void PressLeftButton()
   {
       SwitchItem(-1);
   }
   
   //按下右边按钮
   public void PressRightButton()
   {
       SwitchItem(1);
   }
   
   //amount用来表明按下的是左边按钮还是右边按钮
   public void SwitchItem(int amount)
   {
       var length = ItemManager.Instance.itemNameList.Count;
       
       var index = (currentIndex + amount + length) % length;
       
       //获取物品栏，根据名称获取物品详情
       var itemDetails=ItemManager.Instance.itemData.GetItemDetails(ItemManager.Instance.itemNameList[index]);
       
       //根据物品详情和序号更新
       EventHandler.CallUpdateUIEvent(itemDetails,index);

   }
}
