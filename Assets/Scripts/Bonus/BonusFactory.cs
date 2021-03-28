using UnityEngine;

namespace RollaBall
{
    public class BonusFactory : IBonusFactory
    {
        private readonly BonusData _bonusData;

        public BonusFactory(BonusData bonusData)
        {
            bonusData = _bonusData;
        }

        public Transform CreateBonuses()
        {
            return new GameObject("FinishPickUp").AddMeshSphere().
                AddMaterial(_bonusData.Material).
                AddSphereCollider().transform;
        }
    }
}