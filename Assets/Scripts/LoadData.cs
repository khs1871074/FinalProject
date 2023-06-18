using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadData : MonoBehaviour
{
    private SaveData saveData;
    private bool[] stageClearList;
    private int clearCount = 0;
    
    public Button[] stageButton;
    public GameObject allClear;
    public GameObject allClearParticle;
    public Transform allClearParticlePos;
    // Start is called before the first frame update
    void Start()
    {
        allClear.SetActive(false);
        saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        stageClearList = saveData.GetClearList();
        SetClearStage();
        if (clearCount == stageClearList.Length)
        {
            Instantiate(allClearParticle, allClearParticlePos.position, allClearParticlePos.rotation);
            allClear.SetActive(true);
        }
    }

    private void SetClearStage()
    {
        for (int i = 0; i < stageClearList.Length; i++)
        {
            if (stageClearList[i])
            {
                clearCount++;
                stageButton[i].interactable = false;
            }
        }
    }
}
