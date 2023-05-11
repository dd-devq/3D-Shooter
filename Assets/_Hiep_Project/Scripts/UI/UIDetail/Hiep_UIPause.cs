using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Hiep_UIPause : BaseUI
{    
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void OnMainClick()
    {
        Time.timeScale = 1;
        UIManager.Instance.HideAllUI();        
        LoadSceneManager.Instance.OnLoadScene("Hiep_Main", (obj) =>
        {
            Debug.Log(obj.ToString());            
            UIManager.Instance.ShowUI(UIIndex.UIMain);
        });
    }

    public void OnContinueClick()
    {
        Time.timeScale = 1;
        // Unpause game
        UIManager.Instance.HideUI(this);
    }

    public void OnRestartClick()
    {
        Time.timeScale = 1;
        // Restart game
        UIManager.Instance.HideUI(this);
    }
}
