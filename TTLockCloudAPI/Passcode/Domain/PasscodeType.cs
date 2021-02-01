namespace OrbitaTech.TTLock
{
    public enum PasscodeType : byte
    {
        /// <summary>
        /// Code only valid for once within 6 hours from the Start Time.
        /// </summary>
        OneTime = 1,

        /// <summary>
        /// Code must be used at least once within 24 Hours after the Start Time, Or it will be invalidated
        /// </summary>
        Permanent,

        /// <summary>
        /// Code must be used at least once within 24 Hours after the Start Time, Or it will be invalidated.
        /// </summary>
        Periodical,

        /// <summary>
        /// Code will delete all the other codes.
        /// </summary>
        Deletion,

        /// <summary>
        /// Code is valid during the time period at the weekend.
        /// </summary>
        WeekendCyclic,

        /// <summary>
        /// Code is valid during the time period everyday.
        /// </summary>
        DailyCyclic,

        /// <summary>
        /// Code is valid during the time period on workdays.
        /// </summary>
        WorkdayCyclic,

        /// <summary>
        /// Code is valid during the time period on Mondays.
        /// </summary>
        MondayCyclic,

        /// <summary>
        /// Code is valid during the time period on Tuesdays.
        /// </summary>
        TuesdayCyclic,

        /// <summary>
        /// Code is valid during the time period on Wednesdays.
        /// </summary>
        WednesdayCyclic,

        /// <summary>
        /// Code is valid during the time period on Thursdays.
        /// </summary>
        ThursdayCyclic,

        /// <summary>
        /// Code is valid during the time period on Fridays.
        /// </summary>
        FridayCyclic,

        /// <summary>
        /// Code is valid during the time period on Saturdays.
        /// </summary>
        SaturdayCyclic,

        /// <summary>
        /// Code is valid during the time period on Sundays.
        /// </summary>
        SundayCyclic,
    }
}
