using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hiep
{
    public class Hiep_WeaponBehaviour : MonoBehaviour
    {
        public IWeapon iweapon;
        public WeaponControl weaponControl;

        // Variable
        public float rof;
        public float timeReload;
        public int clipSize;
        public int currentBullet;
        public int amountAmo;
        public int damage;


        public GameObject goMuzzle;

        private float timer;
        private float timerReload;

        public Hiep_ConfigGunData configGunData;

        public AudioSource soundWeapon;

        public virtual void OnSetupBehaviour(Hiep_ConfigGunData configGunData, WeaponControl weaponControl)
        {
            this.configGunData = configGunData;
            rof = configGunData.rof;
            timeReload = configGunData.timeReload;
            clipSize = configGunData.clipSize;
            currentBullet = clipSize;
            amountAmo = configGunData.amountAmo;
            damage = configGunData.damage;

            timer = 0;
            timerReload = 0;
            this.weaponControl = weaponControl;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timer += Time.deltaTime;
            if (weaponControl.IsFire && timer > rof)
            {
                // Play Anim attack
                weaponControl.PlayAttackAnimation();
                OnAttack();
                timer = 0;
            }
        }

        public void OnAttack()
        {
            if (currentBullet > 0)
            {
                iweapon.OnAttack(this);
                soundWeapon.Play();
                PlayMuzzle();
            }
            else
            {
                weaponControl.OnReload();
            }
        }

        public void PlayMuzzle()
        {
            if (goMuzzle != null && !goMuzzle.activeInHierarchy)
            {
                StopCoroutine(RunMuzzle());
                StartCoroutine(RunMuzzle());
            }
        }

        IEnumerator RunMuzzle()
        {
            goMuzzle.SetActive(true);
            goMuzzle.transform.localRotation = Quaternion.Euler(0, 90, Random.Range(0, 180));
            yield return new WaitForSeconds(0.1f);
            goMuzzle.SetActive(false);
        }
    }
}

