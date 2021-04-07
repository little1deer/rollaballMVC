using UnityEngine;

namespace RollaBall
{
    public sealed class PlayerFactory: IPlayerFactory
    {
        private readonly PlayerData _playerData;

        public PlayerFactory(PlayerData playerData)
        {
            _playerData = playerData;
        }

        public Transform CreatePlayer()
        {
            return new GameObject("Player").AddMeshSphere().AddMaterial(_playerData.Material).AddSphereCollider()
                .AddRigidbody(1).AddComponent<PlayerController>().transform;
        }
    }
}