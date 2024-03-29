﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {

            _customerDal.Add(customer);
            return new SuccesResult(Messages.CustomerAdded);


        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccesResult("Müşteri Silindi");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetById(int Id)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c => c.UserId == Id));
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccesResult("Müşteri Güncellendi");
        }
    }
}
