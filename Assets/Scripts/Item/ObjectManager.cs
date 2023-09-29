using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 这个脚本用来保存场景中物品的拾取信息
/// </summary>

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemNameEnum, bool> itemAvaiableDict = new Dictionary<ItemNameEnum, bool>();
    
    //string是名字，如信箱，Npc，bool值是isDone
    private Dictionary<string, bool> interactiveStateDic = new Dictionary<string, bool>();
    
    
    private void OnEnable()
    {
        EventHandler.BeforeSceneUnLoadEvent += OnBeforeSceneUnLoadEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnLoadEvent -= OnBeforeSceneUnLoadEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    
    //用这个来处理拾取物品以后把物品的SetActive设置为false
    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        if (itemDetails != null)
        {
            itemAvaiableDict[itemDetails.itemName] = false;
        }
    }
    
    
    //这个是卸载之前的处理：保存物体的状态
    private void OnBeforeSceneUnLoadEvent()
    {
        foreach (var item in FindObjectsOfType<Item>())
        {
            //GameObject不在字典中，就把它加进字典。
            //这个是为了处理信箱互动后的船票，打开信箱以后生成的船票，不管拿没拿，其状态都应该保存
            //卸载之前，如果有船票，就把它加到字典里
            if (!itemAvaiableDict.ContainsKey(item.itemName))
            {
                itemAvaiableDict.Add(item.itemName,true);
            }
        }

        
        //这个是为了处理信箱的状态，即打开信箱以后，应当保存其状态，我们重进场景时，也应当是这个状态
        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDic.ContainsKey(item.name))
            {
                //是否互动完成，保存到字典中
                interactiveStateDic[item.name] = item.isDone;
            }
            else
            {
                interactiveStateDic.Add(item.name, item.isDone);
            }
        }
        
    }

    
    //这个是加载之后的处理
    private void OnAfterSceneLoadedEvent()
    {
        //遍历场景中所有挂载Item脚本的GameObject
        foreach (Item item in FindObjectsOfType<Item>())
        {
            //GameObject不在字典中，就把它加进字典
            if (!itemAvaiableDict.ContainsKey(item.itemName))
            {
                itemAvaiableDict.Add(item.itemName,true);
            }
            //如果有，则看是否该显示出来，设置其SetActive
            else
            {
                item.gameObject.SetActive(itemAvaiableDict[item.itemName]);
            }
        }

        foreach (var item in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDic.ContainsKey(item.name))
            {
                //从字典中读取数据，看是否互动完成
                item.isDone = interactiveStateDic[item.name];
            }
            else
            {
                interactiveStateDic.Add(item.name,item.isDone);
            }
        }
    }
}
