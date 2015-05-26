using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chain;
using NSubstitute;

namespace Chain.Test
{
    [TestClass]
    public class ChainTest
    {
        [TestMethod]
        public void AddLinkTest()
        {
            ILink link = Substitute.For<ILink>();
            Chain chain = new Chain();

            Assert.AreEqual(0, chain.Links.Count);
            
            chain.AddLink(link);

            Assert.AreEqual(1, chain.Links.Count);
        }
    }
}
