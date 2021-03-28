using UnityEngine;

namespace RollaBall
{
    public class BonusInitialization : IInitialization
    {
        private readonly IBonusFactory _bonusFactory;
        private Transform _bonuses;
        
        public BonusInitialization(IBonusFactory bonusFactory)
        {
            _bonusFactory = bonusFactory;
            //_bonuses = bonusFactory.CreateBonuses();
        }
        
        public void Initialization()
        {
        }
    }
}