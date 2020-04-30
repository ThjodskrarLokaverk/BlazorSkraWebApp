using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;
using BlazorSkraApp1.Data;
using BlazorSkraApp1.Services;
using BlazorSkraApp1.Tests;

namespace BlazorSkraApp1.Tests
{
    public class IndexPageTests : 
        IClassFixture<CustomWebApplicationFactory<BlazorSkraApp1.Startup>>
    {

    }
}