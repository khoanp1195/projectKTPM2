using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach.DAO
{
    class ProductDAO
    {
        private DBHelper dbHelper = new DBHelper();

        public ProductDAO()
        {
            dbHelper.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public DataSet SelectAllProduct()
        {
            string sql = "SELECT * FROM Product";
            string taleName = "Product";
            DataSet ds = dbHelper.executeSelect(sql,taleName);
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public DataSet SelectAllOrigin()
        {
            string sql = "SELECT DISTINCT Origin FROM Product";
            string taleName = "Origin";
            DataSet ds = dbHelper.executeSelect(sql, taleName);
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public DataSet SelectAllCategory()
        {
            string sql = "SELECT * FROM Category";
            string tableName = "Category";
            DataSet ds = dbHelper.executeSelect(sql, tableName);
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public DataSet SelectNameCategory()
        {
            string sql = "SELECT P.Id, P.Name, P.Price, P.Description, P.Unit, P.Origin, C.Name AS 'CategoryName' FROM Product P, Category C WHERE P.CategoryId = C.Id";
            string taleName = "ProductCategoryName";
            DataSet ds = dbHelper.executeSelect(sql, taleName);
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectNameCategory(string codeSP,int id)
        {
            string sql = "SELECT P.Id, P.Name, P.Price, P.Description, P.Unit, P.Origin, C.Name AS 'CategoryName' FROM Product P, Category C WHERE P.CategoryId = C.Id AND (P.CategoryId="+id+" AND P.Id='"+codeSP+"')";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectAllAdvancedCategory()
        {
            string sql = "SELECT * FROM Category";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectAllAdvancedProduct(string keyword)
        {
            string sql = "SELECT * FROM Product WHERE Name LIKE  N'%" + keyword + "%'";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectById(string id)
        {
            string sql = "SELECT * FROM Product WHERE Id = '"+id+"'";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectByKeyWord(string keyword)
        {
            string sql = "SELECT * FROM Product WHERE Name LIKE  N'%" + keyword + "%'";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectProductByCategoryID(int id)
        {
            string sql = "SELECT * FROM Product WHERE CategoryId = " + id + "";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(Product newProduct)
        {
            try
            {
                string sql = "INSERT INTO Product VALUES ('" + newProduct.Id + "',N'" + newProduct.Name + "'," + newProduct.Price + ",N'" + newProduct.Description + "',N'" + newProduct.Unit + "',N'" + newProduct.Origin + "'," + newProduct.CategoryId + ")";
                bool result = dbHelper.executeCRUD(sql);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Product newProduct,string id)
        {
            try
            {
                string sql = "UPDATE Product SET Name=N'" + newProduct.Name + "', Price=" + newProduct.Price + ", Description=N'" + newProduct.Description + "', Unit=N'" + newProduct.Unit + "', Origin=N'" + newProduct.Origin + "', CategoryId=" + newProduct.CategoryId + " Where Id='" + id + "'";
                bool result = dbHelper.executeCRUD(sql);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                string sql = "DELETE FROM Product Where Id= '" + id + "'";
                bool result = dbHelper.executeCRUD(sql);
                if (result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
