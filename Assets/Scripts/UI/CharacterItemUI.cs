using Assets.Scripts.Characters;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    [RequireComponent(typeof(Button))]
    public class CharacterItemUI : MonoBehaviour
    {
        public event Action<CharacterData> OnClick;

        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Image _imageBg;
        private Button _button;
        private CharacterData _characterData;
        private Color _backgroundStartColor;


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
            _backgroundStartColor = _imageBg.color;
            UpdateItem(_characterData);
        }

        public void UpdateItem(CharacterData characterData)
        {
            _imageBg.color = characterData.FacilityId == 0 ? _backgroundStartColor: Color.yellow;
        }

        private void OnButtonClick()
        {
            OnClick?.Invoke(_characterData);         
        }
    }
}