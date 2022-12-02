using UnityEngine;
using Zenject;

namespace Assets.Scripts.Characters
{
    [CreateAssetMenu(fileName = "CharactersInstaller", menuName = "Installers/CharactersInstaller")]
    public class CharactersInstaller : ScriptableObjectInstaller<CharactersInstaller>
    {

        [SerializeField] public CharacterEntity CharacterEntity;

        public override void InstallBindings()
        {
            Container.BindInstance(CharacterEntity);
        }
    }
}