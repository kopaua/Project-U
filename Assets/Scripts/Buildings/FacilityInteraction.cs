using UnityEngine;

namespace Assets.Scripts.Buildings
{
    public class FacilityInteraction : MonoBehaviour
    {
        public Vector3 InteractionPoint => _interactionPoint.position;

        [SerializeField] private Transform _interactionPoint;
    }
}