using ForumApp.Core.Contracts;
using ForumApp.Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Core.Services
{
	public class PostService : IPostService
	{
		private readonly IPostRepository repo;

		public PostService(IPostRepository repo)
		{
			this.repo = repo;
		}
	}
}
