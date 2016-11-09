using System;
using System.Collections.Generic;
using System.Text;
using DataManageBDC.Domain.Exceptions;

namespace DataManageBDC.Domain.GTZYs
{
    public class GTZY
    {
        private string _Bsm;
        private string _Ywh;
        private string _Ysdm;
        private string _Fzry;
        public string Bsm
        {
            get { return _Bsm; }
            set
            {
                if (value == "")
                {
                    throw new DomainException("标识码是无效的。");
                }
                _Bsm = value;
            }
        }

        public string Ywh
        {
            get { return _Ywh; }
            set
            {
                if (value == "")
                {
                    throw new DomainException("业务号是无效的。");
                }

                _Ywh = value;
            }
        }

        public string Ysdm
        {
            get { return _Ysdm; }
            set
            {
                if (value == "")
                {
                    throw new DomainException("约束代码是无效的。");
                }
                _Ysdm = value;
            }
        }

        public string Fzry
        {
            get { return _Fzry; }
            set
            {
                if (value == "")
                {
                    throw new DomainException("fazhengrenyuan是无效的。");
                }
                _Fzry = value;
            }
        }
    }
}
