using MediatR;
using MediatRTransactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // all tests
        services.AddDbContext<DB1Context>();
        services.AddDbContext<DB2Context>();
        services.AddDbContext<IDbContext1, DB1Context>();
        services.AddDbContext<IDbContext2, DB2Context>();
        services.AddDbContext<IDbContext21, DB21Context>();

        // User permission
        services.AddScoped<IRequestHandler<InsertRecordCommand, bool>, InsertRecordHandler>();    
        services.AddScoped<IRequestHandler<InsertRecordCommand2, bool>, InsertRecordHandler2>();
        services.AddScoped<IRequestHandler<InsertRecordCommand21, bool>, InsertRecordHandler21>();
        services.AddScoped<IRequestHandler<InsertIntoMultipleDBsCommand, bool>, InsertIntoMultipleDBsCommandHandler>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(TransactionBehavior<,>));

        // mediator
        services.AddMediatR(typeof(Startup));
    }

    public void Configure(IApplicationBuilder app)
    {
    }
}
