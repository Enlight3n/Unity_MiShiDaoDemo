using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using Unity.VisualScripting;
using UnityEngine;

public class ClickManager : SingletonMonobehaviour<ClickManager>
{
    //获取鼠标位置
    private Vector3 MousueWorldPos =>
        Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));

    
    private ItemNameEnum _currentItemName;

    public RectTransform hand;
    private bool _isHoldItem;
    
    //获取鼠标点击的物体的Collider2D组件
    private Collider2D ObjectAtMousePosition()
    {
        return Physics2D.OverlapPoint(MousueWorldPos);
    }

    
    private void OnEnable()
    {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    //我们已经将数据传输到OnItemSelectedEvent方法中，但是我们想在update中使用，所以在这个方法中，我们将数据保存起来
    private void OnItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
    {
        _isHoldItem = isSelected;
        if (isSelected)
        {
            _currentItemName = itemDetails.itemName;
            
        }
        hand.gameObject.SetActive(_isHoldItem);
    }

    private void OnItemUsedEvent(ItemNameEnum itemName)
    {
        _currentItemName = itemName;
        _isHoldItem = false;
        hand.gameObject.SetActive(false);
    }
    
    private void Update()
    {
        //实现选中物品栏中物品时的跟随效果
        if (hand.gameObject.activeInHierarchy)
        {
            hand.position = Input.mousePosition;
        }
        
        
        var collider = ObjectAtMousePosition();
        if ((bool)collider && Input.GetMouseButtonDown(0))
        {
            switch (collider.tag)
            {
                case "Teleport":
                    var teleport = collider.gameObject.GetComponent<Teleport>();
                    teleport.Transition();
                    break;
                case "Item":
                    var item = collider.gameObject.GetComponent<Item>();
                    item.ItemPickUp();
                    break;
                case "Interactive":
                    var interactive = collider.gameObject.GetComponent<Interactive>();
                    
                    //鼠标判断是否选择了物体，选择了物体再互动的话效果是不一样的
                    if (_isHoldItem)
                    {
                        interactive.CheckItem(_currentItemName);
                    }
                    else
                    {
                        interactive.EmptyClicked();
                    }
                    break;
            }
            
        }
    }

    
}