﻿namespace HouseRentingSystem.Data
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

            public const double HousePricePerMonthMaxValue = 2000.00;
            public const double HousePricePerMonthMinValue = 0.00;
        }

        public class Agent
        {
            public const int AgentPhoneNumberMaxLength = 15;
            public const int AgentPhoneNumberMinLength = 7;
        }

        public class User
        {
            public const int UserFirstNameMaxLength = 12;
            public const int UserFirstNameMinLength = 1;

            public const int UserLastNameMaxLength = 15;
            public const int UserLastNameMinLength = 3;
        }
    }
}