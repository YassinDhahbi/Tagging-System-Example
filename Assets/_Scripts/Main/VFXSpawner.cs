using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    public class VFXSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject explosionVfx;

        public void SpawnExplosionVFX(GameObject target)
        {
            var spawningPos = target.transform.position;
            explosionVfx.transform.position = spawningPos;
            // This is used reactivate the animation on the Explosion Effect
            explosionVfx.SetActive(false);
            explosionVfx.SetActive(true);
        }
    }
}