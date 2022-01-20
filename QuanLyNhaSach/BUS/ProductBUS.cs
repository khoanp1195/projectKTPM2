using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhaSach.DAO;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach.BUS
{
    class ProductBUS
    {
        ProductDAO dao = new ProductDAO();

        public DataSet GetAllProduct()
        {
            DataSet ds = dao.SelectAllProduct();
            return ds;
        }

        public DataSet GetAllOrigin()
        {
            DataSet ds = dao.SelectAllOrigin();
            return ds;
        }

        public DataSet GetAllCategory()
        {
            DataSet ds = dao.SelectAllCategory();
            return ds;
        }

        public DataSet GetNameCategory()
        {
            DataSet ds = dao.SelectNameCategory();
            return ds;
        }

        public Product GetNameCategory(string codeSP, int id)
        {
            Product product = null;
            SqlDataReader dr = dao.SelectNameCategory(codeSP,id);
            while (dr.Read())
            {
                product = new Product()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Price = Convert.ToDouble(dr["Price"]),
                    Description = (string)dr["Description"],
                    Unit = (string)dr["Unit"],
                    Origin = (string)dr["Origin"],
                    CategoryName = (string)dr["CategoryName"]
                };
            }
            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public List<Category> GetAllCategorys()
        {
            List<Category> categories = new List<Category>();
            SqlDataReader dr = dao.SelectAllAdvancedCategory();
            while (dr.Read())
            {
                Category category = new Category()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = (string)dr["Name"],
                };
                categories.Add(category);
            }
            if (categories != null)
            {
                return categories;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetAllProducts(string keyword)
        {
            List<Product> products = new List<Product>();
            SqlDataReader dr = dao.SelectAllAdvancedProduct(keyword);
            while (dr.Read())
            {
                Product product = new Product()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Price = Convert.ToDouble(dr["Price"]),
                    Description = (string)dr["Description"],
                    Unit = (string)dr["Unit"],
                    Origin = (string)dr["Origin"],
                    CategoryId = Convert.ToInt32(dr["CategoryId"])
                };
                products.Add(product);
            }
            if (products != null)
            {
                return products;
            }
            else
            {
                return null;
            }
        }

        public Product GetProductDetail(string id)
        {
            Product product = null;
            SqlDataReader dr = dao.SelectById(id);
            while (dr.Read())
            {
                product = new Product()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Price = Convert.ToDouble(dr["Price"]),
                    Description = (string)dr["Description"],
                    Unit = (string)dr["Unit"],
                    Origin = (string)dr["Origin"],
                    CategoryId = Convert.ToInt32(dr["CategoryId"])
                };
            }
            if (product != null)
            {
                return product;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetProductsSearch(string keyword)
        {
            List<Product> products = new List<Product>(); ;
            SqlDataReader dr = dao.SelectByKeyWord(keyword);
            while (dr.Read())
            {
                Product product = new Product()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Price = Convert.ToDouble(dr["Price"]),
                    Description = (string)dr["Description"],
                    Unit = (string)dr["Unit"],
                    Origin = (string)dr["Origin"],
                    CategoryId = Convert.ToInt32(dr["CategoryId"])
                };
                products.Add(product);
            }
            if (products != null)
            {
                return products;
            }
            else
            {
                return null;
            }
        }

        public List<Product> GetAllProductsByCategoryId(int id)
        {
            List<Product> products = new List<Product>();
            SqlDataReader dr = dao.SelectProductByCategoryID(id);
            while (dr.Read())
            {
                Product product = new Product()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Price = Convert.ToDouble(dr["Price"]),
                    Description = (string)dr["Description"],
                    Unit = (string)dr["Unit"],
                    Origin = (string)dr["Origin"],
                    CategoryId = Convert.ToInt32(dr["CategoryId"])
                };
                products.Add(product);
            }
            if (products != null)
            {
                return products;
            }
            else
            {
                return null;
            }
        }

        public bool InsertProduct(Product product)
        {
            bool result = dao.Insert(product);
            return result;
        }

        public bool UpdateProduct(Product product,string id)
        {
            bool result = dao.Update(product,id);
            return result;
        }

        public bool DeleteProduct(string id)
        {
            bool result = dao.Delete(id);
            return result;
        }

        public List<Product> SortAsc(string name, string keyword)
        {
            List<Product> products = GetAllProducts(keyword);
            if (name == "Name")
            {
                products = products.OrderBy(x => x.Name).ToList();
            }
            else if (name == "Price")
            {
                products = products.OrderBy(x => x.Price).ToList();
            }
            else if (name == "Description")
            {
                products = products.OrderBy(x => x.Description).ToList();
            }
            else if (name == "Unit")
            {
                products = products.OrderBy(x => x.Unit).ToList();
            }
            else if (name == "Origin")
            {
                products = products.OrderBy(x => x.Origin).ToList();
            }
            else if (name == "CategoryId")
            {
                products = products.OrderBy(x => x.CategoryId).ToList();
            }
            return products;
        }

        public List<Product> SortDesc(string name, string keyword)
        {
            List<Product> products = GetAllProducts(keyword);
            if (name == "Name")
            {
                products = products.OrderByDescending(x => x.Name).ToList();
            }
            else if (name == "Price")
            {
                products = products.OrderByDescending(x => x.Price).ToList();
            }
            else if (name == "Description")
            {
                products = products.OrderByDescending(x => x.Description).ToList();
            }
            else if (name == "Unit")
            {
                products = products.OrderByDescending(x => x.Unit).ToList();
            }
            else if (name == "Origin")
            {
                products = products.OrderByDescending(x => x.Origin).ToList();
            }
            else if (name == "CategoryId")
            {
                products = products.OrderByDescending(x => x.CategoryId).ToList();
            }
            return products;
        }

        public List<Product> FilterOrigin(string origin, string keyword)
        {
            List<Product> products = GetAllProducts(keyword);
            products = products.Where(x => x.Origin == origin).ToList();
            return products;
        }
    }
}
