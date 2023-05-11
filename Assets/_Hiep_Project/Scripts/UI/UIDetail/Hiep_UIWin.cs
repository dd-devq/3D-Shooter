using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using UnityEngine.UI;
using DG.Tweening;

public class Hiep_UIWin : BaseUI
{
    public Text txtScore;
    public Text txtTime;
    private WinParam winParam;

    [SerializeField]
    private List<Image> lsImgStars = new List<Image>();
    [SerializeField]
    private Sprite spriteStarOn;
    [SerializeField]
    private Sprite spriteStarOff;

    [SerializeField]
    private GameObject goEffect;

    public override void OnSetUp(UIParam param = null)
    {
        winParam = (WinParam)param;
        Firebase.Analytics.Parameter[] winFirebaseParam =
        {
            new Firebase.Analytics.Parameter("star", winParam.numberStar),
            new Firebase.Analytics.Parameter("score", winParam.score),
            new Firebase.Analytics.Parameter("timeCount", winParam.timeCount),
        };
        Hiep_FirebaseAnalyticManager.Instance.LogEvent("GameWin", winFirebaseParam);

        txtScore.text = "000";
        txtTime.text = "00:00";
        for(int i = 0; i < lsImgStars.Count; i++)
        {
            lsImgStars[i].sprite = spriteStarOff;
        }
        goEffect.SetActive(false);
        base.OnSetUp(param);
    }

    public void PlayAnimationEnable()
    {
        int score = 0;
        DOTween.To(() => score, x => score = x, winParam.score, 1).OnUpdate(() =>
        {
            txtScore.text = score.ToString();
        });

        StartCoroutine(CountdownTime(1f, winParam.timeCount));
    }


    IEnumerator CountdownTime(float timer, int timeCount)
    {
        float deltaTime = timer / timeCount;
        int minute = timeCount / 60;
        int second = timeCount % 60;

        for(int i = 0; i <= minute; i++)
        {
            if (i == minute)
            {
                for(int j = 0; j <= second; j++)
                {
                    txtTime.text = i.ToString("D2") + " : " + j.ToString("D2");
                    yield return new WaitForSeconds(deltaTime);
                }
            }
            else
            {
                for(int j = 0; j < 59; j++)
                {
                    txtTime.text = i.ToString("D2") + " : " + j.ToString("D2");
                    yield return new WaitForSeconds(deltaTime);
                }                
            }
        }

        for(int i = 0; i < winParam.numberStar; i++)
        {
            lsImgStars[i].sprite = spriteStarOn;
            yield return new WaitForSeconds(0.3f);
        }

        goEffect.SetActive(true);
    }

    public void OnPlayClick()
    {
        UIManager.Instance.HideAllUI();
        LoadSceneManager.Instance.OnLoadScene("Hiep_Main", (obj) =>
        {
            Debug.Log(obj.ToString());
            UIManager.Instance.ShowUI(UIIndex.UIMain);
        });
    }

    public void OnSettingClick()
    {

    }

    public void OnRankClick()
    {

    }

    public void OnShopClick()
    {

    }

    public void OnAchievementClick()
    {

    }
}
