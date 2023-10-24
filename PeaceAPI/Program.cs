using Peace.Application.Factories;
using Peace.Application.Interfaces;
using Peace.Application.Services;
using Peace.Core.Helpers;
using Peace.Core.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<FacebookService>(); 
builder.Services.AddTransient<InstagramService>();
builder.Services.AddTransient<TwitterService>();
builder.Services.AddTransient<GoogleService>();
builder.Services.AddTransient<LinkedinService>();
builder.Services.AddTransient<SocialMediaHandler>();
builder.Services.AddSingleton<ISocialMediaServiceFactory, SocialMediaServiceFactory>();
builder.Services.AddSingleton<IHttpClientWrapper, HttpClientWrapper>();

new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory()) // This line requires the 'using' directive.
    .AddJsonFile("appsettings.json")
    .Build();

builder.Services.AddHttpClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

