using MediatR;


namespace MediatRTransactions
{
    public class InsertRecordCommand : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
