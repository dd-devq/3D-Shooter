using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hiep;

public class Hiep_GameManager : SingletonMono<Hiep_GameManager>
{
    public void SetupGameplay(int level)
    {
        Transform transCharacterControl = GameObject.Find("CharacterControl").transform;
        Hiep_AutoController autoController = transCharacterControl.GetComponent<Hiep_AutoController>();

        Transform transMissionControl = GameObject.Find("MissionControl").transform;
        MissionControl missionControl = transMissionControl.GetComponent<MissionControl>();

        autoController.OnSetup(level, missionControl);
    }
}
