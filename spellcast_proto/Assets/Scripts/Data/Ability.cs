using UnityEditor;
using UnityEngine;

namespace Data
{
    public abstract class Ability : ScriptableObject
    {
        public GUID AbilityGuid;
        public string Name = "New Ability";
        public Sprite iconSprite;
        public float BaseCooldown = 1f;
        public string BindName = "New Bind";

        public abstract void Initialize(GameObject obj);
        public abstract void TriggerAbility();
    }
}
