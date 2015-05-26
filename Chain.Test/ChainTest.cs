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

        [TestMethod]
        public void RunLinksWithEnabledLinkTest()
        {
            ILink link = Substitute.For<Link>();

            Chain chain = new Chain();
            chain.AddLink(link);

            chain.RunLinks();

            link.Received(1).HookBeforeLink();
            link.Received(1).RunLink();
            link.Received(1).HookAfterLink();
        }

        [TestMethod]
        public void RunLinksWithDisabledLinkTest()
        {
            ILink link = Substitute.For<Link>();

            link.IsEnabled = false;
            Chain chain = new Chain();

            chain.AddLink(link);

            chain.RunLinks();

            link.DidNotReceive().HookBeforeLink();
            link.DidNotReceive().RunLink();
            link.DidNotReceive().HookAfterLink();
        }

        [TestMethod]
        public void LoopLinksTest()
        {
            ILink link = Substitute.For<Link>();
            Chain chain = new Chain();

            chain.AddLink(link);

            chain.LoopLinks(3);

            link.Received(3).HookBeforeLink();
            link.Received(3).RunLink();
            link.Received(3).RunLink();
        }
    }
}
