using Assets.Scripts.Characters;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof (Button))]
    public class CharacterItemUI : MonoBehaviour
    {
        public event Action<CharacterData> OnClick;

        [SerializeField] private TextMeshProUGUI _name;
        private Button _button;
        private CharacterData _characterData;

        // Use this for initialization
        void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnButtonClick);
        }

        public void Init(CharacterData characterData)
        {
            _characterData = characterData;
            _name.text = characterData.Name;
        }

        private void OnButtonClick()
        {
            OnClick?.Invoke(_characterData);         
        }
    }
}