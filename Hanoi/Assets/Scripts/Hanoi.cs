using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hanoi : MonoBehaviour
{
    public HanoiStack[] stacks = new HanoiStack[3];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool Equals(object other)
    {
        if (!(other is Hanoi hanoi)) return false;

        bool isEqual = true;
        for (int i = 0; i < 3; i++)
        {
            isEqual &= hanoi.stacks[i].Equals(stacks[i]);
        }

        return isEqual;

    }
}
