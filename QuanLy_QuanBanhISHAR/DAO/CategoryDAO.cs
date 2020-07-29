using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLy_QuanBanhISHAR.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return CategoryDAO.instance; }
            private set { CategoryDAO.instance = value; }
        }

        private CategoryDAO() { }

        public List<DTO.Category> GetListCategory()
        {
            List<DTO.Category> list = new List<DTO.Category>();
            string query = "Select *  from  FOODCATEGORY";

            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                DTO.Category category = new DTO.Category(item);
                list.Add(category);
            }

            return list;
        }
        public DTO.Category GetCategoryByID(int id)
        {
            DTO.Category category = null;

            string query = "Select *  from  FOODCATEGORY where id = " + id;

            DataTable data = DAO.DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                category = new DTO.Category(item);
                return category;
            }

            return category;

        }
    }
}
