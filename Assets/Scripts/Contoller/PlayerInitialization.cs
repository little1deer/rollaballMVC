using UnityEngine;
namespace RollaBall
{
    internal sealed class PlayerInitialization : IInitialization
    {
        private readonly IPlayerFactory _playerFactory;
        private Transform _player;

        public PlayerInitialization(IPlayerFactory playerFactory, Vector3 position)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
            _player.position = position;
        }
        
        public void Initialization()
        {
        }

        public Transform GetPlayer()
        {
            return _player;
        }
    }
}