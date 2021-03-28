using UnityEngine;

namespace RollaBall
{
    public class EnvironmentInitialization:IInitialization
    {
        private readonly IEnvironmentFactory _environmentFactory;
        private Transform _environment;

        public EnvironmentInitialization(IEnvironmentFactory environmentFactory, Vector3 position)
        {
            _environmentFactory = environmentFactory;
            _environment = _environmentFactory.CreateMaze();
            _environment.position = position;
        }
        
        public void Initialization()
        {
        }
    }
}