using Data;
using UnityEngine;

namespace Behaviours
{
    public class Wizard : MonoBehaviour
    {
        public Spell fireBlast;
        // Start is called before the first frame update
        void Start()
        {
            fireBlast = new Spell(1, Texture2D.normalTexture,0, "Fire Blast", "Cast an instant blast of fire.");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                fireBlast.Cast();
            }
        }
    }
}
