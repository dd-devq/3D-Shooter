using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hiep
{
    public class Hiep_AutoWeapon : Hiep_WeaponBehaviour
    {
        public Transform posShoot;
        public Transform aimPosShoot;
        
        public override void OnSetupBehaviour(Hiep_ConfigGunData configGunData, WeaponControl weaponControl)
        {
            base.OnSetupBehaviour(configGunData, weaponControl);
            this.iweapon = new AutoAction();
        }
    }
}

