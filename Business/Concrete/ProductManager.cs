﻿using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using DataAccess.DTOs;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ILogger _logger;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //bir kategoride en fazla 10 ürün olabilir
            //Aynı isimde ürün eklenemez.
            if (CheckIfProductCountofCategoryCorrect(product.CategoryId).Success && CheckIfProductNameExits(product.ProductName).Success)
            {
                _productDal.Add(product);

                return new SuccessResult(Messages.ProductAdded);
            }
            return new ErrorResult();
            

         
           
        }

        public IDataResult<List<Product>> GetAll()
        {
            //İş kodları.
            if (DateTime.Now.Hour == 15)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed); 
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {  //Yapı basit aslında SuccesDataResult<T> formantının içine Product gönderiyoruz parametre olarak da parantez içindekiler.
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice >=min && p.UnitPrice <=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            //bir kategoride en fazla 10 ürün olabilir
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCounofCategoryError);
            }

            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountofCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCounofCategoryError);
            }
            return new SuccessResult();

        }
        private IResult CheckIfProductNameExits(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            
            return new SuccessResult();
        }
    }
}
