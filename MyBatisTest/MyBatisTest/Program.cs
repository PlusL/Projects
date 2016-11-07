using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace MyBatisTest
{
    class Program
    {
         private static SqlMapper mapper = null;
        static Program()
        {
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
 
            mapper = builder.Configure("SqlMap.config") as SqlMapper;
        }
 
        public int Count()
        {
            int result = mapper.QueryForObject<int>("selectCount", null);
            return result;
        }
 
        public bool Create(Products product)
        {
            int id = (int)mapper.Insert("InsertProduct", product);
            return id > 0;
        }
 
        public Products Select(int productid)
        {
            Products product = mapper.QueryForObject<Products>("SelectByProductId", productid);
            return product;
        }
 
        public IList<Products> SelectAll()
        {
            var result = mapper.QueryForList<Products>("SelectByProductId", null);
            return result;
        }
 
        public bool Update(Products product)
        {
            var result = mapper.Update("DeleteProduct", product);
            return result > 0;
        }
 
        public bool Delete(Products product)
        {
            var result = mapper.Delete("DeleteProduct", product);
            return result > 0;
        }

    }
}
