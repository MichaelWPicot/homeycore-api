using HomieCore.Services.Users;
using HomieCore.Services.Groups;
using HomieCore.Services.Tasks;
using HomieCore.Services.GroupTask;
using HomieCore.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
{
    DotNetEnv.Env.Load();
    builder.Services.AddControllers();
    // builder.Services.AddTransient<TaskDataSeed>();
    _ = builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "HomieCorePolicy",
                      policy =>
                      {
                          policy.WithOrigins(Environment.GetEnvironmentVariable("CORS_ALLOWED_ORIGIN"));
                      });
    });
    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IGroupService, GroupService>();
    builder.Services.AddScoped<ITaskService, TaskService>();
    builder.Services.AddScoped<IGroupTaskService, GroupTaskService>();

    builder.Services.AddDbContext<DataContext>(
        o =>o.UseNpgsql(Environment.GetEnvironmentVariable("TASKSDB_CONNECTION_STRING")));
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(x =>
    {
        x.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "HomieCore API",
            Version = "v1"
        });
    });
}

var app = builder.Build();
{
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
}
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();
}
