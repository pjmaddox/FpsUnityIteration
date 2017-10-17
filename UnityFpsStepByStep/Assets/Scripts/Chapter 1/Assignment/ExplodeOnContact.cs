using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Chapter1Assignment
{
    public class ExplodeOnContact : MonoBehaviour
    {
        private float explosionForce = 100f;
        private float explosionRadius = 10f;
        public LayerMask targetLayers;

        void OnCollisionEnter()
        {
            Explode();
            Destroy(gameObject);
        }

        void Explode()
        {
            var hits = Physics.OverlapSphere(this.transform.position, explosionRadius, targetLayers);

            foreach(Collider cx in hits)
            {
                //Disable Agent for enemies if they exist
                var navMeshAgentX = cx.GetComponent<NavMeshAgent>();
                if (navMeshAgentX)
                {
                    if (cx.CompareTag("Enemy") && navMeshAgentX.enabled)
                        cx.gameObject.GetComponent<EnemySeekAI>().MarkEnemyKilled();

                    navMeshAgentX.enabled = false;
                }


                //Add force
                var rbx = cx.GetComponent<Rigidbody>();
                if (rbx != null)
                    rbx.AddExplosionForce(explosionForce, this.transform.position, explosionRadius, 1, ForceMode.Impulse);

                if (cx.CompareTag("Enemy"))
                    Destroy(cx, 7f);
            }
        }
    }
}
