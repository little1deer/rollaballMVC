using System.IO;
using UnityEngine;

namespace RollaBall
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _environmentDataPath;
        [SerializeField] private string _bonusDataPath;
        private PlayerData _player;
        private EnvironmentData _environmentData;
        private BonusData _bonusData;
        
        public PlayerData Player
        {
            get
            {
                if (_player == null)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }  
        public EnvironmentData Environment
        {
            get
            {
                if (_environmentData == null)
                {
                    _environmentData = Load<EnvironmentData>("Data/" + _environmentDataPath);
                }

                return _environmentData;
            }
        }
        public BonusData Bonus
        {
            get
            {
                if (_bonusData == null)
                {
                    _bonusData = Load<BonusData>("Data/" + _bonusDataPath);
                }

                return _bonusData;
            }
        }
        private T Load<T>(string resourcesPath) where T : Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcesPath, null));
        
    }
}