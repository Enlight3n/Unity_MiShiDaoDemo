using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : SingletonMonobehaviour<GameController>
{
    public UnityEvent OnFinish;
    
    [Header("游戏数据")]
    public GameH2A_SO gameData;

    public Transform[] holderTransform;

    public Ball ballPrefab;

    public LineRenderer linePrefab;

    public GameObject lineParaent;

    private void Start()
    {
        DrowLine();
        CreatBall();
        
    }

    public void ResetGame()
    {
        for (int i = 0; i < lineParaent.transform.childCount; i++)
        {
            Destroy(lineParaent.transform.GetChild(i).gameObject);
        }

        foreach (var holder in holderTransform)
        {
            if(holder.childCount>0)
                Destroy(holder.GetChild(0).gameObject);
        }

        DrowLine();
        CreatBall();
    }

    //绘制线
    public void DrowLine()
    {
        foreach (var connections in gameData.lineConnections)
        {
            var line = Instantiate(linePrefab, lineParaent.transform);
            line.SetPosition(0,holderTransform[connections.from].position);
            line.SetPosition(1,holderTransform[connections.to].position);

            //创建每个Holder的连接关系
            holderTransform[connections.from].GetComponent<Holder>().LinkHolders.Add(
                holderTransform[connections.to].GetComponent<Holder>());
            
            holderTransform[connections.to].GetComponent<Holder>().LinkHolders.Add(
                holderTransform[connections.from].GetComponent<Holder>());
        }
    }

    public void CreatBall()
    {
        for (int i = 0; i<gameData.startBallOrders.Count;i++)
        {
            if (gameData.startBallOrders[i] == BallNameEnum.None)
            {
                holderTransform[i].GetComponent<Holder>().isEmpty = true;
                continue;
            }

            Ball ball = Instantiate(ballPrefab, holderTransform[i]);
            
            
            holderTransform[i].GetComponent<Holder>().CheckBall(ball);
            
            holderTransform[i].GetComponent<Holder>().isEmpty = false;
            
            ball.SetUpBall(gameData.GetBallDetails(gameData.startBallOrders[i]));
        }
    }

    public void CheckIsFinished()
    {
        foreach (var ball in FindObjectsOfType<Ball>())
        {
            if(!ball.isMatch)
                return;
        }

        //禁用游戏的互动
        foreach (var holder in holderTransform)
        {
            holder.GetComponent<Collider2D>().enabled = false;
        }

        Settings.isMiniGameFinished = true;
        
        OnFinish?.Invoke(); //这个事件是传送事件，将玩家传送回场景H2
        
        
    }
}
