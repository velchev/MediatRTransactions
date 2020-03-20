using MediatR;


namespace MediatRTransactions
{
    public class InsertIntoMultipleDBsCommand : IRequest<bool>
    {
        public string Name1 { get; set; }
        public string Name2 { get; set; }
    }
}
