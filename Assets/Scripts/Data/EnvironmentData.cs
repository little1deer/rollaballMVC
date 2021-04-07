using UnityEngine;

namespace RollaBall
{
    [CreateAssetMenu(fileName = "EnvironmentSettings", menuName = "Data/Environment/WallSettings")]
    public sealed class EnvironmentData:ScriptableObject
    {
        public Material MaterialWall;
        public Material MaterialFloor;
        public Material MaterialFinish;
        public Material MaterialKey;
        [SerializeField] private Vector3 _position;
        [SerializeField] private Vector3 _scaleWallChange;
        [SerializeField] private int _scaleLabirintX;
        [SerializeField] private int _scaleLabirintY;
        [SerializeField] private int _amountBonuses;
        public Vector3 Position => _position;
        public Vector3 ScaleWallChange => _scaleWallChange;
        public int ScaleLabirintX => _scaleLabirintX;
        public int ScaleLabirintY => _scaleLabirintY;
        public int AmountBonuses => _amountBonuses;
    }
}