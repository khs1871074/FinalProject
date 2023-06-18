using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveSaveData : MonoBehaviour
{
    public void DoRemoveSaveData()
    {
        SaveData saveData = GameObject.Find("SaveData").GetComponent<SaveData>();
        Destroy(saveData.gameObject);
    }
}
