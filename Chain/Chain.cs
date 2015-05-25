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
        void LoopLinks();
        void RunLinks();
    }

    public class Chain : IChain
    {
        private IList<ILink> _Links;

        public Chain()
        {

        }

        public IList<ILink> Links
        {
            get { throw new NotImplementedException(); }
        }

        public void ConnectAllLinks()
        {
            throw new NotImplementedException();
        }

        public void LoopLinks()
        {
            throw new NotImplementedException();
        }

        public void RunLinks()
        {
            throw new NotImplementedException();
        }
    }
}
