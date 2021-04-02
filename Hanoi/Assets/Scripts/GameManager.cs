using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool nowCatching;
    public Ball catchingBall;
    
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CatchBall(Ball ball)
    {
        if (ball == null) return;
        
        ball.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(10, 10, 10));
        nowCatching = true;
        catchingBall = ball;
    }

    public void PushBall(HanoiStack stack)
    {
        var res = stack.Push(catchingBall);
        if (res)
        {
            nowCatching = false;
            catchingBall = null;
        }
    }
}
