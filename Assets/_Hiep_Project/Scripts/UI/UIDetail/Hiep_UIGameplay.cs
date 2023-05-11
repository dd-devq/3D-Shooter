using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Hiep_UIGameplay : BaseUI
{
    public void OnPauseClick()
    {
        UIManager.Instance.ShowUI(UIIndex.UIPause);
    }

    public void OnWinClick()
    {
        UIManager.Instance.ShowUI(UIIndex.UIWin, new WinParam { score = 100, timeCount = 61, numberStar = 3 });
    }

    public void OnLoseClick()
    {
        UIManager.Instance.ShowUI(UIIndex.UILose);
    }
}
