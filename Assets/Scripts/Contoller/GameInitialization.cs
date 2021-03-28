using UnityEngine;
namespace RollaBall
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data data)
        {
            Camera camera = Camera.main;
            var inputInitialization = new InputInitialization();
            var playerFactory = new PlayerFactory(data.Player);
            var playerInitialization = new PlayerInitialization(playerFactory,data.Player.Position);
            var environmentFactory = new EnvironmentFactory(data.Environment);
            var environmentInitialization = new EnvironmentInitialization(environmentFactory, data.Environment.Position);
            var bonusFactory = new BonusFactory(data.Bonus);
            var bonusInitialization = new BonusInitialization(bonusFactory);
            controllers.Add(inputInitialization);
            controllers.Add(playerInitialization);
            controllers.Add(bonusInitialization);
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(new MoveController(inputInitialization.GetInput(), playerInitialization.GetPlayer(), data.Player));
            controllers.Add(new CameraController(playerInitialization.GetPlayer(), camera.transform));
            // controllers.Add(new EndGameController(enemyInitialization.GetEnemies(), playerInitialization.GetPlayer().gameObject.GetInstanceID()));
        }
    }
}