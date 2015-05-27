using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain
{
    public interface IChain
    {
        IList<ILink> Links { get; }
        IList<IHook> Hooks { get; }
        void LoopLinks(int amountOfLoops);
        void RunLinks();
        void AddLink(ILink link);
        void AddHook(IHook hook);
    }

    public class Chain : IChain
    {
        private IList<ILink> _Links;
        private IList<IHook> _Hooks;

        public Chain()
        {
            _Links = new List<ILink>();
            _Hooks = new List<IHook>();
        }

        public IList<ILink> Links
        {
            get { return _Links; }
        }

        public IList<IHook> Hooks
        {
            get { return _Hooks; }
        }

        public void LoopLinks(int amountOfLoops)
        {
            int i = 0;
            while (i < amountOfLoops)
            {
                i++;
                RunLinks();
            }
        }

        public void RunLinks()
        {
            RunHookBeforeChain();
            foreach (ILink link in _Links)
            {
                if (link.IsEnabled)
                {
                    RunHookStartLink(link);
                    link.HookBeforeLink();
                    link.RunLink();
                    link.HookAfterLink();
                    RunHookAfterLink(link);
                }
            }
            RunHookAfterChain();
        }

        private void RunHookAfterChain()
        {
            foreach(IHook hook in _Hooks)
            {
                hook.OnChainEnd(this);
            }
        }

        private void RunHookAfterLink(ILink link)
        {
            foreach(IHook hook in _Hooks)
            {
                hook.OnLinkEnd(link);
            }
        }

        private void RunHookStartLink(ILink link)
        {
            foreach(IHook hook in _Hooks)
            {
                hook.OnLinkStart(link);
            }
        }

        private void RunHookBeforeChain()
        {
            foreach(IHook hook in _Hooks)
            {
                hook.OnChainStart(this);
            }
        }


        public void AddLink(ILink link)
        {
            _Links.Add(link);
        }

        public void AddHook(IHook hook)
        {
            _Hooks.Add(hook);
        }
    }
}
