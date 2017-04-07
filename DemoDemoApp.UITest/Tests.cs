using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DemoDemoApp.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.Tap(x => x.Marked("ItemsListView").Child(0).Child(0));
            app.Screenshot("Detail page.");
        }

        [Test]
        public void AddItem()
        {
            app.Screenshot("First screen.");
            app.Tap(x => x.Marked("toolbar").Child(0));
            app.Screenshot("Item add screen.");
            app.EnterText("EntryText", "Test text");
            app.EnterText("EditorDescription", "Test description");
            app.Screenshot("Enter data.");
            app.Tap(x => x.Marked("toolbar").Child(0));
            app.Screenshot("Item added");
        }

        [Test]
        public void Repl()
        {
            app.Repl();
        }
    }
}

