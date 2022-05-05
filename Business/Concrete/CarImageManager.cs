using Business.Abstract;
using Business.Constants;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

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
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id));
        }
        public IDataResult<List<CarImage>> GetAllByCarId(int id)
        {
            var result = CheckIfCarImageNull(id);
            if (!result.Success)
            {
                var defaultImages = GenerateDefaultImages(id);
                return defaultImages;
            }
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
        }

        private IResult CheckIfCarImageNull(int id)
        {
            var carImages=_carImageDal.GetAll(c=>c.CarId==id).Any();
            if (!carImages)
            {
                return new ErrorResult();
            }
            return new SuccesResult();
        }
        private IDataResult<List<CarImage>> GenerateDefaultImages(int id)
        {
            string imagePath = PathConstants.DefaultCarImages;
            List<CarImage> defaultImages = new List<CarImage>();
            defaultImages.Add(new CarImage { CarId = id,ImagePath=imagePath });
            return new SuccessDataResult<List<CarImage>>(defaultImages);
        }
    }
}
