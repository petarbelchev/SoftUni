﻿using HouseRentingSystem.Data;

namespace HouseRentingSystem.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HouseRentingDbContext data;

        public UserService(HouseRentingDbContext data)
            => this.data = data;

        public string UserFullName(string userId)
        {
            var user = data.Users.Find(userId);

            return user?.FirstName + " " + user?.LastName;
        }
    }
}
