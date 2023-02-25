using System;
using RealEstate.Core.Types;

namespace RealEstate.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static Date ToDate(this DateTime dateTime)
        {
            return new Date(dateTime);
        }
    }
}
