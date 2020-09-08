using UnityEngine;

namespace Behaviours
{
    public class BulletLifespan : MonoBehaviour
    {
        public float lifespan = 1f;

        private void Awake()
        {
            Destroy(gameObject, lifespan);
        }
    }
}
