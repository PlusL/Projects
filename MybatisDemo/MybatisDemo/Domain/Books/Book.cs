using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MybatisDemo.Domain.Exceptions;

namespace MybatisDemo.Domain.Books
{
    public class Book
    {
        private string _Isbn;
        private string _Title;
        private DateTime _SaleDate;
        private int _Price;
        public string Isbn
        {
            get { return _Isbn; }
            set
            {
                if (value.Length != 10)
                {
                    throw new DomainException("ISBN是无效的。");
                }
                _Isbn = value;
            }
        }

        public string IsbnWithHyphen
        {
            get
            {
                return
                    _Isbn.Substring(0, 1) + "-" + _Isbn.Substring(1, 4) + "-" + _Isbn.Substring(5, 4) + "-" +
                    _Isbn.Substring(9, 1);
            }
        }

        public string Title
        {
            get { return _Title; }
            set
            {
                if (value == "")
                {
                    throw new DomainException("标题是无效的。");
                }

                _Title = value;
            }
        }

        public DateTime SaleDate
        {
            get { return _SaleDate; }
            set
            {
                if (DateTime.Compare(value.Date, DateTime.Now) > 0)
                {
                    throw new DomainException("发布日期是无效的。");
                }
                _SaleDate = value;
            }
        }

        public int Price
        {
            get { return _Price; }
            set
            {
                if (value <= 0)
                {
                    throw new DomainException("价格是无效的。");
                }
                _Price = value;
            }
        }
    }
}
