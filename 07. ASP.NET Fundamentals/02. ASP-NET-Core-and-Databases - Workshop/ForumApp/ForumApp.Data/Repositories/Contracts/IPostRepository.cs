using ForumApp.Models.DTOs;

namespace ForumApp.Data.Repositories.Contracts
{
	public interface IPostRepository
	{
		Task AddPost(PostDTO postDTO);

		Task DeletePostById(int postId);

		Task EditPost(PostDTO postDTO);

		Task<IEnumerable<PostDTO>> GetAllPosts();

		Task<PostDTO> GetPostById(int id);
	}
}
