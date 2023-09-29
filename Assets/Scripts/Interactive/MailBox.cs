using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBox : Interactive
{
   //用来改变信箱的图片
   private SpriteRenderer _spriteRenderer;
   
   //用来取消信箱的碰撞体，避免点击了信箱之后再次点击
   private BoxCollider2D _boxCollider2D;

   //信箱打开的图片
   public Sprite sprite;
   private void Awake()
   {
      _spriteRenderer = GetComponent<SpriteRenderer>();
      _boxCollider2D = GetComponent<BoxCollider2D>();
   }


   private void OnEnable()
   {
      EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
   }

   private void OnDisable() 
   {
      EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
   }

   private void OnAfterSceneLoadedEvent()
   {
      //判断是否互动结束，如果结束，隐藏船票
      if (!isDone)
      {
         transform.GetChild(0).gameObject.SetActive(false);
      }
      else
      {
         _spriteRenderer.sprite = sprite;
         _boxCollider2D.enabled = false;
      }
   }
   

   protected override void OnClickedAction()
   {
      //改变图片
      _spriteRenderer.sprite = sprite;

      
      transform.GetChild(0).gameObject.SetActive(true);
   }
}
