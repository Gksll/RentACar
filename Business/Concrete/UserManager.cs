using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccessLayer.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);
        }

        public IResult AddTransactionalTest(User entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(User user)
        {
           _userDal.Delete(GetById(user.Id).Data);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<User>> GetAll()
        {
           return new SuccessDataResult<List<User>>(_userDal.GetAll(),Messages.Listed);
        }

        public IDataResult<User> GetById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==userId),Messages.Get);
        }

        public IDataResult<User> GetByMail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Email==email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IResult Update(User user)
        {
            User u = GetById(user.Id).Data;
            u.Id = user.Id;
            u.Email = user.Email;
            u.LastName = user.LastName;
            u.FirstName = user.FirstName;
            _userDal.Update(u);
            return new SuccessResult(Messages.Updated);
        }
    }
}
