using System;

namespace RealEstate.Core.Types
{
    public struct UnixTime
    {
        private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private readonly long unixTime;

        public UnixTime(long unixTime)
        {
            this.unixTime = unixTime;
        }

        public DateTime GetUtcDateTime()
        {
            return epoch.AddSeconds(unixTime);
        }
    }
}
