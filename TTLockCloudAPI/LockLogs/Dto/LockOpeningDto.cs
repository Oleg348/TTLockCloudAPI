namespace OrbitaTech.TTLock
{
    internal class LockOpeningDto
    {
        public int lockId { get; set; }

        /// <summary>
        /// <list type="bullet">
        /// <item>1 - App unlock</item>
        /// <item>2 - touch the parking lock</item>
        /// <item>3 - gateway unlock</item>
        /// <item>4 - pass code unlock</item>
        /// <item>5 - parking lock raise</item>
        /// <item>6 - parking lock lower</item>
        /// <item>7 - IC card unlock</item>
        /// <item>8 - fingerprint unlock</item>
        /// <item>9 - wristband unlock</item>
        /// <item>10 - mechanical key unlock</item>
        /// <item>11 - Bluetooth lock</item>
        /// <item>12 - gateway unlock</item>
        /// <item>29 - unexpected unlock</item>
        /// <item>30 - door magnet close</item>
        /// <item>31 - door magnet open</item>
        /// <item>32 - open from inside</item>
        /// <item>33 - lock by fingerprint</item>
        /// <item>34 - lock by pass code</item>
        /// <item>35 - lock by IC card</item>
        /// <item>36 - lock by Mechanical key</item>
        /// <item>37 - Remote Control</item>
        /// <item>44 - Tamper alert</item>
        /// <item>45 - Auto Lock</item>
        /// <item>46 - unlock by unlock key</item>
        /// <item>47 - lock by lock key</item>
        /// <item>48 - Use INVALID pass code several times</item>
        /// </list>
        /// </summary>
        public int recordType { get; set; }

        /// <summary>
        /// Is success: 0-No, 1-Yes.
        /// </summary>
        public int success { get; set; }

        /// <summary>
        /// Operator account.
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Pass code, IC card number, or wristband address.
        /// </summary>
        public string keyboardPwd { get; set; }

        /// <summary>
        /// Lock time.
        /// </summary>
        public long lockDate { get; set; }

        /// <summary>
        /// Server time.
        /// </summary>
        public long serverDate { get; set; }
    }
}
