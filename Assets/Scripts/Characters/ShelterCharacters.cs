using Assets.Scripts.Buildings;
using System.Linq;
using Zenject;

namespace Assets.Scripts.Characters
{
    public class ShelterCharacters : IInitializable
    {
        [Inject] private CharacterEntity.Factory _characterFactory;
        [Inject] private CharacterData[] CharactersConfigInfo;
        [Inject] private SignalBus _signalBus;  

        public int GetCharacterCount => _characters.Length;     

        private CharacterEntity[] _characters;

        public void Initialize()
        {
            CreateCharacters();
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

        public CharacterEntity GetWorkerEntity(FacilityData facilityData)
        {
            CharacterEntity characterEntity = null;
            foreach (var item in _characters)
            {
                if (item.GetCharacterData.FacilityId == facilityData.FacilityID)
                {
                    characterEntity = item;
                    break;
                }
            }
            return characterEntity;
        }

        private void OnSetCharacterToFacility(SetCharacterToFacility signal)
        {
            CharacterEntity character = GetWorkerEntity(signal.FacilityData);
            if (character != null)
                character.ClearFacility();
            CharacterEntity characterEntity = GetCharacterEntityById(signal.CharacterData.ID);
            characterEntity.gameObject.SetActive(true);
            characterEntity.SetFacility(signal.FacilityData);
        }

        private void CreateCharacters()
        {
            _characters = new CharacterEntity[CharactersConfigInfo.Length];
            for (int i = 0; i < _characters.Length; i++)
            {
                CharactersConfigInfo[i].ID = i + 1;
                CharactersConfigInfo[i].FacilityId = 0;
                CharacterEntity characterClone = _characterFactory.Create();
                characterClone.Init(CharactersConfigInfo[i]);
                _characters[i] = characterClone;
            }
        }
    }
}