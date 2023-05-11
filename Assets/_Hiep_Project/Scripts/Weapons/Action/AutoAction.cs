using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
namespace Hiep
{
    public class AutoAction : IWeapon
    {
        private Hiep_AutoWeapon autoWeapon;

        public void OnAttack(object data)
        {
            autoWeapon = (Hiep_AutoWeapon)data;
            // Create Bullet;
            Transform transBullet = PoolManager.Instance.dicPools[NamePool.PoolBulletAuto.ToString()]
                .GetObjectInstance();
            transBullet.position = autoWeapon.posShoot.position;

            Vector3 dir = autoWeapon.aimPosShoot.position - autoWeapon.posShoot.position;
            dir.Normalize();
            transBullet.up = dir;
            transBullet.GetComponent<Bullet>().OnShoot(10, dir, autoWeapon.damage);

            autoWeapon.currentBullet--;
        }

        public void OnReload(object data)
        {
            autoWeapon = (Hiep_AutoWeapon)data;
            if (autoWeapon.amountAmo >= autoWeapon.clipSize)
            {
                autoWeapon.currentBullet = autoWeapon.clipSize;
                autoWeapon.amountAmo -= autoWeapon.clipSize;
            }
            else
            {                
                autoWeapon.currentBullet = autoWeapon.amountAmo;
                autoWeapon.amountAmo = 0;
                if (autoWeapon.currentBullet == 0 && autoWeapon.amountAmo == 0)
                {
                    // Game Over
                    UIManager.Instance.ShowUI(UIIndex.UILose);
                }
            }
        }

    }
}
