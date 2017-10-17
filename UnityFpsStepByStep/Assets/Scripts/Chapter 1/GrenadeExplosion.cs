using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Chapter1
{
    public class GrenadeExplosion : MonoBehaviour
    {
        public float explosionForceMagnitude = 40f;
        public float blastRadius = 6f;
        public LayerMask layersToHit;
        private float destroyDelay = 7f;
        private Collider[] hits;

        void OnCollisionEnter(Collision col)
        {
            //Debug.Log(col.contacts[0].point.ToString());
            Explosion(col.contacts[0].point);
            Destroy(gameObject);
        }

        void Explosion(Vector3 explosionPoint)
        {
            hits = Physics.OverlapSphere(explosionPoint, blastRadius, layersToHit);

            foreach(Collider colx in hits)
            {
                var hitRigidBody = colx.GetComponent<Rigidbody>();

                if (colx.GetComponent<NavMeshAgent>() != null)
                    hitRigidBody.GetComponent<NavMeshAgent>().enabled = false;

                if (hitRigidBody == null)
                    continue;

                hitRigidBody.isKinematic = false;
                hitRigidBody.AddExplosionForce(explosionForceMagnitude, explosionPoint, blastRadius, 1, ForceMode.Impulse);

                if (colx.CompareTag("Enemy"))
                    Destroy(colx.gameObject, destroyDelay);
            }
        }
    }

}
