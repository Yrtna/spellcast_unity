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

        public Animator _Animator;
        private int castQueue = 0;

        private AudioManagerScript _audioManager;
        private bool AnimatorIsCasting =>_Animator.GetBool("isCasting");

        // Start is called before the first frame update
        void Start()
        {
            Initialize(ability, weaponHolder);
            _audioManager = GameObject.FindWithTag("AudioManager").GetComponent<AudioManagerScript>();
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
                {
                    if (ability.Name == "Dash" && !AnimatorIsCasting)
                    {
                        castQueue = 1;
                        _Animator.SetTrigger("dash");
                        _Animator.SetBool("isCasting", true);
                        ((DashAbility)ability).PreCastAbility();
                    }
                    else if (ability.Name == "Channel" && !AnimatorIsCasting)
                    {
                        castQueue = 9;
                        _Animator.SetTrigger("channel");
                        _Animator.SetBool("isCasting", true);
                    }
                    else if (ability.Name == "Meteor" && !AnimatorIsCasting)
                    {
                        castQueue = 1;
                        _Animator.SetTrigger("cast");
                        _Animator.SetBool("isCasting", true);
                    }
                }
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
            _audioManager.PlayOneShot(ability.Name, 0.5f);
            castQueue -= 1;
            if (castQueue > 0)
            {
                _Animator.SetBool("isCasting", true);
                return;
            }

            _Animator.SetBool("isCasting", false);
            if (ability.Name == "Dash")
                _Animator.ResetTrigger("dash");
            else if (ability.Name == "Channel")
                _Animator.ResetTrigger("channel");
            else if (ability.Name == "Meteor")
                _Animator.ResetTrigger("cast");
        }

        public void CastSpell()
        {
            if (castQueue > 0)
                ButtonTriggered();
        }
    }
}