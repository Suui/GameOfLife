using System;
using System.IO;
using FluentAssertions;
using Nancy.Testing;
using Nancy.Testing.Fakes;
using NUnit.Framework;
using WebDisplay;


/* TODO
	
*/

namespace WebDisplayTest
{
	[TestFixture]
	class GameModuleShould
	{
		public Browser Browser { get; set; }

		[SetUp]
		public void GivenABrowserForTheGameModule()
		{
			var solutionPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\"));
			FakeRootPathProvider.RootPath = solutionPath + @"WebDisplay\Views";
			Browser = new Browser(with =>
			{
				with.Module<GameModule>();
				with.RootPathProvider<FakeRootPathProvider>();
			});
		}

		[Test]
		public void display_the_game_of_life_page()
		{
			Browser.Get("game").Body.AsString().Should().Contain("<title>Game of Life</title>");
		}
	}
}
