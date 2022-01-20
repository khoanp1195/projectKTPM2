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
    class CategoryBUS
    {
        CategoryDAO dao = new CategoryDAO();

        public DataSet GetAll(string keyword)
        {
            DataSet ds = dao.SelectAll(keyword);
            return ds;
        }

        public List<Category> GetAllAdvanced()
        {
            List<Category> categories = new List<Category>();
            SqlDataReader dr = dao.SelectAllAdvanced();
            while (dr.Read())
            {
                Category category = new Category()
                {
                    Id = (int)dr["Id"],
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

        public Category GetCategoryDetail(int id)
        {
            Category category = null;
            SqlDataReader dr = dao.SelectById(id);
            while (dr.Read())
            {
                category = new Category()
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                };
            }
            if (category != null)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public Category GetCategoryDetail(string name)
        {
            Category category = null;
            SqlDataReader dr = dao.SelectByName(name);
            while (dr.Read())
            {
                category = new Category()
                {
                    Id = (int)dr["Id"],
                    Name = (string)dr["Name"],
                };
            }
            if (category != null)
            {
                return category;
            }
            else
            {
                return null;
            }
        }

        public List<Category> GetCategoriesSearch(string keyword)
        {
            List<Category> categories = new List<Category>(); ;
            SqlDataReader dr = dao.SelectByKeyWord(keyword);
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

        public bool InsertCategory(Category category)
        {
            bool result = dao.Insert(category);
            return result;
        }

        public bool UpdateCategory(Category category,int id)
        {
            bool result = dao.Update(category,id);
            return result;
        }

        public bool DeleteCategory(int id)
        {
            bool result = dao.Delete(id);
            return result;
        }
    
        public List<Category> SortASC()
        {
            List<Category> categories = GetAllAdvanced();
            categories = categories.OrderBy(x => x.Name).ToList();
            return categories;
        }

        public List<Category> SortDESC()
        {
            List<Category> categories = GetAllAdvanced();
            categories = categories.OrderByDescending(x => x.Name).ToList();
            return categories;
        }


    }
}
