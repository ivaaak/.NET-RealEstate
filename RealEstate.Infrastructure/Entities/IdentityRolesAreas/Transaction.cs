using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RealEstate.Infrastructure.Entities.IdentityRolesAreas
{
    public class Transaction : AzureDocumentBase
    {
        public Transaction() { }

        [JsonConstructor]
        public Transaction(string etag, long timestamp) : base(etag, timestamp) { }

        [JsonProperty(PropertyName = "id")]
        public Guid TransactionId { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "tenantId")]
        public Guid TenantId { get; set; }

        [JsonProperty(PropertyName = "accountId")]
        public Guid AccountId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal Amount { get; set; }

        //[JsonProperty(PropertyName = "currencyCode")]
        //public IsoCurrencyCode CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "categoryId")]
        public string CategoryId { get; set; }

        //[JsonProperty(PropertyName = "expenseCategory")]
        //public ExpenseCategory ExpenseCategory { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        /// <summary>
        /// Transaction Identifer from Plaid
        /// </summary>
        [JsonProperty(PropertyName = "plaidTransactionId")]
        public string PlaidTransactionId { get; set; }

        /// <summary>
        /// Pending Transaction Identifer from Plaid
        /// </summary>
        [JsonProperty(PropertyName = "plaidPendingId")]
        public string PlaidPendingId { get; set; }

        [JsonProperty(PropertyName = "mergedDate")]
        public DateTime? MergedDate { get; set; }

        [JsonProperty(PropertyName = "verifiedDate")]
        public DateTime? VerifiedDate { get; set; }
    }

    public static class TransactionExtension
    {
        public static TransactionState GetState(this Transaction transaction)
        {
            if (transaction == null) return TransactionState.None;
            if (transaction.VerifiedDate.HasValue == true) return TransactionState.Verified;
            if (transaction.MergedDate.HasValue == true) return TransactionState.Merged;
            if (String.IsNullOrEmpty(transaction.PlaidTransactionId) == false) return TransactionState.Settled;
            else return TransactionState.Pending;
        }
    }

    /// <summary>
    /// Transaction States
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TransactionState
    {
        None,

        Pending,

        Settled,

        Merged,

        Verified,
    }
}
