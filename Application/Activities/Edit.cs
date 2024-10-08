using Domain;
using MediatR;
using Persistence;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                Activity activityToEdit = await _context.Activities.FindAsync(request.Activity.Id);

                activityToEdit.Title = request.Activity.Title ?? activityToEdit.Title;

                await _context.SaveChangesAsync();
            }
        }
    }
}