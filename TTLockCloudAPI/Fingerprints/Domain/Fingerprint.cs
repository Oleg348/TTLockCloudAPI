namespace OrbitaTech.TTLock
{
    public class Fingerprint
    {
        public Fingerprint(int id, int lockId)
        {
            Id = id;
            LockId = lockId;
        }

        public int Id { get; }

        public int LockId { get; }
    }
}
