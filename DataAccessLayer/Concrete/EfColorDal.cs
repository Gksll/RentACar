using Core.DAL.EntityFramework;
using DataAccessLayer.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfColorDal: EfEntityRepositoryBase<Color,CarContext>,IColorDal
    {
    }
}
