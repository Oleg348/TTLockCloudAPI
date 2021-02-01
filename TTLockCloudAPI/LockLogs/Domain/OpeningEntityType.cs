namespace OrbitaTech.TTLock
{
    public enum OpeningEntityType
    {
        AppUnlock = 1,
        TouchTheParkingLock,
        GatewayUnlock1,
        PasscodeUnlock,
        ParkingLockRaise,
        ParkingLockLower,
        ICCardUnlock,
        FingerprintUnlock,
        WristbandUnlock,
        MechanicalKeyUnlock,
        BluetoothLock,
        GatewayUnlock2,
        UnexpectedUnlock = 29,
        DoorMagnetClose,
        DoorMagnetOpen,
        OpenFromInside,
        LockByFingerprint,
        LockByPasscode,
        LockByICCard,
        LockByMechanicalKey,
        RemoteControl,
        TamperAlert = 44,
        AutoLock,
        UnlockByUnlockKey,
        LockByLockKey,
        UseINVALIDPasscodeSeveralTimes
    }
}
