using System;

namespace AssignmentDotStark.Models
{
    public static class General
    {
        public static string GetISO8601Format()
        {
            return DateTime.Now.Date.ToUniversalTime().ToString("yyyyMMddTHHmmssfffZ");
        }
    }
}
