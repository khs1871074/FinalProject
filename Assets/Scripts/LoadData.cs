using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    private SaveData saveData;
    private bool[] stageClearList;
    
    public Button[] stageButton;
    // Start is called before the first frame update
    void Start()
    {
        saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        stageClearList = saveData.GetClearList();
        SetClearStage();
    }

    private void SetClearStage()
    {
        for (int i = 0; i < stageClearList.Length; i++)
        {
            if (stageClearList[i])
            {
                stageButton[i].interactable = false;
            }
        }
    }
}
