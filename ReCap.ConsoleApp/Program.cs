using ReCap.Business.Concrete;
using ReCap.DataAccess.Concrete.EntityFramework;
using ReCap.Entities.Concrete;
using System;

namespace ReCap.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Bolum1();

            CarManager carManager = new CarManager(new EFCarDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());

            #region BrandCRUDOperation

            //Sakın ID yazma. Çünkü primary key ve kendisi otomatik yapıyor!
            //Brand addBrand = new Brand()
            //{
            //    BrandName = "Nissan"
            //};

            //brandManager.Add(addBrand);

            //Brand updateBrand = new Brand()
            //{
            //    Id = 1005,
            //    BrandName = "Nissanssss"
            //};

            //brandManager.Update(updateBrand);

            //Brand deleteBrand = new Brand()
            //{
            //    Id = 1005,
            //    BrandName = "Nissanssss"
            //};

            //brandManager.Delete(deleteBrand);

            //foreach (var brands in brandManager.GetAll())
            //{
            //    Console.WriteLine(brands.BrandName);
            //}

            #endregion

            #region ColorCRUDOperation

            //Color addColor = new Color()
            //{
            //    ColorName = "Vişne Çürüğü"
            //};

            //colorManager.Add(addColor);

            //Color updateColor = new Color()
            //{
            //    Id = 1002,
            //    ColorName = "Elma Kırmızısı"
            //};

            //colorManager.Update(updateColor);

            //Color deleteColor = new Color()
            //{
            //    Id = 1002,
            //    ColorName = "Elma Kırmızısı"
            //};

            //colorManager.Delete(deleteColor);

            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}

            #endregion

            #region CarCRUDOperation

            //Car car1 = new Car()
            //{
            //    BrandId = 2,
            //    ColorId = 3,
            //    DailyPrice = 100,
            //    ModelYear = "2006",
            //    Descriptions = "Tofaş - Dizel"
            //};

            //carManager.Add(car1);

            //Car car2 = new Car()
            //{
            //    Id = 8,
            //    BrandId = 2,
            //    ColorId = 3,
            //    DailyPrice = 85,
            //    ModelYear = "2007",
            //    Descriptions = "Renault/Kangoo - Manuel Benzin"
            //};

            //carManager.Update(car2);

            //Car deleteCar = new Car()
            //{
            //    Id = 1002,
            //    BrandId = 2,
            //    ColorId = 3,
            //    DailyPrice = 100,
            //    ModelYear = "2006",
            //    Descriptions = "Tofaş - Dizel"
            //};

            //carManager.Delete(deleteCar);

            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Descriptions);
            //}

            #endregion

            #region DTOUsing
            
            DtoUsing(carManager);

            #endregion

        }

        private static void DtoUsing(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Rengi: " + car.ColorName + " \nMarkası: " + car.BrandName +
                                " \nAraba Hakkında:" + car.CarName + " \nGünlük Ücreti: " + car.DailyPrice);
                Console.WriteLine("---------------------");
            }
        }

        private static void Bolum1()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());

            Console.Write("Hangi marka araba getirilsin? --> ");
            byte brandId = Convert.ToByte(Console.ReadLine());

            foreach (var car in carManager.GetCarsByBrandId(brandId))
            {
                Console.WriteLine($"Araba Rengi: {colorManager.GetById(car.ColorId).ColorName}\n" +
                    $"Araba Markası: {brandManager.GetById(car.BrandId).BrandName}\n" +
                    $"Arabanın Yılı: {car.ModelYear}\n" +
                    $"Arabanın Günlük Ücreti: {car.DailyPrice}\n" +
                    $"Açıklama: {car.Descriptions}\n");
            }

            Console.Write("Hangi renk araba getirilsin? --> ");
            byte colorId = Convert.ToByte(Console.ReadLine());

            foreach (var car in carManager.GetCarsByColorId(colorId))
            {
                Console.WriteLine($"Araba Rengi: {colorManager.GetById(car.ColorId).ColorName}\n" +
                    $"Araba Markası: {brandManager.GetById(car.BrandId).BrandName}\n" +
                    $"Arabanın Yılı: {car.ModelYear}\n" +
                    $"Arabanın Günlük Ücreti: {car.DailyPrice}\n" +
                    $"Açıklama: {car.Descriptions}\n");
            }

            Brand brand1 = new Brand()
            {
                Id = 5,
                BrandName = "w"
            };

            brandManager.Add(brand1);

            Console.WriteLine();

            Car car1 = new Car()
            {
                Id = 9,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = -10,
                ModelYear = "2006",
                Descriptions = "Tofaş - Dizel"
            };

            carManager.Add(car1);
        }
    }
}
