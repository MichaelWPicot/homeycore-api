using HomieCore.Services.Users;
using HomieCore.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    DotNetEnv.Env.Load();
    builder.Services.AddControllers();
    // builder.Services.AddTransient<TaskDataSeed>();
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddDbContext<TaskDataContext>(
        o =>o.UseNpgsql(Environment.GetEnvironmentVariable("TASKSDB_CONNECTION_STRING")));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
}

//   if(args.Length==1 && string.Equals(args[0], "seeddata", StringComparison.OrdinalIgnoreCase))
//     {
//         SeedData(app);
//     }
//     static void SeedData(IHost app){
//         var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
//     using var scope = scopedFactory?.CreateScope();
//     var service = scope?.ServiceProvider.GetService<TaskDataSeed>();
//     service?.Seed();
// }