using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class Spell
    {
        public int id;
        public Texture icon;
        public int castTime;
        public string name;
        public string description;

        public Spell(int id, Texture icon, int castTime,string name, string description)
        {
            this.id = id;
            this.icon = icon;
            this.castTime = castTime;
            this.name = name;
            this.description = description;
        }

        public void Cast()
        {
            Debug.Log($"Cast Spell: {this.name}");
        }
    }
}
