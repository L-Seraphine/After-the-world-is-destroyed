﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioSource beginAudio;      //背景音频
    public AudioSource startAudio;
    public Image beakground;      //背景图片
    public Text text;       //向导文本
    public Text titleText;      //标题文本
    public Text titleText1;      //标题文本
    public Text author;     //原作者以及制作者名单
    public string sceneName;        //设置切换场景名称
    public Text loadingText;    //加载进度 UI
    float TargetVaule;      //异步加载反馈进度数据
    void Start()
    {
        beginAudio.Play();      //开始播放背景音乐
        BackgroundMon();     //初始化动画
        TextMon();
    }
    void BackgroundMon()
    {
        //建立队列
        Sequence quence = DOTween.Sequence();
        //添加第一个动画
        quence.Append(beakground.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 5));
        //延迟动画
        quence.AppendInterval(0.4f);
        //添加第二个动画
        quence.Append(beakground.transform.DOScale(new Vector3(1f, 1f, 1f), 5));
        //延迟2秒
        quence.AppendInterval(0.4f);
        //设置循环-1无限
        quence.SetLoops(-1);
    }
    void TextMon()
    {
        //建立队列
        Sequence quence = DOTween.Sequence();
        //添加第一个动画
        quence.Append(text.DOFade(0.1f, 1));
        //添加第二个动画
        quence.Append(text.DOFade(1f, 1));
        //设置循环-1无限
        quence.SetLoops(-1);
    }
    //开始游戏
    public void StartGames()
    {
        DOTween.PauseAll();
        beginAudio.Pause();
        startAudio.Play();
        text.DOFade(0,4);
        titleText.DOFade(0, 4);
        titleText1.DOFade(0, 4);
        author.DOFade(0, 4);
        beakground.transform.DOMoveY(7.2f, 5);
        Invoke("LoadingScence", 5);
        //StartCoroutine(AsyncLoading());
        Debug.Log("进入下一个场景");
    }
    IEnumerator AsyncLoading()
    {
        //异步加载场景
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        //阻止当加载完成自动切换
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
            {
                TargetVaule = async.progress;
            }
            else
            {
                TargetVaule = 1.0f;
            }

            loadingText.text = (int)(TargetVaule * 100) + "%";

            if (TargetVaule >= 0.9)
            {
                async.allowSceneActivation = true;
            }

            yield return null;

        }
    }
    void LoadingScence()
    {
        SceneManager.LoadScene(1);
    }
}
