using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "GameH2A_SO", menuName = "Inventory/GameH2A_SO")]
public class GameH2A_SO :ScriptableObject
{

    [Header("球的名字和对应的图片")] public List<BallDetails> ballDetailsList;

    [Header("游戏逻辑数据")] public List<Connections> lineConnections;

    public List<BallNameEnum> startBallOrders;

    public BallDetails GetBallDetails(BallNameEnum ballNameEnum)
    {
        return ballDetailsList.Find(b => b.ballName == ballNameEnum);
    }
}

[System.Serializable]
public class BallDetails
{
    public BallNameEnum ballName;
    public Sprite wrongSprite;
    public Sprite rightSprite;
}

[System.Serializable]
public class Connections
{
    public int from;

    public int to;
}