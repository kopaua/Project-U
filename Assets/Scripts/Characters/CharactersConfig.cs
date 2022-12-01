using UnityEngine;

namespace Assets.Scripts.Characters
{
    [CreateAssetMenu(fileName = "CharactersConfig", menuName = "Configs/CharactersConfig")]

    public class CharactersConfig : ScriptableObject
    {
        public CharacterData[] GerCharactersData => charactersData;

        [SerializeField] private CharacterData[] charactersData;
    }
}