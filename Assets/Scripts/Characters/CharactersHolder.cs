using System.Linq;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Characters
{
    public class CharactersHolder : IInitializable
    {
        private CharacterData[] _characters;

        public void Initialize()
        {
            _characters = Resources.Load<CharactersConfig>("CharactersConfig").GerCharactersData;
            for (int i = 0; i < _characters.Length; i++)
            {
                _characters[i].ID = i +1;
            }
        }

        public CharacterData GetCharacter(int id)
        {
            return _characters.First(x => x.ID == id);
        }
    }
}
