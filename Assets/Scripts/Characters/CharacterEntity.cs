using Assets.Scripts.Buildings;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Characters
{
    public class CharacterEntity : MonoBehaviour
    {
        public CharacterData GetCharacterData => _characterData;

        private CharacterData _characterData;

        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Init(CharacterData data)
        {
            _characterData = data;
            gameObject.name = _characterData.Name;
            gameObject.SetActive(false);
        }

        public void SetFacility(FacilityData facilityData)
        {
            _characterData.FacilityId = facilityData.FacilityID;
            transform.position = facilityData.InteractionPoint;
        }

        public void ClearFacility()
        {
            _characterData.FacilityId = 0;
            gameObject.SetActive(false);
        }

        public class Factory : PlaceholderFactory<CharacterEntity>
        {
        }
    }
}