namespace OrbitaTech.TTLock
{
    internal class PageResultDto<T>
        where T : class, new()
    {
        public T[] list { get; set; }

        public int pageNo { get; set; }

        public int pageSize { get; set; }

        public int pages { get; set; }

        public int total { get; set; }
    }
}
