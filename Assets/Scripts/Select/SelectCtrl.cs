using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCtrl : MonoBehaviour
{
    [SerializeField]
    private GameObject selectLevelPrefab;
    [SerializeField]
    private Button preButton;
    [SerializeField]
    private Button nextButton;

    private void Awake()
    {
        Debug.Log(LevelJsonManager.Instance.Read());
    }

}
