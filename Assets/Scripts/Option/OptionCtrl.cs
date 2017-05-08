using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OptionCtrl : MonoBehaviour
{
    private bool isMusicOpen;
    private bool isMusicEffectOpen;


    private Button btn_music_off;
    private Button btn_music_on;

    private Button btn_musicEffect_off;
    private Button btn_musicEffect_on;

    private Button btn_back;

    private void Awake()
    {
        btn_music_off = GameObject.Find(OptionPath.musicOFFBtnPath).GetComponent<Button>();
        btn_music_on = GameObject.Find(OptionPath.musicONBtnPath).GetComponent<Button>();
        btn_musicEffect_off = GameObject.Find(OptionPath.musicEffectOFFBtnPath).GetComponent<Button>();
        btn_musicEffect_on = GameObject.Find(OptionPath.musicEffectONBtnPath).GetComponent<Button>();

        btn_back = GameObject.Find(OptionPath.backBtnPath).GetComponent<Button>();

        btn_music_off.onClick.AddListener(ToggleMusic);
        btn_music_on.onClick.AddListener(ToggleMusic);

        btn_musicEffect_off.onClick.AddListener(ToggleMusicEffect);
        btn_musicEffect_on.onClick.AddListener(ToggleMusicEffect);

        btn_back.onClick.AddListener(Back);

    }


    void ToggleMusic()
    {
        if(isMusicOpen)
        {

        }
        else
        {

        }
        isMusicOpen = !isMusicOpen;
    }

    void ToggleMusicEffect()
    {
        if (isMusicEffectOpen)
        {

        }
        else
        {

        }
        isMusicEffectOpen = !isMusicEffectOpen;
    }

    void Back()
    {
        LoadScene.Load(ScenesName.mainScene);
    }
}
