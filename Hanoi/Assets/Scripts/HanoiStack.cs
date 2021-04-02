using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HanoiStack : MonoBehaviour
{
    public int length;
    public List<Ball> stack = new List<Ball>();

    public bool Push(Ball ball)
    {
        if (stack.Count < length)
        {
            stack.Add(ball);

            var pos = transform.position;
            pos.y += stack.Count;
            ball.transform.position = pos;

            return true;
        }

        return false;
    }

    public Ball Pop()
    {
        if (stack.Count > 0)
        {
            var res = stack[stack.Count - 1];
            stack.Remove(res);
            return res;
        }

        return null;
    }

    public override bool Equals(object other)
    {
        if (!(other is HanoiStack stack)) return false;

        if (this.stack.Count != stack.stack.Count) return false;
        
        bool isEqual = true;
        for (int i = 0; i < this.stack.Count; i++)
        {
            isEqual &= this.stack[i].Equals(stack.stack[i]);
        }

        return isEqual;
    }
    
    public void OnMouseDown()
    {
        if (GameManager.Instance.nowCatching)
        {
            GameManager.Instance.PushBall(this);
        }
        
        else if (!GameManager.Instance.nowCatching)
        {
            GameManager.Instance.CatchBall(Pop());
        }
    }
    
}
