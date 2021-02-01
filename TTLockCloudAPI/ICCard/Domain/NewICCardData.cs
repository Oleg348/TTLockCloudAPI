using System;

namespace OrbitaTech.TTLock
{
    using static APIHelpers;

    public class NewICCardData
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <param name="cardName"></param>
        /// <param name="beginningTime"></param>
        /// <param name="expirationTime"></param>
        /// <exception cref="ArgumentException"><paramref name="cardNumber"/> is invalid.</exception>
        public NewICCardData(string cardNumber, string cardName, DateTime beginningTime, DateTime expirationTime)
        {
            CardNumber = VerifyICCardNumber(cardNumber);
            CardName = cardName;
            BeginningTime = beginningTime;
            ExpirationTime = expirationTime;
        }

        public string CardNumber { get; }

        public string CardName { get; }

        public DateTime BeginningTime { get; }

        public DateTime ExpirationTime { get; }
    }
}
