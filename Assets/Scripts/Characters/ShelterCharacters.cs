using Assets.Scripts.Buildings;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Assets.Scripts.Characters
{
    public class ShelterCharacters : IInitializable
    {
        [Inject] private CharactersHolder _charactersHolder;
        [Inject] private CharacterEntity.Factory _characterFactory;
        [Inject] private SignalBus _signalBus;

        public int GetCharacterCount => _characters.Count;

        private List<CharacterEntity> _characters = new List<CharacterEntity>();

        public void Initialize()
        {
            for (int i = 1; i <= 2; i++)
            {
                CharacterEntity character = _characterFactory.Create();
                character.Init(_charactersHolder.GetCharacter(i));
                _characters.Add(character);
            }
            _signalBus.Subscribe<SetCharacterToFacility>(OnSetCharacterToFacility);
        }

        public CharacterData GetCharacterDataById(int id)
        {
            return _characters.First(x => x.GetCharacterData.ID == id).GetCharacterData;
        }

        public CharacterData GetCharacterDataByIndex(int index)
        {
            return _characters[index].GetCharacterData;
        }

        public CharacterEntity GetCharacterEntityById(int id)
        {
            return _characters.First(x => x.GetCharacterData.ID == id);
        }

        public CharacterEntity FindWorker(FacilityData facilityData)
        {
            CharacterEntity characterEntity = _characters.Find(x => x.GetCharacterData.FacilityId == facilityData.FacilityID);
            return characterEntity;
        }

        private void OnSetCharacterToFacility(SetCharacterToFacility signal)
        {
            CharacterEntity character = FindWorker(signal.FacilityData);
            if (character != null)
                character.ClearFacility();
            GetCharacterEntityById(signal.CharacterData.ID).SetFacility(signal.FacilityData);
        }
    }
}