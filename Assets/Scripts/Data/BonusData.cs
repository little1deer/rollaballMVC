using UnityEngine;

namespace RollaBall
{
    [CreateAssetMenu(fileName = "PlayerSettings", menuName = "Data/Bonus/BonusSettings")]
    public sealed class BonusData: ScriptableObject
    {
        public Material Material;
    }
}