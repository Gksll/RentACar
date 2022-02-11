using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(GetById(color.ColorId).Data);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.Listed);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId)
                ,Messages.Get);
        }

        public IResult Update(Color color)
        {
            Color c = GetById(color.ColorId).Data;
            c.ColorId = color.ColorId;
            c.ColorName = color.ColorName;
            _colorDal.Update(c);
            return new SuccessResult(Messages.Updated);
        }
    }
}
