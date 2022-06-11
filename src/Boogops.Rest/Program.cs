using Boogops.Core.Extensions.DependencyInjection;
using Boogops.MongoDbCore;
using Boogops.MongoDbCore.Extensions.DependencyInjection;
using Boogops.Rest.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(typeof(BoogopsProfile));
builder.Services.AddBoogopsManager<ThingDef>()
    .AddMongoStore(o =>
    {
        o.ConnectionString = builder.Configuration["mongodb:connection_string"];
        o.Database = builder.Configuration["mongodb:database"];
    });
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();