namespace RealEstate.Shared
{
    public static class GlobalConstants
    {
        #region API Keys
        public const string STRIPE_API_KEY = "";
        public const string CURRENCY_API_KEY = "";
        public const string CRAFTMYPDF_API_KEY = "";
        public const string ZILLOW_API_KEY = "";
        #endregion

        #region Environments
        public const string ENV_LOCAL = "Local";
        public const string ENV_DEVELOPMENT = "Development";
        public const string ENV_PRODUCTION = "Production";
        #endregion

        #region Date Formats
        public const string DATE_FORMAT = @"dd/MM/yyyy";
        public const string DATE_HOUR_FORMAT = @"dd/MM/yyyy HH:mm";
        public const string DATEPICKER_DATE_FORMAT = "yyyy-MM-dd";
        public const string DATETIME_PICKER_FORMAT = "yyyy-MM-ddTHH:mm";
        #endregion

        #region Root admin credentials
        public const string ADMIN_USERNAME = "admin";
        public const string ADMIN_PASSWORD = "Password!@#$%";
        public const string ADMIN_EMAIL = "admin@admin.com";
        #endregion

        #region Exception messages
        public const string ERROR_OCCURED_MSG = "An error has occured!";
        public const string ENTITY_ALREADY_DELETED_MSG = "Entity is already deleted.";
        public const string VALIDATION_EXCEPTION_BASE_MSG = "One or more validation failures have occurred.";
        #endregion

        #region Notifications
        public const string CREATED_SUCCESSFULLY_MSG = "has been created successfully!";
        public const string DELETED_SUCCESSFULLY_MSG = "has been deleted successfully!";
        public const string MODIFIED_SUCCESSFULLY_MSG = "has been modified successfully!";
        #endregion

        #region Microservices Naming Scheme
        public const string API_GATEWAY = "API Gateway";
        public const string CLIENTS = "Clients";
        public const string CONTRACTS = "Contracts";
        public const string ESTATES = "Estates";
        public const string EXTERNAL = "External APIs";
        public const string LISTINGS = "Listings";
        public const string MESSAGING = "Messaging";
        public const string UTILITIES = "Utilities";
        #endregion
    }
}
