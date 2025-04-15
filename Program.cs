// Copyright (c) 2025 LLCode
// 
// Licensed under a Commercial License.
// You may not modify, distribute, or sublicense without prior written permission.
// See LICENSE.txt for more details.

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Yarp.ReverseProxy.Configuration;

var builder = WebApplication.CreateBuilder(args);
//Add controllers
builder.Services.AddControllers();

// Add YARP Reverse Proxy
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.WebHost.UseUrls("http://0.0.0.0:5050");
var app = builder.Build();

// Enable routing
app.UseRouting();

// Enable Reverse Proxy
app.MapReverseProxy();

app.UseAuthorization();

app.MapControllers();

app.Run();
