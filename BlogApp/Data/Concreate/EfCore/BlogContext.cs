using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concreate.EfCore
{
	public class BlogContext:DbContext
	{
		public BlogContext(DbContextOptions<BlogContext> options):base(options)
		{

		}

		public DbSet<Post> Posts  => Set<Post>();
		public DbSet<Comment> Comments => Set<Comment>();
		public DbSet<User> Users => Set<User>();
		public DbSet<Tag> Tags => Set<Tag>();



		//protected override void OnModelCreating(ModelBuilder builder)
		//{
		//	//builder.Entity<Comment>()
		//	//  .HasOne(c => c.Post)
		//	//  .WithMany(p => p.Comments)
		//	//  .HasForeignKey(c => c.PostId)
		//	//  .OnDelete(DeleteBehavior.Cascade);
		//	//builder.Entity<Comment>()
		//	//  .HasOne(c => c.User)
		//	//  .WithMany(u => u.Comments)
		//	//  .HasForeignKey(c => c.UserId)
		//	//  .OnDelete(DeleteBehavior.Cascade);

		//	//builder.Entity<Comment>()
		//	//	.HasKey(x => new { x.UserId, x.PostId });
		//	//builder.Entity<Comment>()
		//	//	.HasOne(x=>x.User)
		//	//	.WithMany(j=>j.Comments)
		//	//	.HasForeignKey(x=>x.UserId)
		//	//	.OnDelete(DeleteBehavior.NoAction);
		//	//builder.Entity<Comment>()
		//	//	.HasOne(x=>x.Post)
		//	//	.WithMany(j=>j.Comments)
		//	//	.HasForeignKey(x=> x.PostId)
		//	//	.OnDelete(DeleteBehavior.NoAction);


		//	builder.Entity<Comment>()
		//		.HasKey(x => new { x.UserId, x.PostId });
		//	builder.Entity<Comment>()
		//		.HasOne(x => x.User)
		//		.WithMany(x => x.Comments)
		//		.HasForeignKey(x => x.UserId)
		//		.OnDelete(DeleteBehavior.ClientSetNull);
		//	builder.Entity<Comment>()
		//		.HasOne(x => x.Post)
		//		.WithMany(x => x.Comments)
		//		.HasForeignKey(x => x.PostId)
		//		.OnDelete(DeleteBehavior.ClientSetNull);



		//}
	}

	
}
