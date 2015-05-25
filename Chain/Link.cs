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
    }

    public class Link : ILink
    {
        public bool IsEnabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
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
    }
}
