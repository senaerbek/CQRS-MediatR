using System;
using System.Collections.Generic;
using System.Linq;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(DataContext context){
            if (!context.Posts.Any())
            {
                var posts = new List<Post> {
                    new Post{
                        Content ="content1",
                        Date = DateTime.Now.AddMonths(-2)
                    },
                    new Post{
                        Content ="content2",
                        Date = DateTime.Now.AddMonths(-2)
                    },
                    new Post{
                        Content ="content3",
                        Date = DateTime.Now.AddMonths(-2)
                    },
                    new Post{
                        Content ="content4",
                        Date = DateTime.Now.AddMonths(-2)
                    },
                    new Post{
                        Content ="content5",
                        Date = DateTime.Now.AddMonths(-2)
                    },
                };

                context.Posts.AddRange(posts);
                context.SaveChanges();
            }
        }
    }
}