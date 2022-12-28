using System;

namespace RealEstate.Core
{
    public static class DateTimeExtensions
    {
        public static Date ToDate(this DateTime dateTime)
        {
            return new Date(dateTime);
        }
    }
}
