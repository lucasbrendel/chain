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

    public class Link : ILink
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

        public LinkResult Result
        {
            get { throw new NotImplementedException(); }
        }

        public void RunLink()
        {
            throw new NotImplementedException();
        }


        public void HookBeforeLink()
        {
            throw new NotImplementedException();
        }

        public void HookAfterLink()
        {
            throw new NotImplementedException();
        }
    }
}
