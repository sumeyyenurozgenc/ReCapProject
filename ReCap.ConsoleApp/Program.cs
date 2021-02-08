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
