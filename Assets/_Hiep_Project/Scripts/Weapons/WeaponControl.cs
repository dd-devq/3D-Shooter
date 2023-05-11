using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Hiep
{
    public delegate void ChangeGunHandle(Hiep_WeaponBehaviour weaponBehaviour);
    public delegate void UpdateBulletHandle(int curNumber, int total);
    public delegate void ReloadHandle(float timeReload, Action callback);

    public class WeaponControl : MonoBehaviour
    {
        public event ChangeGunHandle OnChangeGunhandle;
        public event UpdateBulletHandle OnUpdateBulletHandle;
        public event ReloadHandle OnReloadHandle;

        public float rof = 0.5f;
        private float timer = 0;

        public List<GameObject> lsWeapons = new List<GameObject>();
        private Hiep_AutoDatabinding autoDatabinding;

        private Hiep_WeaponBehaviour curWeapon;

        private bool isFire;

        public bool IsFire { get => isFire; set => isFire = value; }

        private int indexWeapon;


        // Start is called before the first frame update
        void Start()
        {
            Hiep_AutoInput.OnFire -= OnCheckFire;
            Hiep_AutoInput.OnFire += OnCheckFire;

            OnReloadHandle -= OnReloadHandleEvent;
            OnReloadHandle += OnReloadHandleEvent;

            autoDatabinding = GetComponent<Hiep_AutoDatabinding>();
            indexWeapon = -1;
            //SwitchWeapon();       
        }

        public void PlayAttackAnimation()
        {
            autoDatabinding.Attack = true;
        }


        public void OnReload()
        {
            Hiep_AutoInput.OnFire -= OnCheckFire;
            IsFire = false;
            if (curWeapon.amountAmo > 0)
            {
                if (curWeapon.timeReload > 0)
                {
                    if (OnReloadHandle != null)
                    {
                        OnReloadHandle(curWeapon.timeReload, () =>
                        {
                            curWeapon.iweapon.OnReload(curWeapon);
                            OnUpdateBullet();
                            Hiep_AutoInput.OnFire += OnCheckFire;
                        });
                    }                    
                }
                else
                {
                    curWeapon.iweapon.OnReload(curWeapon);
                    OnUpdateBullet();
                    Hiep_AutoInput.OnFire += OnCheckFire;
                }
            }
        }

        public void OnReloadHandleEvent(float timer, Action callback)
        {
            float timeCountdown = 0;
            DOTween.To(() => timeCountdown, x => timeCountdown = x, timer, timer).OnComplete(() =>
            {
                if (callback != null)
                {
                    callback();
                }                
            });
        }

        private void OnCheckFire(bool isFire)
        {
            this.IsFire = isFire;
        }

        public void OnUpdateBullet()
        {
            if (OnUpdateBulletHandle != null)
            {
                OnUpdateBulletHandle(curWeapon.currentBullet, curWeapon.amountAmo);
            }

        }

        public void SwitchWeapon()
        {
            indexWeapon++;
            if (indexWeapon >= lsWeapons.Count)
            {
                indexWeapon = 0;
            }

            if (curWeapon != null)
            {
                curWeapon.gameObject.SetActive(false);
            }

            lsWeapons[indexWeapon].SetActive(true);
            curWeapon = lsWeapons[indexWeapon].GetComponent<Hiep_WeaponBehaviour>();

            Hiep_ConfigGunData configGunData = Hiep_ConfigManager.configGun.GetRecordByKey(indexWeapon + 1);
            curWeapon.OnSetupBehaviour(configGunData, this);

            if (OnChangeGunhandle != null)
            {
                OnChangeGunhandle(curWeapon);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}