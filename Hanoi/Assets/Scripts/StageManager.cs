using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;

    public Text[] texts;
    public List<GameObject> stages;
    public List<GameObject> stages2;
    public List<GameObject> stages3;
    private GameObject stage;
    public GameObject canvas;
    public List<GameObject> passedStages;
    private int index = 0;

    // Start is called before the first frame update
    public void Start()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
            passedStages = new List<GameObject>();
        }

        if (stage != null) Destroy(stage);
        
        if (index != 0 && index % 3 == 0)
        {
            stages.Clear();
        }

        if (stages.Count <= 0)
        {
            if (stages2.Count > 0)
            {
                for (int i = 0; i < stages2.Count; i++)
                {
                    stages.Add(stages2[i]);
                }
                stages2.Clear();
            }
            else if (stages3.Count > 0)
            {
                for (int i = 0; i < stages3.Count; i++)
                {
                    stages.Add(stages3[i]);
                }
                stages3.Clear();
            }
            else
            {
                ShowResult();
                return;
            }
        }
        var tempStage = stages[Random.Range(0, stages.Count)];
        stage = Instantiate(stages[Random.Range(0, stages.Count)]);
        stages.Remove(tempStage);
    }

    private void ShowResult()
    {
        canvas.SetActive(true);
        int x = 0;
        int y = 0;
        foreach (var stage in passedStages)
        {
            stage.transform.localScale *= .3f;
            stage.transform.position = new Vector3(x++ * 8 + -10, -y * 3.5f + 5, 0);
            if (x % 3 == 0)
            {
                x = 0;
                y++;
            }
        }
    }

    public void SetMessage(string msg)
    {
        texts[index++].text = msg;
    }
}
