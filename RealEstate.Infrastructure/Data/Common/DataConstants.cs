namespace RealEstate.Infrastructure.Data.Common
{
    public class DataConstants
    {
        public class User
        {
            public const int FirstNameMinLength = 5;
            public const int FirstNameMaxLength = 200;
            public const int PasswordMinLength = 6;
            public const int PasswordMaxLength = 100;
        }

        public class Property
        {
            public const int TitleMinLength = 2;
            public const int TitleMaxLength = 20;
            public const int DescriptionMinLength = 10;
            public const int YearMinValue = 1800;
            public const int YearMaxValue = 2050;
        }

        public class Category
        {
            public const int NameMaxLength = 25;
        }

        public class Agent
        {
            public const int NameMinLength = 2;
            public const int NameMaxLength = 120;
            public const int PhoneNumberMinLength = 6;
            public const int PhoneNumberMaxLength = 30;
        }
    }
}
