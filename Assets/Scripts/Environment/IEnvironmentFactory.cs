using UnityEngine;

namespace RollaBall
{
    public interface IEnvironmentFactory
    {
        Transform CreateMaze();
    }
}