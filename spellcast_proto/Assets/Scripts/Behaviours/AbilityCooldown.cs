using System.Globalization;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviours
{
    public class AbilityCooldown : MonoBehaviour
    {
        public Image darkMask;
        public Text cooldownText;
        public GameObject canvasAbility;

        [SerializeField] private Ability ability;
        [SerializeField] private GameObject weaponHolder;
        private Image _buttonImage;
        private float _cooldownDuration;
        private float _nextReadyTime;
        private float _cooldownTimeLeft;
    
        // Start is called before the first frame update
        void Start()
        {
            Initialize(ability, weaponHolder);
        }

        private void Initialize(Ability selectedAbility, GameObject weaponHolderGameObject)
        {
            ability = selectedAbility;
            _buttonImage = canvasAbility.GetComponent<Image>();
            _buttonImage.sprite = ability.iconSprite;
            darkMask.sprite = ability.iconSprite;
            _cooldownDuration = ability.BaseCooldown;
            ability.Initialize(weaponHolderGameObject);
            AbilityReady();
        }

        private void AbilityReady()
        {
            cooldownText.enabled = false;
            darkMask.enabled = false;
        }

        // Update is called once per frame
        void Update()
        {
            var cooldownComplete = Time.time > _nextReadyTime;
            if (cooldownComplete)
            {
                AbilityReady();
                if (Input.GetButton(ability.BindName))
                    ButtonTriggered();
            }
            else
            {
                Cooldown();
            }
        }

        private void Cooldown()
        {
            _cooldownTimeLeft -= Time.deltaTime;
            var roundedCooldown = Mathf.Round(_cooldownTimeLeft);
            cooldownText.text = roundedCooldown.ToString(CultureInfo.InvariantCulture);
            darkMask.fillAmount = _cooldownTimeLeft / _cooldownDuration;
        }
        
        private void ButtonTriggered()
        {
            _nextReadyTime = _cooldownDuration + Time.time;
            _cooldownTimeLeft = _cooldownDuration;
            darkMask.enabled = true;
            cooldownText.enabled = true;
            
            ability.TriggerAbility(gameObject.transform);
        }
    }
}
