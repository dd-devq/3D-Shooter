using System;
using System.Collections;
using System.Collections.Generic;
using Core;
using DG.Tweening;
using Hiep;
using UnityEngine;
using UnityEngine.UI;

public class UIIngame : MonoBehaviour
{
    public Hiep_AutoHealth characterHealth;
    private Hiep_WeaponBehaviour weaponBehaviour;
    public WeaponControl weaponControl;

    public GameObject goReload;

    public Image imgReloadProgress;
    public Image imgHPProgress;

    public Text txtTimeReload;
    public Text txtAmo;

    private void Start()
    {
        weaponControl.OnChangeGunhandle -= ChangeGunHandle;
        weaponControl.OnChangeGunhandle += ChangeGunHandle;
        goReload.SetActive(false);
    }

    private void OnReloadHandle(float timeReload, Action callback)
    {
        float fillAmount = 1;        
        goReload.SetActive(true);
        DOTween.To(() => fillAmount, x => fillAmount = x, 0, timeReload).OnComplete(() =>
       {
           if (callback != null)
           {
               callback();
           }
           goReload.SetActive(false);
       }).OnUpdate(() =>
       {
           imgReloadProgress.fillAmount = fillAmount;
       });

        float timeCount = timeReload;
        DOTween.To(() => timeCount, x => timeCount = x, 0, timeReload).OnUpdate(() =>
        {
            txtTimeReload.text = timeCount.ToString("F1");
        });
    }

    public void UpdateBulletHandle(int current, int amo)
    {
        txtAmo.text = current.ToString() + "/" + amo.ToString();
    }

    private void HPChangeHandle(int curHP, int maxHP)
    {
        imgHPProgress.fillAmount = (float)curHP / maxHP;
    }

    public void ChangeGunHandle(Hiep_WeaponBehaviour weaponBehaviour)
    {
        this.weaponBehaviour = weaponBehaviour;
        if (weaponBehaviour.amountAmo > 0)
        {
            txtAmo.text = weaponBehaviour.currentBullet.ToString()
                + "/" + weaponBehaviour.amountAmo.ToString();
        }
        else
        {
            txtAmo.text = "0/0";
        }

        weaponControl.OnUpdateBulletHandle -= UpdateBulletHandle;
        weaponControl.OnUpdateBulletHandle += UpdateBulletHandle;

        weaponControl.OnReloadHandle -= OnReloadHandle;
        weaponControl.OnReloadHandle += OnReloadHandle;

        characterHealth.OnHPChange -= HPChangeHandle;
        characterHealth.OnHPChange += HPChangeHandle;       
    }

    public void OnPauseClick()
    {
        UIManager.Instance.ShowUI(UIIndex.UIPause);
    }

    public void OnSwitchWeaponClick()
    {
        weaponControl.SwitchWeapon();
    }
}
