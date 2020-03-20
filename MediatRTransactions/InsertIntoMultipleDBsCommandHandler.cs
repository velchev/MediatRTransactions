using MediatR;
using System.Threading;
using System.Threading.Tasks;


namespace MediatRTransactions
{
    public class InsertIntoMultipleDBsCommandHandler : IRequestHandler<InsertIntoMultipleDBsCommand, bool>
    {
        private IMediator _mediator;
        public InsertIntoMultipleDBsCommandHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<bool> Handle(InsertIntoMultipleDBsCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new InsertRecordCommand() { Name = request.Name1 });
            await _mediator.Send(new InsertRecordCommand2() { Name = request.Name2 });

            return true;
        }
    }
}
