using System;
using System.Collections.Generic;

namespace OrbitaTech.TTLock
{
    public class PageResult<T>
    {
        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="totalPages"></param>
        /// <param name="totalItems"></param>
        /// <param name="items"></param>
        /// <exception cref="ArgumentNullException"><paramref name="items"/> is null</exception>
        public PageResult(int currentPage, int totalPages, int totalItems, IList<T> items)
        {
            CurrentPage = currentPage;
            TotalPages = totalPages;
            TotalItems = totalItems;
            Items = items.IsNotNull(nameof(items));
        }

        public int CurrentPage { get; }

        public int TotalPages { get; }

        /// <summary>
        /// In all pages.
        /// </summary>
        public int TotalItems { get; }

        public IList<T> Items { get; }
    }
}
