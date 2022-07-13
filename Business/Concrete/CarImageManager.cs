using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
<<<<<<< HEAD
=======
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

<<<<<<< HEAD
        public IResult Add(IFormFile file, CarImage carImage)
        {
            //var imageLimitResult = ChekIfCarImageLimitExceeded(carImage.CarId);
            //if (!imageLimitResult.Success)
            //{
            //    return imageLimitResult;
            //}
            //var carImageDirectory = PathConstants.CarImagesMainPath + "" + carImage.CarId + "\\";
            //var imageUploadResult = FileHelper.Upload(file, carImageDirectory);
            //if (!imageUploadResult.Success)
            //{
            //    return imageUploadResult;
            //}
            //carImage.ImagePath = imageUploadResult.Message;
            //_carImageDal.Add(carImage);
            //return new SuccesResult(Messages.CarImageAdded);
            

                carImage.ImagePath = FileHelper.Add(file);
                carImage.Date = DateTime.Now;
                _carImageDal.Add(carImage);
                return new SuccesResult(Messages.CarImageAdded);
            

        }

        private IResult ChekIfCarImageLimitExceeded(int carId)
        {
            var maxAllowedImageCount = 5;
            var carImageCount = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount >= maxAllowedImageCount)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded + "" + maxAllowedImageCount);
            }
            return new SuccesResult();
        }

        public IResult Delete(CarImage carImage)
        {
            var carImagePath = PathConstants.CarImagesPath + "" + carImage.CarId + "\\" + carImage.ImagePath;
            FileHelper.Delete(carImagePath);
            _carImageDal.Delete(carImage);
            return new SuccesResult(Messages.CarImageDeleted);
=======
        public IResult Add(IFormFile file,CarImage carImage)
        {
            var imageLimitResult = CheckIfCarImageLimitExceeded(carImage.CarId);
            if (!imageLimitResult.Success)
            {
                return imageLimitResult;
            }
            var carImageDirectory = PathConstants.CarImagesMainPath + "" + carImage.CarId + "\\";
            var imageUploadResult = FileHelper.Upload(file, carImageDirectory);
            if (!imageUploadResult.Success)
            {
                return imageUploadResult;
            }
            carImage.ImagePath = imageUploadResult.Message;
            _carImageDal.Add(carImage);
            return new SuccesResult(Messages.CarImageAdded);


        }


        public IResult Delete(CarImage carImage)
        {
            var carImagePath = PathConstants.CarImagesMainPath + "" + carImage.CarId + "\\" + carImage.ImagePath;
            FileHelper.Delete(carImagePath);
            _carImageDal.Delete(carImage);
            return new SuccesResult("Marka Silindi");
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }
<<<<<<< HEAD

        public IDataResult<List<CarImage>> GetByAllCarId(int id)
=======
        public IDataResult<List<CarImage>> GetAllByCarId(int id)
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        {
            var result = CheckIfCarImageNull(id);
            if (!result.Success)
            {
                var defaultImages = GenerateDefaultImages(id);
                return defaultImages;
            }
<<<<<<< HEAD
            return new SuccessDataResult<List<CarImage>>
                (_carImageDal.GetAll(c => c.Id == id));
        }

        private IDataResult<List<CarImage>> GenerateDefaultImages(int id)
        {
            string imagePath = PathConstants.DefaultCarImage;
            List<CarImage> defaultImages = new List<CarImage>();
            defaultImages.Add(new CarImage { CarId = id, ImagePath = imagePath });
            return new SuccessDataResult<List<CarImage>>(defaultImages);
=======
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.Id == id));
        }

        

        public IResult Update(IFormFile file ,CarImage carImage)
        {
            var carImageDirectory = PathConstants.CarImagesMainPath + "" + carImage.CarId + "\\";
            var carImagePath = carImageDirectory + carImage.ImagePath;
            FileHelper.Update(file,carImagePath,carImage.ImagePath);
            _carImageDal.Update(carImage);
            return new SuccesResult("Resim Güncellendi");
        }
        /*---------------------------------------------------------------------------*/
        private IResult CheckIfCarImageLimitExceeded(int carId)
        {
            var maxAllowedImageCount = 5;
            var carImageCount=_carImageDal.GetAll(c=>c.CarId == carId).Count;
            if (carImageCount > maxAllowedImageCoun)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded+""+maxAllowedImageCount);
            }
            return new SuccesResult();
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        }

        private IResult CheckIfCarImageNull(int id)
        {
<<<<<<< HEAD
            var carImages = _carImageDal.GetAll(c => c.CarId == id).Any();
=======
            var carImages=_carImageDal.GetAll(c=>c.CarId==id).Any();
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
            if (!carImages)
            {
                return new ErrorResult();
            }
            return new SuccesResult();
        }
<<<<<<< HEAD

        public IResult Update(IFormFile file,CarImage carImage)
        {
            var carImageDirectory = PathConstants.CarImagesMainPath + "" + carImage.CarId + "\\";
            var carImagePath=carImageDirectory + carImage.ImagePath;
            FileHelper.Update(file,carImageDirectory,carImagePath);
            _carImageDal.Update(carImage);
            return new SuccesResult(Messages.CarImageUpdated);
=======
        private IDataResult<List<CarImage>> GenerateDefaultImages(int id)
        {
            string imagePath = PathConstants.DefaultCarImages;
            List<CarImage> defaultImages = new List<CarImage>();
            defaultImages.Add(new CarImage { CarId = id,ImagePath=imagePath });
            return new SuccessDataResult<List<CarImage>>(defaultImages);
>>>>>>> dd5bef6f54cc9747dc2eec951cfb38825296948a
        }
    }
}
