﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
            return new SuccesResult(Messages.UserAdded);


        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccesResult("Kullanıcı Silindi");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetById(int Id)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Id == Id));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult("Kullanıcı Güncellendi");
        }
    }
}
