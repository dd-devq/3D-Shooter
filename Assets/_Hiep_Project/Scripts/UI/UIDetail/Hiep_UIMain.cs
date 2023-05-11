using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Hiep_UIMain : BaseUI
{
    [Header("------------------------Text------------------------")]
    public Text txtCoin;
    public Text txtStamina;
    public Text txtGem;

    public Transform transBtnStart;
    public Image imgFade;

    public override void OnSetUp(UIParam param = null)
    {
        base.OnSetUp(param);
        imgFade.DOFade(0, 1).OnComplete(() =>
        {
            imgFade.raycastTarget = false;

            PlayerPrefs.SetInt("coin", 100);
            int coin = int.Parse(txtCoin.text);
            DOTween.To(() => coin, x => coin = x, PlayerPrefs.GetInt("coin", 0), 1).OnUpdate(() =>
            {
                txtCoin.text = coin.ToString();
            });

            PlayerPrefs.SetInt("gem", 100);
            int gem = int.Parse(txtGem.text);
            DOTween.To(() => gem, x => gem = x, PlayerPrefs.GetInt("gem", 0), 1).OnUpdate(() =>
            {
                txtGem.text = gem.ToString();
            });

            PlayerPrefs.SetInt("stamina", 100);
            string[] strValues = txtStamina.text.Split('/');
            // 0/120 
            int stamina = int.Parse(strValues[0]);
            int maxStamina = int.Parse(strValues[1]);
            DOTween.To(() => stamina, x => stamina = x, PlayerPrefs.GetInt("stamina", 0), 1).OnUpdate(() =>
            {
                txtStamina.text = stamina.ToString() + "/" + maxStamina;
            });

            transBtnStart.DOScale(1f, 1f).SetLoops(-1, LoopType.Yoyo);
        });        
    }

    public void OnAddGemClick()
    {
        // Show Pop up Add Gem
    }

    public void OnAddCoinClick()
    {
        // Show Pop up Add Coin
    }

    public void OnAddStaminaClick()
    {
        // Show Pop up Add Stamina
    }

    public void OnSettingClick()
    {
        // Show UI Setting
    }

    public void OnShopClick()
    {
        // Show Ui Shop
    }

    public void OnRankClick()
    {
        // Show UI Rank
    }

    public void OnAchievementClick()
    {

    }

    public void OnPlayClick()
    {
        //Hiep_GoogleMobileAdsDemoScript.Instance.ShowInterAds();
        //Hiep_GoogleMobileAdsDemoScript.Instance.RequestInterstitial();
        //AdManager.Instance.OnInterstitialClosed += Instance_OnInterstitialClosed;
        //AdManager.Instance.DisplayInterstitialAd();
        Hiep_FirebaseAnalyticManager.Instance.LogEvent("PlayClick");
        Hiep_AdManager.Instance.DisplayRewardAd();
        Hiep_AdManager.Instance.OnRewarded += Instance_OnRewarded;
       
        
    }

    private void Instance_OnRewarded()
    {
        Hiep_AdManager.Instance.OnRewarded -= Instance_OnRewarded;
        Debug.Log("On Play click");
        imgFade.raycastTarget = true;
        imgFade.DOFade(1, 1).OnComplete(() =>
        {
            UIManager.Instance.ShowUI(UIIndex.UISelectLevel);
            UIManager.Instance.HideUI(this);
        });
    }

    private void Instance_OnInterstitialClosed()
    {
        Hiep_AdManager.Instance.OnInterstitialClosed -= Instance_OnInterstitialClosed;
        Debug.Log("On Play click");
        imgFade.raycastTarget = true;
        imgFade.DOFade(1, 1).OnComplete(() =>
        {
            UIManager.Instance.ShowUI(UIIndex.UISelectLevel);
            UIManager.Instance.HideUI(this);
        });
    }
}
