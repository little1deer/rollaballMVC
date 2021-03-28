namespace RollaBall
{
    public interface ILateExecute: IController
    {
        void LateExecute(float deltaTime);
    }
}