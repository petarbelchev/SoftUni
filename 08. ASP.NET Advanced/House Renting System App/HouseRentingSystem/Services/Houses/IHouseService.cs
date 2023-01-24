﻿using HouseRentingSystem.Models;
using HouseRentingSystem.Services.Houses.Models;
using HouseRentingSystem.Services.Models;

namespace HouseRentingSystem.Services.Houses
{
	public interface IHouseService
	{
		IEnumerable<HouseIndexServiceModel> LastThreeHouses();

		IEnumerable<HouseCategoryServiceModel> AllCategories();

		HouseQueryServiceModel All(string? categoryName = null, 
									string? searchTerm = null, 
									HouseSorting sortingValue = HouseSorting.Newest, 
									int currentPage = 1, 
									int housesPerPage = 1);

		IEnumerable<string> AllCategoriesNames();

		bool CategoryExists(int categoryId);

		int Create(string title, string address, string description, 
					string imageUrl, decimal price, int categoryId, int agentId);

		IEnumerable<HouseServiceModel> AllHousesByAgentId(int agentId);

		IEnumerable<HouseServiceModel> AllHousesByUserId(string userId);
	}
}
