using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain
{
    public enum LinkResult
    {
        Unknown,
        Pass,
        Fail,
        Inconclusive,
        Abort
    }

    public interface ILink
    {
        bool IsEnabled { get; set; }
        LinkResult Result { get; }
        void RunLink();
        void HookBeforeLink();
        void HookAfterLink();
    }

    public abstract class Link : ILink
    {
        private bool _IsEnabled;

        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            set
            {
                if(value != _IsEnabled)
                {
                    _IsEnabled = value;
                }
            }
        }

        public Link()
        {
            IsEnabled = true;
        }

        public LinkResult Result
        {
            get { throw new NotImplementedException(); }
        }

        public abstract void RunLink();

        public abstract void HookBeforeLink();

        public abstract void HookAfterLink();
    }
}
