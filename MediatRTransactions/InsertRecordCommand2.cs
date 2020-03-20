using MediatR;


namespace MediatRTransactions
{
    public class InsertRecordCommand2 : IRequest<bool>
    {
        public string Name { get; set; }
    }
}
