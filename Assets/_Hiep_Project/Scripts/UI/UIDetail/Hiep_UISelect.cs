using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using DG.Tweening;
using UnityEngine.UI.Extensions;

public class Hiep_UISelect : BaseUI
{
    public Transform transLevelContent;
    public Transform transContentScrollView;

    public GameObject goPrefabLevelItem;
    public GameObject goPrefabPage;

    private List<Transform> lsTransPageScrollViews = new List<Transform>();

    private List<ItemSlotLevel> lsItemSlotLevels = new List<ItemSlotLevel>();

    public HorizontalScrollSnap scrollSnap;

    public float timerAnimationSlotLevel = 0.33f;
    public int numberLevelPerPage;
    public override void OnInit()
    {
        numberLevelPerPage = Hiep_ConfigLevel.GetNumberLevelPerPage();
        int totalConfigLevel = Hiep_ConfigLevel.GetTotalCountConfig();
        int totalPage = Mathf.CeilToInt((float)totalConfigLevel / numberLevelPerPage);

        lsTransPageScrollViews.Clear();
        for (int i = 0; i < totalPage; i ++)
        {
            GameObject goPage = Instantiate(goPrefabPage, transContentScrollView);
            lsTransPageScrollViews.Add(goPage.transform);
            scrollSnap.AddChild(goPage);
        }

        for(int i = 0; i < totalPage; i++)
        {
            transLevelContent = lsTransPageScrollViews[i];
            for (int j = 0; j < numberLevelPerPage; j++)
            {
                int index = i * numberLevelPerPage + j;
                if (index > totalConfigLevel - 1)
                {
                    return;
                }

                GameObject goItem = Instantiate(goPrefabLevelItem, transLevelContent) as GameObject;
                goItem.name = "Item: " + index;
                ItemSlotLevel itemSlotLevel = goItem.GetComponent<ItemSlotLevel>();
                SetupItem(itemSlotLevel, index, true);
                lsItemSlotLevels.Add(itemSlotLevel);
            }
        }
        
       
        base.OnInit();
    }

    public override void OnSetUp(UIParam param = null)
    {
        StartCoroutine(ShowAnimationEnableSlotLevel());
        base.OnSetUp(param);
    }

    IEnumerator ShowAnimationEnableSlotLevel()
    {
        for (int i = 0; i < lsItemSlotLevels.Count; i++)
        {
            lsItemSlotLevels[i].transform.localScale = Vector3.zero;
            lsItemSlotLevels[i].gameObject.SetActive(false);
        }

        for (int i = 0; i < lsItemSlotLevels.Count; i++)
        {
            lsItemSlotLevels[i].gameObject.SetActive(true);
            lsItemSlotLevels[i].transform.DOScale(1, timerAnimationSlotLevel);
            
            yield return new WaitForSeconds(timerAnimationSlotLevel);
            ItemSlotLevel itemSlotLevel = lsItemSlotLevels[i];
            SetupItem(itemSlotLevel, i);
        }
    }

    private void SetupItem(ItemSlotLevel itemSlotLevel, int index, bool isInit = false)
    {
        index++;
        Hiep_ConfigLevelData configLevelData = Hiep_ConfigLevel.GetConfigLevel(index);
        
        // Setup Item
        int numberChest = 0;
        bool isChest = configLevelData.isChest;
        if (isChest)
        {
            numberChest = index / 5 - 1;
        }

        bool isUnlock = configLevelData.isUnlock;
        int numberStar = configLevelData.numberStar;
       
        itemSlotLevel.OnSetupItem(index, isUnlock, isChest, numberStar, numberChest, isInit);
    }

    public void OnBackClick()
    {
        UIManager.Instance.HideUI(this);
        UIManager.Instance.ShowUI(UIIndex.UIMain);
    }
}
