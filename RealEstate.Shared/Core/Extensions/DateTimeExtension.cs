using System;
using RealEstate.Shared.Core.Types;

namespace RealEstate.Shared.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static Date ToDate(this DateTime dateTime)
        {
            return new Date(dateTime);
        }
    }
}
