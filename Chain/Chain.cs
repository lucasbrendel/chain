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
        void ConnectAllLinks();
        void LoopLinks(int amountOfLoops);
        void RunLinks();
        void AddLink(ILink link);
    }

    public class Chain : IChain
    {
        private IList<ILink> _Links;

        public Chain()
        {
            _Links = new List<ILink>();
        }

        public IList<ILink> Links
        {
            get { return _Links; }
        }

        public void ConnectAllLinks()
        {
            throw new NotImplementedException();
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
            foreach (ILink link in _Links)
            {
                if(link.IsEnabled)
                {
                    link.HookBeforeLink();
                    link.RunLink();
                    link.HookAfterLink();
                }
            }
        }


        public void AddLink(ILink link)
        {
            _Links.Add(link);
        }
    }
}
