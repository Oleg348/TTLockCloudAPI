namespace OrbitaTech.TTLock
{
    public class LockInitResult
    {
        public LockInitResult(int lockId, int adminEkeyId)
        {
            LockId = lockId;
            AdminEkeyId = adminEkeyId;
        }

        public int LockId { get; }

        public int AdminEkeyId { get; }
    }
}
