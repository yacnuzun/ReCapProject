﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [ValidationAspect(typeof(UserValidator))]

        public void Add(User user)
        {

            _userDal.Add(user);


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

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);

        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        [ValidationAspect(typeof(UserValidator))]

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccesResult("Kullanıcı Güncellendi");
        }
    }
}
