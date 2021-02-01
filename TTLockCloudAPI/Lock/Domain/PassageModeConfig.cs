using System;
using System.Collections.Generic;

namespace OrbitaTech.TTLock
{
    public class PassageModeConfig
    {
        private readonly List<byte> _workingDays;

        private PassageModeConfig(bool isEnabled, bool isAllDay, int startDayTime, int endDayTime, IEnumerable<byte> workingDays)
        {
            IsEnabled = isEnabled;
            IsAllDay = isAllDay;
            StartDayTime = startDayTime.IsValid(st => st >= 0, nameof(startDayTime), "Start day time must be a positive value");
            EndDayTime = endDayTime.IsValid(et => et >= 0, nameof(endDayTime), "End day time must be a positive value");
            _workingDays = new List<byte>(workingDays ?? new byte[0]);
        }

        /// <summary>
        /// Ctor for not full working day.
        /// </summary>
        /// <param name="startDayTime"></param>
        /// <param name="endDayTime"></param>
        /// <param name="workingDays"></param>
        /// <exception cref="ArgumentException">
        /// <paramref name="startDayTime"/> is invalid
        /// -or-
        /// <paramref name="endDayTime"/> is invalid
        /// </exception>
        public PassageModeConfig(bool isEnabled, int startDayTime, int endDayTime, IEnumerable<byte> workingDays = null)
            : this(isEnabled, false, startDayTime, endDayTime, workingDays)
        { }

        /// <summary>
        /// Ctor for full working day.
        /// </summary>
        /// <param name="workingDays"></param>
        public PassageModeConfig(bool isEnabled, IEnumerable<byte> workingDays = null)
            : this(isEnabled, true, 0, 0, workingDays)
        { }

        public bool IsEnabled { get; }

        /// <summary>
        /// In minutes.
        /// </summary>
        public int StartDayTime { get; }

        /// <summary>
        /// In minutes.
        /// </summary>
        public int EndDayTime { get; }

        /// <summary>
        /// If true <see cref="StartDayTime"/> and <see cref="EndDayTime"/> is ignored.
        /// </summary>
        public bool IsAllDay { get; }

        /// <summary>
        /// Days when passage mode is enabled. (1 - Monday, 7 - Sunday).
        /// </summary>
        public IList<byte> WorkingDays => _workingDays;
    }
}
