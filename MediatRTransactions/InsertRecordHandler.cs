using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace MediatRTransactions
{
    public class InsertRecordHandler : IRequestHandler<InsertRecordCommand, bool>
    {
        public async Task<bool> Handle(InsertRecordCommand request, CancellationToken cancellationToken)
        {
            using (var db1 = new DB1Context())
            {
                db1.Set<Names>().Add(new Names { Name = request.Name, CreatedAt = DateTime.Now });
                await db1.SaveChangesAsync();
                return true;
            }
        }
    }
}
