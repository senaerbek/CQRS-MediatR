using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public class PostDetails
    {
        public class Query : IRequest<Post>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Post>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Post> Handle(Query request, CancellationToken cancellationToken)
            {
                var post = await _context.Posts.FindAsync(request.Id);
                return post;
            }
        }
    }
}