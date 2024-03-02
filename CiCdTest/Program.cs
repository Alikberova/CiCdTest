// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using System.Reflection;

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true, true)
    .AddEnvironmentVariables();

var configuration = configBuilder.Build();
var val = configuration["secretName"];
var envVar = Environment.GetEnvironmentVariable("secretName");

Console.WriteLine($"GetEnvironmentVariable is: {envVar}");
Console.WriteLine($"Hello, World! New value is: {val}");
