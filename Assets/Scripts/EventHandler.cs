using System;
using UnityEngine;

public  static class EventHandler
{
   
   
   
   public static event Action<ItemDetails, int> UpdateUIEvent;
   //把需要读这个数据的代码都订阅到这个事件里来
   public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
   {
      UpdateUIEvent?.Invoke(itemDetails,index);
   }

   

   public static event Action BeforeSceneUnLoadEvent;
   public static void CallBeforeSceneUnLoadEvent()
   {
      BeforeSceneUnLoadEvent?.Invoke();
   }


   
   public static event Action AfterSceneLoadedEvent;
   public static void CallAfterSceneLoadedEvent()
   {
      AfterSceneLoadedEvent?.Invoke();
   }

   
   
   
   public static event Action<ItemDetails, bool> ItemSelectedEvent;
   public static void CallItemSelectedEvent(ItemDetails itemDetails, bool isSelected)
   {
      ItemSelectedEvent?.Invoke(itemDetails,isSelected);
   }

   
   
   public static event Action<ItemNameEnum> ItemUsedEvent;
   public static void CallItemUsedEvent(ItemNameEnum itemName)
   {
      ItemUsedEvent?.Invoke(itemName);
   }
   
   
   
   public static event Action<string> ShowDialogueEvent;
   public static void CallShowDialogueEvent(string dialogue)
   {
      ShowDialogueEvent?.Invoke(dialogue);
   }

   public static event Action<GameStateEnum> GameStateChangeEvent;

   public static void CallGameStaeChangeEvent(GameStateEnum gameState)
   {
      GameStateChangeEvent?.Invoke(gameState);
   }
}
