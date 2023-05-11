using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hiep
{
    public interface IWeapon
    {
        void OnAttack(object data);

        void OnReload(object data);
    }    
}

