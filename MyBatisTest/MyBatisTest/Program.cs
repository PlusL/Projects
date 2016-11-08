using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using IBatisNet.Common;
using IBatisNet.DataAccess;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;


namespace MyBatisTest
{
    public class Products
    {
        public string ProductName;
        public int SupplierID;
        public int CategoryID;
        public string QuantityPerUnit;
        public double UnitPrice;
        public int UnitsInStock;
        public int UnitsOnOrder;
        public int ReorderLevel;
        public bool Discontinued;

        private static SqlMapper mapper = null;
        static Products()
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
        static void Main(string[] argc)
        {
            Products TestProducts = new Products();
            TestProducts.Create(new Products() 
            {
                ProductName = "1",
                SupplierID = 2,
                CategoryID = 3,
                QuantityPerUnit = "4",
                UnitPrice = 5,
                UnitsInStock = 6,
                UnitsOnOrder = 7,
                ReorderLevel = 8,
                Discontinued = true
            }
                );
        }

    }
}
