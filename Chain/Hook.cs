using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain
{
    public interface IHook
    {
        void OnChainStart(IChain chain);
        void OnChainEnd(IChain chain);
        void OnLinkStart(ILink link);
        void OnLinkEnd(ILink link);
        void OnLinkPass(ILink link);
        void OnLinkFail(ILink link);
        void OnLinkInconclusive(ILink link);
        void OnLinkAborted(ILink link);
    }

    public abstract class Hook : IHook
    {

        public abstract void OnChainStart(IChain chain);

        public abstract void OnChainEnd(IChain chain);

        public abstract void OnLinkStart(ILink link);

        public abstract void OnLinkEnd(ILink link);

        public abstract void OnLinkPass(ILink link);

        public abstract void OnLinkFail(ILink link);

        public abstract void OnLinkInconclusive(ILink link);

        public abstract void OnLinkAborted(ILink link);
    }
}

