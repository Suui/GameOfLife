using Nancy.Testing;
using NUnit.Framework;
using WebDisplay;


namespace WebDisplayTest
{
	public class RootModuleShould
	{
		private Browser Browser { get; set; }

		[SetUp]
		public void GivenABrowserForTheRootModule()
		{
			Browser = new Browser(with => with.Module<RootModule>());
		}

		[Test]
		public void redirect_to_the_game_page()
		{
			Browser.Get("/").ShouldHaveRedirectedTo("/game");
		}
	}
}