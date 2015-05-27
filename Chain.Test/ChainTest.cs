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
        public void AddHookTest()
        {
            IHook hook = Substitute.For<IHook>();

            Chain chain = new Chain();

            Assert.AreEqual(0, chain.Hooks.Count);

            chain.AddHook(hook);

            Assert.AreEqual(1, chain.Hooks.Count);
            Assert.AreEqual(hook, chain.Hooks[0]);
        }

        [TestMethod]
        public void RunLinksWithEnabledLinkTest()
        {
            ILink link = Substitute.For<Link>();
            IHook hook = Substitute.For<Hook>();

            Chain chain = new Chain();
            chain.AddLink(link);
            chain.AddHook(hook);

            chain.RunLinks();

            hook.Received(1).OnChainStart(chain);
            hook.Received(1).OnLinkStart(link);
            link.Received(1).HookBeforeLink();
            link.Received(1).RunLink();
            link.Received(1).HookAfterLink();
            hook.Received(1).OnLinkEnd(link);
            hook.Received(1).OnChainEnd(chain);
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
