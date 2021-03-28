using System;
namespace RollaBall
{
    public interface IUserInputProxy
    {
        event Action<float> AxisOnChange;
        void GetAxis();
    }
}
