using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace MediatRTransactions.Tests
{
    public class TransactionBehaviorTests : IDisposable
    {
        private readonly IWebHost _builder;
        private readonly IServiceScope _scope;
        private readonly IMediator _mediator;
        private readonly DB1Context _context;
        private readonly DB2Context _context2;

        public TransactionBehaviorTests()
        {
            _builder = WebHost.CreateDefaultBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseStartup<Startup>()
                .Build();

            // Creates the dependency injection scope.
            _scope = _builder.Services.CreateScope();

            // Dependency injection variables
            _mediator = _scope.ServiceProvider.GetRequiredService<IMediator>();

            // Get DbContext
            _context = _scope.ServiceProvider.GetRequiredService<DB1Context>();
            _context2 = _scope.ServiceProvider.GetRequiredService<DB2Context>();
        }

        [Fact]
        public async Task AAA()
        {
            try
            {
                //var result =  await _mediator.Send(new InsertRecordCommand{ Name = "fiko" });
                //var result2 = await _mediator.Send(new InsertRecordCommand2 { Name = "fiko2" });
                var result = await _mediator.Send(new InsertIntoMultipleDBsCommand { Name1 = "Lyubomir1", Name2 = "Lyubomir2" });
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
        }

        public void Dispose()
        {
        }
    }
}