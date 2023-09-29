using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    public BallDetails ballDetails;

    public bool isMatch;
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetUpBall(BallDetails ball)
    {
        ballDetails = ball;

        if (isMatch)
        {
            SetRight();
        }
        else
        {
            SetWrong();
        }
    }

    public void SetWrong()
    {
        _spriteRenderer.sprite = ballDetails.wrongSprite;
    }

    public void SetRight()
    {
        _spriteRenderer.sprite = ballDetails.rightSprite;
    }
}
