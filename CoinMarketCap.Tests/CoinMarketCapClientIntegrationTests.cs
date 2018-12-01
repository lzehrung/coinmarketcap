using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoinMarketCap.Tests
{
    [TestClass]
    public class CoinMarketCapClientIntegrationTests
    {
        private CoinMarketCapClient _client;

        [TestInitialize]
        public void Initialize()
        {
            _client = new CoinMarketCapClient("");
        }

        [TestMethod]
        public void GetLatestQuote_GivenIdMap_Succeeds()
        {

        }
    }
}
