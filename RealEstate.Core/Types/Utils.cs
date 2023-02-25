using System;

namespace RealEstate.Core.Types
{
    public sealed class Utils
    {
        /// <summary>
        /// Gets the current <see cref="DateTime"/> in the timeZone
        /// </summary>
        /// <param name="timeZone"></param>
        /// <returns></returns>
        public static DateTime GetTimeZoneNow(string timeZone)
            => TimeZoneInfo.ConvertTimeFromUtc(
                DateTime.UtcNow,
                TimeZoneInfo.FindSystemTimeZoneById(timeZone));
    }
}
