using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{

    [SerializeField]
    private Text levelName;
    [SerializeField]
    private Image mask;

    public void Init(LevelInfo info, bool showMask)
    {
        if (info == null)
        {
            HideSelf();
        }
        else
        {
            if (showMask)
            {
                ShowMask();
            }
            else
            {
                levelName.text = info.levelName;
                HideMask();
            }
            if (!gameObject.activeSelf)
            {
                ShowSelf();
            }
        }
    }


    public void ShowSelf()
    {
        gameObject.SetActive(true);
    }

    public void HideSelf()
    {
        gameObject.SetActive(false);
    }

    public void HideMask()
    {
        mask.gameObject.SetActive(false);
    }

    public void ShowMask()
    {
        mask.gameObject.SetActive(true);
    }
}
