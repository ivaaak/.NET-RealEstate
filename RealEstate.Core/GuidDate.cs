using System.ComponentModel;

namespace RealEstate.Core
{
    [TypeConverter(typeof(GuidDateTypeConverter))]
    public sealed class GuidDate : IEquatable<GuidDate>
    {
        public string Id { get; }
        public Guid Guid { get; }
        public Date Date { get; }

        public GuidDate(string guidDate)
        {
            if (string.IsNullOrWhiteSpace(guidDate) == true) throw new ArgumentException($"Invalid {nameof(guidDate)}");

            string[] splitResult = guidDate.Split('|');

            if (splitResult.Length != 2) throw new ArgumentException($"Invalid {nameof(guidDate)}");

            if (Guid.TryParse(splitResult[0], out Guid guid) == false || guid == Guid.Empty)
            {
                throw new ArgumentException($"Invalid {nameof(guid)} {guid}");
            }

            if (DateTime.TryParse(splitResult[1], out DateTime date) == false)
            {
                throw new ArgumentException($"Invalid {nameof(date)} {splitResult[1]}");
            }

            Id = guidDate;
            Guid = guid;
            Date = new Date(date);
        }

        public GuidDate(Guid guid, DateTime dateTime)
        {
            var date = new Date(dateTime);
            var guidDate = new GuidDate($"{guid}|{date.ToString()}");

            Id = guidDate.Id;
            Guid = guidDate.Guid;
            Date = guidDate.Date;
        }

        public GuidDate(Guid guid, Date date)
        {
            Id = $"{guid}|{date.ToString()}";
            Guid = guid;
            Date = date;
        }

        public GuidDate(Guid guid, string date)
        {
            var guidDate = new GuidDate(guid, Convert.ToDateTime(date));

            Id = guidDate.Id;
            Guid = guidDate.Guid;
            Date = guidDate.Date;
        }

        public override string ToString() => Id;

        public static bool TryParse(string id, out GuidDate guidDate)
        {
            guidDate = null;

            try
            {
                var aci = new GuidDate(id);
                guidDate = aci;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Equals(GuidDate other)
            => other != null && Id == other.Id;
    }
}
