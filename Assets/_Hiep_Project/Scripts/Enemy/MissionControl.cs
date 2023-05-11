using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
namespace Hiep
{
    public class MissionControl : MonoBehaviour
    {
        public List<Transform> lsTransCreateZombies = new List<Transform>();
        public int maxZombieCount = 10;
        private int curZombieCount = 0;

        private int idZombie = 1;
        private float timeCountdownCreate = 3;

        private List<DataWave> lsDataWaves = new List<DataWave>();
        private int scoreMission;
        private float timerMission;

        public void OnSetupMission(int idMission)
        {
            // Load config mission
            curZombieCount = 0;
            scoreMission = 0;
            timerMission = 0;
            Hiep_ConfigMissionData configMission = Hiep_ConfigManager.configMission.GetRecordByKey(idMission);
            lsDataWaves = configMission.GetListWaves();
            maxZombieCount = lsDataWaves.Count;

            StartCoroutine(DelayCreateZombie());
        }

        private void CreateZombie(int idZombie)
        {
            Hiep_ConfigEnemyData configEnemy = Hiep_ConfigManager.configEnemy.GetRecordByKey(idZombie);

            GameObject goEnemy = Instantiate(Resources.Load("Enemy/" + configEnemy.namePrefab, typeof(GameObject)))
                as GameObject;
            int randPos = Random.Range(0, lsTransCreateZombies.Count);
            Transform posTrans = lsTransCreateZombies[randPos];
            goEnemy.transform.position = posTrans.position;

            ZombieNormalSystem zombieNormalSystem = goEnemy.GetComponent<ZombieNormalSystem>();
            zombieNormalSystem.OnSetupZombie(configEnemy);
            zombieNormalSystem.OnZombieDead += OnZombieDeadCallback;
        }

        private void Update()
        {
            timerMission += Time.deltaTime;
        }

        private void OnZombieDeadCallback(ZombieSystem zombieSystem)
        {
            curZombieCount++;
            if (curZombieCount < maxZombieCount)
            {
                // Create zombie
                StartCoroutine(DelayCreateZombie());
                scoreMission += 100;
            }
            else
            {                
                UIManager.Instance.ShowUI(UIIndex.UIWin,
                    new WinParam { numberStar = 3, score = scoreMission, timeCount = Mathf.RoundToInt(timerMission) });
                Debug.Log("You win");
            }
        }

        IEnumerator DelayCreateZombie()
        {
            timeCountdownCreate = lsDataWaves[curZombieCount].timeDelay;
            yield return new WaitForSeconds(timeCountdownCreate);
            idZombie = lsDataWaves[curZombieCount].idEnemy;
            CreateZombie(idZombie);
        }
    }
}