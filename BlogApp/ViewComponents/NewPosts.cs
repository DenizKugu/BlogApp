using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.ViewComponents
{
	public class NewPosts:ViewComponent
	{
		private IPostRepository _postRepository;
		public NewPosts(IPostRepository postRepository) {
			_postRepository = postRepository;
		}

		public IViewComponentResult Invoke()
		{
			return View(_postRepository
				.Post
				.OrderByDescending(p=>p.PublishTime)
				.Take(5)
				.ToList()
				);
		}
	}
}
