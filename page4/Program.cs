using System;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using page4;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();

public partial class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("app");

        // 設定應用程式的配置
        builder.Configuration.AddJsonFile("appsettings.json");
        builder.Configuration.AddJsonFile("appsettings.Development.json", true);

        // 在這裡加入你的 DbContext 配置
        ConfigureDbContext(builder);

        // 設定 DbContext
        builder.Services.AddDbContext<RecordDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("RecordDbContext")));

        // 配置 HTTP Client
        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        await builder.Build().RunAsync();
    }

    private static void ConfigureDbContext(WebAssemblyHostBuilder builder)
    {
        var connection = String.Empty;

        if (builder.HostEnvironment.IsDevelopment())
        {
            builder.Configuration.AddJsonFile("appsettings.Development.json");
            connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
        }
        else
        {
            connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
        }
        builder.Services.AddDbContext<RecordDbContext>(options =>
            options.UseSqlServer(connection));

    }
}



    /*
     * private static void Configure(WebAssemblyHostBuilder builder)
    {
        // 在這裡新增以下端點
        builder.Services.AddScoped<RecordDbContext>();

        builder.Services.AddScoped(sp =>
        {
            var context = sp.GetRequiredService<RecordDbContext>();
            return context.Record.ToList();
        })
        .WithName("GetRecords")
        .WithOpenApi();

        builder.Services.AddScoped(sp =>
        {
            var context = sp.GetRequiredService<RecordDbContext>();
            var record = new Record(); // 根據你的實際需求初始化 Person
            context.Add(Record);
            context.SaveChanges();
        })
        .WithName("CreateRecord")
        .WithOpenApi();
    }

}



        app.MapGet("/Record", (RecordDbContext context) =>
        {
            return context.Person.ToList();
        })
        .WithName("GetRecords")
        .WithOpenApi();

        app.MapPost("/Record", (Record Record, RecordDbContext context) =>
        {
            context.Add(Record);
            context.SaveChanges();
        })
        .WithName("CreateRecord")
        .WithOpenApi();
*/