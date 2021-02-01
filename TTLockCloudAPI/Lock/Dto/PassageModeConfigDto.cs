namespace OrbitaTech.TTLock
{
    internal class PassageModeConfigDto
    {
        public int passageMode { get; set; }

        public int startDate { get; set; }

        public int endDate { get; set; }

        public int isAllDay { get; set; }

        public byte[] weekDays { get; set; }
    }
}
