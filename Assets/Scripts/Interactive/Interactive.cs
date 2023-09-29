using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 可互动物品基类，其他如NPC，信箱都继承自该类
/// </summary>
public class Interactive : MonoBehaviour
{
    public ItemNameEnum requireItem;

    //用来标志是否使用过该物品
    public bool isDone;

    public void CheckItem(ItemNameEnum itemName)
    {
        if (itemName == requireItem && !isDone)
        {
            isDone = true;
            
            //使用这个物品，移除
            OnClickedAction();
            
            EventHandler.CallItemUsedEvent(itemName);
        }
        
    }

    protected virtual void OnClickedAction()
    {
        
    }

    public virtual void EmptyClicked()
    {
        Debug.Log("空点");
    }
}
