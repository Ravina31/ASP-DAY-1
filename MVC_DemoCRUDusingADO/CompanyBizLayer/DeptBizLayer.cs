using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyDAL.DAL;
using CompanyEntities.Models;

namespace CompanyBizLayer
{
    public class DeptBizLayer
    {
        private DeptDAL dal = null;

        public DeptBizLayer()
        {
            dal = new DeptDAL();
        }
        public IEnumerable<DeptModel> GetDepts()
        {
            var depts = dal.GetAllDepts();
            //ToDo : write some business logic(domain logic) here
            return depts;
        }
        public DeptModel GetDeptByDeptNo (int DeptNo)
        {
            var dept = dal.GetDept(DeptNo);
            //ToDo : write some business logic(domain logic) here
            return dept;
        }

        public bool AddDept (DeptModel dept)
        {
            //ToDo : write some business logic(domain logic) here
            bool result = dal.CreateDept(dept);
            //ToDo : write some business logic(domain logic) here
            return result;
        }

        public bool UpdateDept(DeptModel dept)
        {
            //ToDo : write some business logic(domain logic) here
            bool result = dal.EditDept(dept);
            //ToDo : write some business logic(domain logic) here
            return result;
        }

        public bool RemoveDeptByDeptNo(int deptNo)
        {
            //ToDo : write some business logic(domain logic) here
            bool result = dal.DeleteDept(deptNo);
            //ToDo : write some business logic(domain logic) here
            return result;
        }

    }
}
