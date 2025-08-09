using Amazon.S3;
using AutoMapper;
using Project_Backend_2024;
using Project_Backend_2024.Facade.Interfaces;
using Project_Backend_2024.Services;
using Project_Backend_2024.Services.Configurations;
using Project_Backend_2024.Services.Utils;
using Project_Backend_2024.Services.Utils;
using Project_Backend_2024.StartupFolder;

var builder = WebApplication.CreateBuilder(args);
builder.ConfigureSerilog();

builder.Services.ConfigureApp(builder.Configuration);
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.Configure<GithubSettings>(builder.Configuration.GetSection("GithubSettings"));
builder.Services.Configure<S3ClientConfiguration>(builder.Configuration.GetSection("S3Settings"));
builder.Services.AddSingleton<IEmailService, SendGridEmailService>();
builder.Logging.AddConsole();


builder.Services.AddSingleton<IAmazonS3>(sp => new AmazonS3Client(
    builder.Configuration["S3Settings:AccessKey"],
    builder.Configuration["S3Settings:SecretKey"],
    Amazon.RegionEndpoint.GetBySystemName(builder.Configuration["S3Settings:Region"])));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddSignalR();

Console.WriteLine("App has started!!!");

var app = builder.Build();
app.UseCors(policy => policy.WithOrigins("https://bitasmbl.com",
        "https://www.bitasmbl.com", "http://localhost:5173", "http://192.168.100.3:5173",
        "https://bitasmbl-frontend.eu.ngrok.io")
    .AllowAnyMethod().AllowCredentials().AllowAnyHeader());

app.UseCors();
app.UseWebSockets();
app.AddMiddleWare();

app.MapHub<ProjectsHub>("/projects-hub");
app.MapHub<ChatHub>("/chat-hub");
app.Run();
