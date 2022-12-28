using RealEstate.Core.Exceptions;
using System.Collections;
using System.Net;

namespace RealEstate.Core.Guards
{
    /// <summary>
    /// A class that throws HttpExceptions upon validation failures
    /// </summary>
    public sealed class HttpValidate
    {
        /// <summary>
        /// Guards against a null or an empty string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        /// <param name="statusCode"></param>
        public static void NotNullOrEmpty(string value, string inputName, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (value == null) throw new HttpException(statusCode, Errors.NullExceptionMessage(value, inputName));
            if (String.IsNullOrWhiteSpace(value) == true) throw new HttpException(statusCode, Errors.InvalidMessage(value, inputName));

        }

        /// <summary>
        /// Guards against a null or an empty string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        /// <param name="statusCode"></param>
        public static void NotNullOrEmpty<T>(IEnumerable<T> value, string inputName, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (value == null) throw new HttpException(statusCode, Errors.NullExceptionMessage(value, inputName));
            if (value.Any() == false) throw new HttpException(statusCode, Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against an empty Guid
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        /// <param name="statusCode"></param>
        public static void NotEmpty(Guid value, string inputName, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (value == Guid.Empty)
                throw new HttpException(statusCode, Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against a null or an empty collection
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        /// <param name="statusCode"></param>
        public static void NotNullOrEmpty(ICollection value, string inputName, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (value == null) throw new HttpException(statusCode, Errors.NullExceptionMessage(value, inputName));
            if (value.Count <= 0) throw new HttpException(statusCode, Errors.InvalidMessage(value, inputName));
        }

        /// <summary>
        /// Guards against a null object
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inputName"></param>
        /// <param name="statusCode"></param>
        public static void NotNull(object value, string inputName, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (value == null) throw new HttpException(statusCode, Errors.NullExceptionMessage(value, inputName));
        }

        /// <summary>
        /// Guards against mismatching strings
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="errorMessage"></param>
        /// <param name="statusCode"></param>
        public static void AreEqual(string a, string b, string errorMessage, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (a != b) throw new HttpException(statusCode, errorMessage);
        }

        /// <summary>
        /// Guards against mismatching Guids
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="errorMessage"></param>
        /// <param name="statusCode"></param>
        public static void AreEqual(Guid a, Guid b, string name, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (a != b) throw new HttpException(statusCode, $"{name} discrepancy: {a}, {b}");
        }

        /// <summary>
        /// Guards against mismatching dates
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="statusCode"></param>
        public static void AreEqual(Date a, Date b, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (a.Equals(b) == false) throw new HttpException(statusCode, $"Date discrepancy: {a}, {b}");
        }

        /// <summary>
        /// Guards against non-existing key in a dictionary
        /// </summary>
        /// <param name="value"></param>
        /// <param name="dictionaryName"></param>
        public static void ContainsKey<K, T>(IDictionary<K, T> value, K key, string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            NotNullOrEmpty(value as ICollection, "Collection");
            if (value.ContainsKey(key) == false) throw new HttpException(statusCode, message);
        }

        public static void ValidDate(Date date, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            ValidDateTime(date.ToString());
        }

        public static void ValidDateTime(string _dateTime, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (DateTime.TryParse(_dateTime, out DateTime dateTime) == false)
            {
                throw new HttpException(statusCode, $"Invalid {nameof(dateTime)} {_dateTime}");
            }
        }

        public static void ValidRange(DateTime startDate, DateTime endDate, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (startDate == DateTime.MinValue) throw new HttpException(statusCode, Errors.InvalidMessage(startDate, nameof(startDate)));
            if (endDate == DateTime.MinValue) throw new HttpException(statusCode, Errors.InvalidMessage(endDate, nameof(endDate)));
            if (startDate > endDate) throw new HttpException(statusCode, $"{nameof(startDate)} cannot be later than {nameof(endDate)}");
        }

        public static void ValidRange(Date startDate, Date endDate, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            NotNull(startDate, nameof(startDate));
            NotNull(endDate, nameof(endDate));
            ValidRange(startDate.ToDateTime(), endDate.ToDateTime(), statusCode);
        }

        public static void ValidRange(string startDate, string endDate, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            ValidDateTime(startDate, statusCode);
            ValidDateTime(endDate, statusCode);
            ValidRange(Convert.ToDateTime(startDate), Convert.ToDateTime(endDate), statusCode);
        }

        /// <summary>
        /// Guards against an invalid accountCatalogId
        /// </summary>
        /// <param name="accountCatalogId"></param>
        /// <param name="statusCode"></param>
        public static void AccountCatalogId(string accountCatalogId, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            if (GuidDate.TryParse(accountCatalogId, out GuidDate id) == false)
                throw new HttpException(statusCode, Errors.InvalidMessage(accountCatalogId, nameof(accountCatalogId)));
        }
    }
}
