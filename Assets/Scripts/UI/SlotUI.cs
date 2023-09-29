using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;
public class SlotUI : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    
    public Image itemImage;

    public ItemTip itemTip;

    private ItemDetails currentItem; //存储当前的物品信息

    private bool isSelected; //记录是否被选中

    //这个方法通过传进物品的详细信息，将显示的物品设置为传入的物品
    public void SetItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        
        gameObject.SetActive(true);

        itemImage.sprite = itemDetails.itemSprite;
        
        itemImage.SetNativeSize();
    }

    //重置SlotUI，使其显示为空
    public void SetEmpty()
    {
        gameObject.SetActive(false);
        isSelected = false;
    }


    //使用 IPointerClickHandler 接口来处理使用 OnPointerClick 回调的单击输入
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        
        //声明这个事件是为了传输数据currentItem和isSelected
        EventHandler.CallItemSelectedEvent(currentItem, isSelected);
    }

    //鼠标放上去时显示tip
    public void OnPointerEnter(PointerEventData eventData)
    {
        //判断SlotUI是否显示，SlotUI只有在物品栏有物品时才显示，如果SlotUI显示了，则显示对应的tip
        if (gameObject.activeInHierarchy)
        {
            itemTip.gameObject.SetActive(true);
            itemTip.UpdateItemName(currentItem.itemName);
        }
    }
    
    //鼠标离开时隐藏tip
    public void OnPointerExit(PointerEventData eventData)
    {
        itemTip.gameObject.SetActive(false);
    }
}
