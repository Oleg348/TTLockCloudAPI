namespace OrbitaTech.TTLock
{
    public enum NB_IoT_OperateStatus
    {
        Normal = 1,
        InvalidOrExpired,
        Pending,
        Adding,
        AddFailed,
        Modifying,
        ModificationFailed,
        Deleting,
        DeletionFailed,
    }
}
