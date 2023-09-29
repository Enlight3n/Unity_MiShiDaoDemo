using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Interactive
{
    public BallNameEnum matchBall;

    private Ball _currentBall;

    //存储每个holder跟谁连线了
    public HashSet<Holder> LinkHolders = new HashSet<Holder>();

    public bool isEmpty;

    //检查当前是否已经match
    public void CheckBall(Ball ball)
    {
        _currentBall = ball;

        //如果传进来的球是matchBall，设置图片
        if (ball.ballDetails.ballName == matchBall)
        {
            _currentBall.isMatch = true;
            _currentBall.SetRight();
        }
        else
        {
            _currentBall.isMatch = false;
            _currentBall.SetWrong();
        }
    }

    public override void EmptyClicked()
    {
        foreach (var holder in LinkHolders)
        {
            if (holder.isEmpty)
            {
                //移动球
                _currentBall.transform.position = holder.transform.position;
                _currentBall.transform.SetParent(holder.transform);
                
                //交换球
                holder.CheckBall(_currentBall);
                _currentBall = null;
                
                //改变状态
                isEmpty = true;
                holder.isEmpty = false;
                
                GameController.Instance.CheckIsFinished();
            }
        }
        
        
    }
}
