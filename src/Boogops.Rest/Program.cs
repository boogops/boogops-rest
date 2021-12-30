using Boogops.Core.Extensions.DependencyInjection;
using Boogops.Rest.Configuration;
using Boogops.Stores.MongoDB;
using Boogops.Stores.MongoDB.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(BoogopsProfile));
builder.Services.AddBoogopsManager<ThingDef>()
    .AddMongoStore(o =>
    {
        o.ConnectionString = builder.Configuration["mongodb:connection_string"];
        o.Database = builder.Configuration["mongodb:database"];
    });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();