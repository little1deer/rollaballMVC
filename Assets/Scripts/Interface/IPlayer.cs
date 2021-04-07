using System;

namespace RollaBall
{
    public interface IPlayer
    {
        event Action<int> OnTriggerEnterChange;
    }
}