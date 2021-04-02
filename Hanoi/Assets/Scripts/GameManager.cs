using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool nowCatching;
    
    public Ball catchingBall;
    public Hanoi origin;
    public Hanoi playeable;
    public Text text;
    public Text playerText;
    public int canMoveCount;
    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        text.text = "남은 이동 횟수 : " + canMoveCount;
    }

    public void CatchBall(Ball ball)
    {
        if (ball == null) return;
        
        ball.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(10, 10, 10));
        nowCatching = true;
        catchingBall = ball;
        
        text.text = "남은 이동 횟수 : " + --canMoveCount;
    }

    public void PushBall(HanoiStack stack)
    {
        var res = stack.Push(catchingBall);
        if (res)
        {
            nowCatching = false;
            catchingBall = null;

            if (canMoveCount <= 0)
            {
                Check();
            }
        }
    }

    public void Check()
    {
        if (origin.Equals(playeable))
        {
            text.text = "Success";
        }
        else
        {
            text.text = "Fail";
        }

        StageManager.Instance.SetMessage(text.text);
        text.text += "\n3초 후 다음 스테이지로 넘어갑니다.";
        StageManager.Instance.passedStages.Add(Instantiate(playeable.transform.parent.gameObject, new Vector3(100, 100, 100),
            Quaternion.identity));
        StartCoroutine(LoadNext());
    }

    private IEnumerator LoadNext()
    {
        yield return new WaitForSeconds(3f);
        StageManager.Instance.Start();
    }
}
