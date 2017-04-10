using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartCtrl : MonoBehaviour
{
    private Button btn_start;
    private Button btn_option;

    private void Awake()
    {
        btn_start = GameObject.Find(StartPath.startBtnPath).GetComponent<Button>();
        btn_option = GameObject.Find(StartPath.optionBtnPath).GetComponent<Button>();

        btn_start.onClick.AddListener(ClickStartGame);
        btn_option.onClick.AddListener(ClickOption);
    }


    void ClickStartGame()
    {

    }

    void ClickOption()
    {
        SceneManager.LoadScene(ScenesName.optionScene);
    }
}
