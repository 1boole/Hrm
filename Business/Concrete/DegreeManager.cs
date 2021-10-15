using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DegreeManager : IDegreeService
    {
        IDegreeDal _degreeDal;

        public DegreeManager(IDegreeDal degreeDal)
        {
            _degreeDal = degreeDal;
        }

        public Degree GetById(int id)
        {
            return _degreeDal.Get(d => d.Id == id);
        }
    }
}
