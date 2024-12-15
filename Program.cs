using tuontaAPI.Services;
using tuontaAPI.Repositories;
using tuontaAPI;
using Microsoft.EntityFrameworkCore;
using tuontaAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddTransient<IProfileInfoService, ProfileInfoService>();
builder.Services.AddScoped<IProfileInfoRepository, ProfileInfoRepository>();

builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddTransient<IChatService, ChatService>();

builder.Services.AddScoped<IChatItemRepository, ChatItemRepository>();
builder.Services.AddTransient<IChatItemService, ChatItemService>();

builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddTransient<IMatchService, MatchService>();


builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
builder.Services.AddTransient<INotificationService, NotificationService>();



builder.Services.AddDbContext<TuontaDbContext>(
    db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
