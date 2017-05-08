using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityToolbag;

public class SelectCtrl : MonoBehaviour
{
    [Reorderable]
    [SerializeField]
    private List<LevelButton> levelButtonList;
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Text pageTitle;
    [SerializeField]
    private Button preButton;
    [SerializeField]
    private Button nextButton;

    private int nowIndex;
    private const int maxPageCount = 6;
    private int maxPage;


    List<LevelInfo> levelList;
    int canPlayLevel;


    private void Awake()
    {
        InitList();

        maxPage = levelList.Count / maxPageCount;
        RefreshList(0);

        backButton.onClick.AddListener(Back);
        preButton.onClick.AddListener(() => { RefreshList(-1); });
        nextButton.onClick.AddListener(() => { RefreshList(+1); });
    }

    private void InitList()
    {
        levelList = LevelJsonManager.Instance.ToList();
        for (int i = 0; i < levelList.Count; i++)
        {
            if (levelList[i].star == 0)
            {
                canPlayLevel = i;
                break;
            }
        }
    }

    void Back()
    {
        LoadScene.Load(ScenesName.mainScene);
    }


    private void RefreshList(int value)
    {
        int newInt = nowIndex + value;
        if (newInt >= 0 && newInt <= maxPage)
        {

            if (newInt == 0)
            {
                preButton.gameObject.SetActive(false);
            }
            else
            {
                preButton.gameObject.SetActive(true);

            }
            if (newInt == maxPage)
            {
                nextButton.gameObject.SetActive(false);
            }
            else
            {

                nextButton.gameObject.SetActive(true);
            }
            nowIndex = newInt;
            pageTitle.text = string.Format("Page:{0}", nowIndex + 1);
            int startPos = nowIndex * maxPageCount;
            int nowPos;
            for (int i = 0; i < maxPageCount; i++)
            {
                nowPos = startPos + i;
                if (nowPos < levelList.Count)
                {
                    levelButtonList[i].Init(levelList[nowPos], canPlayLevel < nowPos);
                }
                else
                {
                    levelButtonList[i].Init(null, true);
                }
            }
        }

    }
}
