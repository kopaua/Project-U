using UnityEngine;
using Zenject;

namespace Assets.Scripts.Characters
{
    [CreateAssetMenu(fileName = "CharactersInstaller", menuName = "Installers/CharactersInstaller")]
    public class CharactersInstaller : ScriptableObjectInstaller<CharactersInstaller>
    {

        [SerializeField] public CharacterEntity CharacterEntity;
        [SerializeField] public CharacterData[] CharactersConfigInfo;

        public override void InstallBindings()
        {
            Container.BindInstance(CharacterEntity);
            Container.BindInstance(CharactersConfigInfo);
        }
    }
}