using System;
using UnityEngine;

namespace Assets.Scripts.Characters
{
    [Serializable]
    public struct CharacterData
    {
        [HideInInspector] public int ID;
        public string Name;       
    }
}