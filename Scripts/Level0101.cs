using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Video;

public class Level0101 : MonoBehaviour
{
    public RawImage video;      //获取视频播放组件
    public Image backgroundImg;     //获取背景图片
    public Text txtContent;     //获取对话文本
    public AudioSource backAudio;   //获取音频组件
    public Button yes;      //获取选择按钮1
    public Button no;       //获取选择按钮2
    private void Awake()
    {
        video.GetComponent<VideoPlayer>().loopPointReached += VideoFinished;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleData(TXTLoad.instance.loadNext());
        }
    }

    //监听视频播放结束
    void VideoFinished(VideoPlayer video)
    {
        Debug.Log("视频播放完成");
        video.gameObject.SetActive(false);
        backgroundImg.gameObject.SetActive(true);
        txtContent.gameObject.SetActive(true);
        TXTLoad.instance.loadScripts("test.txt");
        HandleData(TXTLoad.instance.loadNext());
        
    }
    //解析文本并显示
    void HandleData(TextDataModel textDataModel)
    {
        if (textDataModel == null)
        {
            Debug.Log("错误，缺失对话文件");
            return;
        }
        if (backAudio.isPlaying==false)
        {
            backAudio.Play();
        }
        if (textDataModel.time == 999)
        {
            yes.gameObject.SetActive(true);
            no.gameObject.SetActive(true);
            Debug.Log("你需要做出选择");
            return;
        }
        txtContent.text = "";
        txtContent.DOText(textDataModel.textContent, textDataModel.time);
        //var sprite = Resources.Load<Sprite>("Assets/Pic/" + textDataModel.picName + ".png");
        backgroundImg.sprite = (Sprite)Resources.Load(textDataModel.picName, typeof(Sprite));
        Debug.Log("Pic/" + textDataModel.picName + ".png");
    }

}
