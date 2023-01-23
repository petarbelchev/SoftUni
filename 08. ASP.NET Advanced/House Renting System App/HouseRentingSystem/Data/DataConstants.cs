namespace HouseRentingSystem.Data
{
    public class DataConstants
    {
        public class Category
        {
            public const int CategoryNameMaxLength = 50;
        }

        public class House
        {
            public const int HouseTitleMaxLength = 50;
            public const int HouseTitleMinLength = 10;

            public const int HouseAddressMaxLength = 150;
            public const int HouseAddressMinLength = 30;

            public const int HouseDescriptionMaxLength = 500;
            public const int HouseDescriptionMinLength = 50;

            public const decimal HousePricePerMonthMaxValue = 2000M;
            public const decimal HousePricePerMonthMinValue = 0M;
        }

        public class Agent
        {
            public const int AgentPhoneNumberMaxLength = 15;
            public const int AgentPhoneNumberMinLength = 7;
        }
    }
}