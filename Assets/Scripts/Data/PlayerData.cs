using UnityEngine;

namespace RollaBall
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Player/PlayerSettings")]
    public sealed class PlayerData:ScriptableObject, IUnit
    {
        public Material Material;
        [SerializeField, Range(0, 100)] private float _speed;
        [SerializeField] private Vector3 _position;
        public float Speed => _speed;
        public Vector3 Position => _position;
    }
}