using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace MediatRTransactions
{
    public class InsertRecordHandler21 : IRequestHandler<InsertRecordCommand21, bool>
    {
        private readonly IDbContext21 dbContext21;

        public InsertRecordHandler21(IDbContext21 dbContext21)
        {
            this.dbContext21 = dbContext21;
        }
        public async Task<bool> Handle(InsertRecordCommand21 request, CancellationToken cancellationToken)
        {
            dbContext21.Names.Add(new Names { Name = request.Name, CreatedAt = DateTime.Now });
            await dbContext21.SaveChangesAsync(cancellationToken);
            
            return true;
        }
    }
}
