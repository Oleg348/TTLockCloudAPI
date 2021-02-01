namespace OrbitaTech.TTLock
{
    public class ICCard
    {
        public ICCard(int id, int lockId)
        {
            Id = id;
            LockId = lockId;
        }

        public int Id { get; }

        public int LockId { get; }
    }
}
