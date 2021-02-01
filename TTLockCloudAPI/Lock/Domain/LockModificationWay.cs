namespace OrbitaTech.TTLock
{
    public enum LockModificationWay
    {
        /// <summary>
        /// After lock was modified by bluetooth SDK.
        /// </summary>
        PhoneBluetooth = 1,

        /// <summary>
        /// Modification via WiFi gateway.
        /// </summary>
        Gateway,

        /// <summary>
        /// Modification via NB-IoT.
        /// </summary>
        NB_IoT
    }
}
