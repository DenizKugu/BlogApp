using BlogApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concreate.EfCore
{
	public class TestVerileri
	{
		public static void TestVerileriEkle(IApplicationBuilder app)
		{

			var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

			if(context != null )
			{
				if(context.Database.GetPendingMigrations().Any())
				{
					context.Database.Migrate();

                }
				if(!context.Tags.Any())
				{
					context.Tags.AddRange(
							new Tag { Text = "C# MVC Core 7.0" ,Url="csharp-mvc-core", Color=TagColors.success},
							new Tag { Text = "Django",Url="django-dersleri", Color = TagColors.warning },
							new Tag { Text = "Flutter", Url="flutter-derseleri", Color = TagColors.danger },
							new Tag { Text = "Full Stack",Url="full-stack", Color = TagColors.secondary }
						);
					context.SaveChanges();
				}
				if(!context.Users.Any())
				{
					context.Users.AddRange(
						new User { UserName="pancarahmet",Name="Recep Ahmet Pancar",Email="pancarahmet@gmail.com",Password="123456", Image="p1.jpg"},
						new User { UserName="deniz",Name="Deniz Kugu",Email="deniz@gmail.com",Password="123456", Image="p2.jpg"},
						new User { UserName="ibrahim",Name="İbrahim Aydin",Email="ibrahim@gmail.com",Password="123456", Image="p3.png"}
						);
					context.SaveChanges();
				}
				if (!context.Posts.Any())
				{
					context.Posts.AddRange(
						new Post
						{
							Title="Asp .Net Core 7.0",
							Description="Asp .Net Core 7.0",
							Content="Asp dersleri",
							IsActive=true,
							Image="1.jpg",
							Url="aspnet-core-7-0",
							PublishTime=DateTime.Now.AddDays(-5),
							UserId=1,
							Tags=context.Tags.Take(3).ToList(),
							Comments=new List<Comment>
							{
								new Comment{ Text="İyi bir kurstu",PublishedOn=DateTime.Now.AddDays(-5),UserId=1},
								new Comment{ Text="Gelişimime çok katkısı oldu",PublishedOn=DateTime.Now,UserId = 2}
							},
						},
						new Post
						{
							Title = "Php",
                            Description = "Php",
							Content = "Php dersleri",
							IsActive = true,
							Image = "2.jpg",
							Url = "php",
							PublishTime = DateTime.Now.AddDays(-3),
							UserId = 2,
							Tags = context.Tags.Take(2).ToList(),
						},
						new Post
						{
							Title = "Flutter",
                            Description = "Flutter",
							Content = "Flutter dersleri",
							IsActive = true,
							Image = "3.jpg",
							Url = "flutter",
							PublishTime = DateTime.Now.AddDays(-10),
							UserId = 3,
							Tags = context.Tags.Take(1).ToList(),
						},
						new Post
						{
							Title = "Django",
                            Description = "Django",
							Content = "Django dersleri",
							IsActive = true,
							Image = "2.jpg",
							Url = "django",
							PublishTime = DateTime.Now.AddDays(-7),
							UserId = 3,
							Tags = context.Tags.Take(4).ToList(),
						},
						new Post
						{
							Title = "C#",
                            Description = "C#",
							Content = "C# dersleri",
							IsActive = true,
							Image = "3.jpg",
							Url = "csharp",
							PublishTime = DateTime.Now.AddDays(-5),
							UserId = 1,
							Tags = context.Tags.Take(3).ToList(),
						}
						);
					context.SaveChanges();
				}
				
			}
		}
	}
}
