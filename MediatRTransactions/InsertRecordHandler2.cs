using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace MediatRTransactions
{
    public class InsertRecordHandler2 : IRequestHandler<InsertRecordCommand2, bool>
    {
        public async Task<bool> Handle(InsertRecordCommand2 request, CancellationToken cancellationToken)
        {
            using (var db2 = new DB2Context())
            {
                db2.Set<Names>().Add(new Names { Name = request.Name, CreatedAt = DateTime.Now });
                await db2.SaveChangesAsync();
                return true;
            }
        }
    }
}
