using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Hiep
{
    public class Bullet : MonoBehaviour
    {
        private int damage;
        private float speed;
        public LayerMask mask;
        private Vector3 dir;
        private RaycastHit hit;

        public void OnShoot(float speed, Vector3 dir, int damage)
        {
            transform.forward = dir.normalized;
            this.damage = damage;
            this.speed = speed;
            this.dir = dir;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            Physics.Raycast(transform.position, dir, out hit, 0.5f);
            if (hit.collider != null)
            {
                Debug.Log("Hit: " + hit.collider.name);
                OnHit();
            }    
        }

        private void OnHit()
        {
            Transform impact = null;
            if (hit.collider != null)
            {
                Debug.LogError("hit: " + hit.collider.gameObject.name);
            }

            // Damage Enemy
            if (hit.collider != null && hit.collider.gameObject.CompareTag("Enemy"))
            {
                hit.collider.gameObject.GetComponent<ZombieOnDamage>().ApplyDamage(damage);
                impact = PoolManager.Instance.dicPools[NamePool.PoolImpactEnemy.ToString()].GetObjectInstance();
            }
            
            if (impact != null)
            {
                impact.position = hit.point;
                impact.forward = hit.normal;
                PoolManager.Instance.dicPools[NamePool.PoolBulletAuto.ToString()].DisableObjectPool(gameObject);
            }           
        }
    }
}
