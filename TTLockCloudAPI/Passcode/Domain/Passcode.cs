namespace OrbitaTech.TTLock
{
    public class Passcode
    {
        public Passcode(int id, int lockId)
        {
            Id = id;
            LockId = lockId;
        }

        public int Id { get; }

        public int LockId { get; }
    }
}
