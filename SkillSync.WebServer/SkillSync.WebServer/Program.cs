using Microsoft.AspNetCore.Http.Features;
using SkillSync.Chat;
using SkillSync.Notifications;
using SkillSync.WebServer;
using SkillSync.WebServer.Extensions;
using SkillSync.WebServer.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.AddAzureKeyVault();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureCors(builder.Configuration);

builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.ConfigureIdentity();

Dependecies.Inject(builder);

builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(builder.Configuration);

builder.Services.ConfigureLinkedInClient(builder.Configuration);

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");

app.UseStaticFiles();

app.MapHub<ChatHub>("/chat");

app.MapHub<NotificationHub>("/notification");

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
