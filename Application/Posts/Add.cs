using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Posts
{
    public class Add
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
            public DateTime Date { get; set; }
            public string Content { get; set; }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var post = new Post{
                    Id = request.Id,
                    Content = request.Content,
                    Date = request.Date
                };
                _context.Posts.Add(post);
                var success = await _context.SaveChangesAsync() > 0;
                
                if (success)
                {
                 return Unit.Value;   
                }
                 throw new Exception ("eklenemedi");
            }
        }
    }
}