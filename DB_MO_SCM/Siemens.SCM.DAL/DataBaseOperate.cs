using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Siemens.SCM.Model.ViewModel;
using Siemens.SCM.Model;
using System.Data;

namespace Siemens.SCM.DAL
{
    public class DataBaseOperate<T>
        where T : class
    {
        public DataBaseManagementResult Add(T item)
        {
            DataBaseManagementResult result = new DataBaseManagementResult();
            try
            {
                using (UsersContext db = new UsersContext())
                {
                    db.Set<T>().Add(item);
                    db.SaveChanges();
                    result.Status = true;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public DataBaseManagementResult Update(T item)
        {
            DataBaseManagementResult result = new DataBaseManagementResult();
            try
            {
                using (UsersContext db = new UsersContext())
                {
                    db.Entry<T>(item).State = EntityState.Modified;
                    db.SaveChanges();
                    result.Status = true;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public DataBaseManagementResult Delete(T item)
        {
            DataBaseManagementResult result = new DataBaseManagementResult();
            try
            {
                using (UsersContext db = new UsersContext())
                {
                    db.Entry<T>(item).State = EntityState.Deleted;
                    db.SaveChanges();
                    result.Status = true;
                }
            }
            catch (Exception e)
            {
                result.ErrorMessage = e.Message;
            }
            return result;
        }


    }
}
