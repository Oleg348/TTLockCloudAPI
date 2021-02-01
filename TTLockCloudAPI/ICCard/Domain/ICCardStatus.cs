namespace OrbitaTech.TTLock
{
    public enum ICCardStatus
    {
        Normal = 1,
        InvalidOrExpired,
        Pending,
        Adding,
        AddingFailed,
        Modifying,
        ModificationFailed,
        Deleting,
        DeletionFailed,
    }
}
