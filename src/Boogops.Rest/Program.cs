using Boogops.Rest.Configuration;

var builder = WebApplication.CreateBuilder(args);

// var connectionString = builder.Configuration.GetConnectionString("boogops");
// builder.Services.AddDbContext<BoogopsDbContext>(options =>
//     options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(BoogopsProfile));

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