using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class Hiep_UIGameOver : BaseUI
{
    public void OnReplayClick()
    {
        // Setup gameplay
        UIManager.Instance.HideUI(this);
    }

    public void OnMainClick()       
    {
        UIManager.Instance.HideAllUI();
        LoadSceneManager.Instance.OnLoadScene("Hiep_Main", (obj) =>
        {
            Debug.Log(obj.ToString());
            UIManager.Instance.ShowUI(UIIndex.UIMain);
        });
    }

    public void OnShopClick()
    {

    }
}
