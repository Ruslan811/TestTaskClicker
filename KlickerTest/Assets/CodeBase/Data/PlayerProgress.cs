using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public Money Money;

        public PlayerProgress()
        {
            Money = new Money();
        }
    }
}