using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    private static SaveData Instance;

    private bool[] stageClear;

    public int stageCount;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance != null) // SaveData 오브젝트가 이미 존재하면
        {
            Destroy(gameObject); // 새로 생긴 SaveData 제거
            return;
        }
        Instance = this;

        DontDestroyOnLoad(transform.gameObject);

        stageClear = new bool[stageCount];

        for (int i = 0; i < stageCount; i++)
        {
            stageClear[i] = false;
        }
    }

    public void StageClear(int stageindex)
    {
        stageClear[stageindex - 1] = true;
    }

    public bool[] GetClearList()
    {
        return stageClear;
    }
}
