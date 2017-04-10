using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoDemoApp.Services;
using System.Threading.Tasks;
using System.Linq;

namespace DemoDemoApp.Test
{
    [TestClass]
    public class MockDataStoreTest
    {
        [TestMethod]
        public async Task InitializeTest()
        {
            var target = new MockDataStore();
            Assert.AreEqual(6, (await target.GetItemsAsync()).Count());

            var item = (await target.GetItemsAsync()).First();
            await target.DeleteItemAsync(item);
            Assert.AreEqual(5, (await target.GetItemsAsync()).Count());
        }
    }
}
