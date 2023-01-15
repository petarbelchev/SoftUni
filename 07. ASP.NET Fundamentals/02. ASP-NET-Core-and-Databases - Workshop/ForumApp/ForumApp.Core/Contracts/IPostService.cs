using ForumApp.Models.ViewModels;

namespace ForumApp.Core.Contracts
{
	public interface IPostService
	{
		Task AddPost(PostFormModel model);

		Task DeletePostById(int postId);

		Task EditPost(int id, PostFormModel model);

		Task<IEnumerable<PostViewModel>> GetAllPosts();

		Task<PostFormModel> GetPostById(int id);
	}
}
