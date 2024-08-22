using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class JobManager : IGenericService<Job>
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public Job GetById(int id)
        {
           return _jobDal.GetById(id);
        }

        public List<Job> GetList()
        {
            return _jobDal.GetLİst();
        }

        public void TDelete(Job t)
        {
           _jobDal.Delete(t);
        }

        public Job TGetById(int id)
        {
            return _jobDal.GetById(id);
            throw new NotImplementedException();
        }

        public object TGetList()
        {
            return _jobDal.GetAll();
            throw new NotImplementedException();
        }

        public void TInsert(Job t)
        {
            _jobDal.Insert(t);
        }

        public void TUpdate(Job t)
        {
            _jobDal.Update(t);
        }
    }
}
