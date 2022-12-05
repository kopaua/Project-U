using Assets.Scripts.Buildings;
using Assets.Scripts.Characters;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Assets.Scripts.UI
{
    public class FacilityPanel : BasePanel
    {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _character;
        [SerializeField] private Button _charactersButton;
        [SerializeField] private GameObject _characterList;
        [SerializeField] private CharacterItemUI _characterItemUI;

        [Inject] private ShelterCharacters _shelterCharacters;
        [Inject] private SignalBus _signalBus;

        private FacilityData _facilityData;
        private List<CharacterItemUI> _items = new List<CharacterItemUI>();

        private void Start()
        {
            _charactersButton.onClick.AddListener(OpenCharactersList);
            _characterList.SetActive(false);
            CreateCharacterList();
        }

        private void OnDestroy()
        {
            foreach (var item in _items)
            {
                item.OnClick -= SetCharacterToFacility;
            }
        }

        public override void OpenPanel(object data)
        {
            base.OpenPanel(data);
            _characterList.SetActive(false);
            _facilityData = (FacilityData)data;
            _name.text = _facilityData.BuildType.ToString();
            FindWorker();
            UpdateCharacterList();
        }

        private void FindWorker()
        {
            CharacterEntity character = _shelterCharacters.GetWorkerEntity(_facilityData);
            if (character != null)
            {
                _character.text = character.GetCharacterData.Name;
            }
            else
            {
                _character.text = "None";
            }
        }

        private void OpenCharactersList()
        {
            _characterList.SetActive(true);          
        }

        private void SetCharacterToFacility(CharacterData characterData)
        {
            _signalBus.Fire(new SetCharacterToFacility
            {
                CharacterData = characterData,
                FacilityData = _facilityData
            });
            FindWorker();
            UpdateCharacterList();
        }

        private void CreateCharacterList()
        {
            int count = _shelterCharacters.GetCharacterCount;
            for (int i = 0; i < count; i++)
            {
                CharacterItemUI clone = Instantiate(_characterItemUI, _characterList.transform);
                clone.OnClick += SetCharacterToFacility;
                clone.Init(_shelterCharacters.GetCharacterDataByIndex(i));
                _items.Add(clone);
            }
        }

        private void UpdateCharacterList()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                _items[i].UpdateItem(_shelterCharacters.GetCharacterDataByIndex(i));
            }
        }
    }
}