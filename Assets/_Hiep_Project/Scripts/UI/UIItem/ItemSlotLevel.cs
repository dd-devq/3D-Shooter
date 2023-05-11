using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Core;
public class ItemSlotLevel : MonoBehaviour
{
    [Header("------------------UI------------------")]
    public List<Image> lsImgWoods = new List<Image>();
    public List<Image> lsImgStars = new List<Image>();
    public Image imgChest;

    public Text txtLevel;
    public Button btnClick;

    [Header("------------------Sprite------------------")]
    public List<Sprite> lsSpriteWoods = new List<Sprite>();
    public List<Sprite> lsSpriteChest = new List<Sprite>();
    public Sprite spriteStarOff;
    public Sprite spriteStarOn;

    [Header("------------------Variable------------------")]
    public float timerAnimStar = 0.2f;
    private int levelIndex;

    private void Awake()
    {
        btnClick = GetComponent<Button>();

    }
    public void OnSetupItem(int level, bool isUnlock, bool isChest, int numberStar, int numberChest = 0
        , bool isInit = false)
    {
        levelIndex = level;
        btnClick.enabled = isUnlock;
        txtLevel.text = level.ToString();
        for (int i = 0; i < lsImgStars.Count; i++)
        {
            lsImgStars[i].sprite = spriteStarOff;
        }

        if (isChest)
        {
            for (int i = 0; i < lsImgWoods.Count; i++)
            {
                lsImgWoods[i].gameObject.SetActive(false);
            }

            imgChest.gameObject.SetActive(true);

            numberChest %= lsSpriteChest.Count;
            imgChest.sprite = lsSpriteChest[numberChest];
            if (!isInit)
            {
                SetStarLevel(numberStar);
            }
            
        }
        else
        {
            imgChest.gameObject.SetActive(false);
            if (isUnlock)
            {
                for (int i = 0; i < lsImgWoods.Count; i++)
                {
                    lsImgWoods[i].gameObject.SetActive(false);
                }
                if (!isInit)
                {
                    SetStarLevel(numberStar);
                }
            }
            else
            {
                if (isInit)
                {
                    int randCount = Random.Range(1, lsImgWoods.Count + 1);
                    {
                        for (int i = 0; i < lsImgWoods.Count; i++)
                        {
                            if (i < randCount)
                            {
                                lsImgWoods[i].gameObject.SetActive(true);
                                int randIndexSprite = Random.Range(0, lsSpriteWoods.Count);
                                lsImgWoods[i].sprite = lsSpriteWoods[randIndexSprite];
                            }
                            else
                            {
                                lsImgWoods[i].gameObject.SetActive(false);
                            }
                        }
                    }
                }              
            }
        }
    }

    private void SetStarLevel(int numberStar)
    {
        StartCoroutine(SetAnimationStar(numberStar, timerAnimStar));
    }

    IEnumerator SetAnimationStar(int numberStar, float timer)
    {
        for (int i = 0; i < lsImgStars.Count; i++)
        {
            if (i < numberStar)
            {
                lsImgStars[i].sprite = spriteStarOn;
            }
            
            yield return new WaitForSeconds(timer);
        }
    }

    public void OnLevelClick()
    {
        Hiep_FirebaseAnalyticManager.Instance.LogEvent("LevelClick", "level", levelIndex.ToString());
        UIManager.Instance.HideUI(UIIndex.UISelectLevel);
        // Load scene
        Hiep_ConfigMissionData configMissionData = Hiep_ConfigManager.configMission.GetRecordByKey(levelIndex);
        LoadSceneManager.Instance.OnLoadScene(configMissionData.sceneMap, (obj) =>
        {
            Debug.Log(obj.ToString());
            Hiep_GameManager.Instance.SetupGameplay(levelIndex);
        });
        //UIManager.Instance.ShowUI(UIIndex.UIGameplay);
    }

}
