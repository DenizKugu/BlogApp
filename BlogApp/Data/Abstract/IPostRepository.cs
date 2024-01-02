using BlogApp.Entities;

namespace BlogApp.Data.Abstract
{
	public interface IPostRepository
	{
		IQueryable<Post> Post { get; }

		void CreatePost(Post post);
		void EditPost(Post post, int[] tagIds);
	}
}
