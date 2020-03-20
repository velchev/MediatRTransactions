using MediatR;

namespace MediatRTransactions
{
    public class InsertRecordCommand21 : IRequest<bool>
    {
        public string Name { get; set; }
    }
}