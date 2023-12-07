using Bunit.Rendering;
using MusicBlazorApp.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using Microsoft.Extensions.DependencyInjection;
using AngleSharp.Dom;
using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;

namespace MusicTests.PageTests;

public class ViewItemTests : PageTestContext
{
    [Fact]
    public async Task CanMakeComponent()
    {
        var cut = RenderComponent<ViewItem>(param => param.Add(p => p.ItemId, 1));

        cut.Find("h1").InnerHtml.Should().Be("Loading...");

        cut.WaitForElements("img").Should().HaveCount(1);
    }
}
