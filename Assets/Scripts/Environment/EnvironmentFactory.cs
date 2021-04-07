using UnityEngine;

namespace RollaBall
{
    public sealed class EnvironmentFactory : IEnvironmentFactory
    {
        private readonly EnvironmentData _environmentData;
        public EnvironmentFactory(EnvironmentData environmentData)
        {
            _environmentData = environmentData;
        }

        public Transform CreateWall(string name, Vector3 rotation, Vector3 position)
        {
            return new GameObject(name).AddMeshCube().AddMaterial(_environmentData.MaterialWall).ChangeRotation(rotation)
                .ChangeScale(_environmentData.ScaleWallChange).ChangePosition(position).AddBoxCollider().transform;
        }

        public Transform CreateFloor(Vector3 scale, Vector3 position)
        {
            return new GameObject("Floor").AddMeshPlane().AddMaterial(_environmentData.MaterialFloor).AddBoxCollider()
                .ChangeScale(scale).ChangePosition(position).ChangeBoxColliderFloor().transform;
        }
        public Transform CreateFinish(string name, Vector3 position,Vector3 scale)
        {
            return new GameObject(name).AddMeshCube().AddMaterial(_environmentData.MaterialFinish).
                ChangePosition(position).ChangeScale(scale).AddBoxCollider().SetTriggerBox().SetTag("Finish").transform;
        } 
        public Transform CreateKey(string name,Vector3 pos)
        {
            return new GameObject(name).ChangePosition(pos).AddMeshSphere().AddMaterial(_environmentData.MaterialKey).AddBoxCollider().SetTriggerBox().SetTag("Key").transform;
        }
        public GameObject CreateCell(Vector3 vector3,bool leftEnable,bool bottomEnable, bool exitEnable, bool floorEnable, bool keyEnable)
        {
            GameObject cell;
            cell = new GameObject("Cell");
            var leftWallRot = new Vector3(0, 90, 0);
            var leftWallPos = new Vector3(-3, -1, 3);
            var zeros = new Vector3(0, 0, 0);
            var bottomWallPos = new Vector3(0, -1, 0);
            var finishPos = new Vector3(0.5f, 0, 3.5f);
            var finishScale = new Vector3(5, 2, 5);
            var keyPos = new Vector3(0, -1, 3);
            if (leftEnable)
            {
                CreateWall("Left Wall", leftWallRot, leftWallPos).SetParent(cell.transform);
            }
            if (bottomEnable)
            {
                CreateWall("Bottom Wall", zeros, bottomWallPos).SetParent(cell.transform);
            }
            
            var scaleFloor = new Vector3(-1.7f, 0, -1.7f);
            var positionFloor = new Vector3(0, -1.5f, 3);
            if (floorEnable)
            {
                CreateFloor(scaleFloor, positionFloor).SetParent(cell.transform);
            }
            if (exitEnable)
            {
                CreateFinish("Finish", finishPos,finishScale).SetParent(cell.transform);
            }
            if (keyEnable)
            {
                CreateKey("Key",keyPos).SetParent(cell.transform);
            }
            cell.transform.position = vector3;
            return cell;
        }
        public Transform CreateMaze()
        {
            Vector3 CellSize = new Vector3(_environmentData.ScaleWallChange.x+1,0,_environmentData.ScaleWallChange.x+1);
            GameObject c;
            c = new GameObject("Maze");
            MazeController generatorCell = new MazeController();
            MazeGeneratorCell[,] maze = generatorCell.GenerateMaze(_environmentData.ScaleLabirintX,_environmentData.ScaleLabirintY );
            
            for (int x = 0; x < maze.GetLength(0); x++)
            {
                for (int y = 0; y < maze.GetLength(1); y++)
                {
                    Vector3 v = new Vector3(x*CellSize.x,y*CellSize.y,y*CellSize.z);
                    CreateCell(v, (maze[x, y].WallLeft), (maze[x, y].WallBottom),maze[x,y].Exit,maze[x,y].Floor, maze[x,y].Key).transform.parent = c.transform;
                }
            }
            return c.transform;
        }
    }
}