// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Configuration;
using System.Reflection;

var configBuilder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddUserSecrets(Assembly.GetExecutingAssembly(), true, true)
    .AddEnvironmentVariables();

var val = configBuilder.Build()["secretName"];

Console.WriteLine($"Hello, World! New value is: {val}");
