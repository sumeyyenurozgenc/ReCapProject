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

            //Bolum2();

            UserManager userManager = new UserManager(new EFUserDal());
            CustomerManager customerManager = new CustomerManager(new EFCustomerDal());
            RentalManager rentalManager = new RentalManager(new EFRentalDal());

            #region UserCRUDOperation

            //User addUser = new User()
            //{
            //    FirstName = "Sümeyye Nur",
            //    LastName = "Özgenç",
            //    Email = "s@gmail.com",
            //    Password = "123"
            //};

            //userManager.Add(addUser);


            //User updateUser = new User()
            //{
            //    Id = 1,
            //    FirstName = "Merve",
            //    LastName = "Öz",
            //    Email = "n@gmail.com",
            //    Password = "123"
            //};

            //userManager.Update(updateUser);

            //User deleteUser = new User()
            //{
            //    Id = 1,
            //    FirstName = "Merve",
            //    LastName = "Öz",
            //    Email = "n@gmail.com",
            //    Password = "123"
            //};

            //userManager.Delete(deleteUser);

            //foreach (var users in userManager.GetAll().Data)
            //{
            //    Console.WriteLine(users.Id);
            //    Console.WriteLine(users.FirstName);
            //}
            #endregion

            #region CustomerCRUDOperation

            //Customer addCustomer = new Customer()
            //{
            //    UserId = 2,
            //    CompanyName = "PeraKent A.Ş"
            //};
            //customerManager.Add(addCustomer);

            //Customer updateCustomer = new Customer()
            //{
            //    Id = 2,
            //    UserId = 2,
            //    CompanyName = "perakalem a.ş"
            //};
            //customerManager.Update(updateCustomer);

            //Customer deleteCustomer = new Customer()
            //{
            //    Id=3,
            //    UserId = 2,
            //    CompanyName = "PeraKent A.Ş"
            //};
            //customerManager.Delete(deleteCustomer);

            //foreach (var customers in customerManager.GetAll().Data)
            //{
            //    Console.WriteLine(customers.Id);
            //    Console.WriteLine(customers.UserId);
            //    Console.WriteLine(customers.CompanyName);
            //}

            #endregion

            #region RentalCRUDOperations

            Rental addRental = new Rental()
            {
                CarId = 8,
                CustomerId = 1,
                RentDate = "27/01/2021",
                ReturnDate = ""
            };
            rentalManager.Add(addRental);

            //Rental updateRental = new Rental()
            //{
            //    Id = 2,
            //    CarId = 6,
            //    CustomerId = 2,
            //    RentDate = "12/01/2021",
            //    ReturnDate = "18/01/2021"
            //};
            //rentalManager.Update(updateRental);

            //Rental addRental = new Rental()
            //{
            //    Id = 3,
            //    CarId = 7,
            //    CustomerId = 2,
            //    RentDate = "05/02/2021",
            //    ReturnDate = "08/02/2021"
            //};
            //rentalManager.Delete(addRental);

            foreach (var rentals in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Id: {0}" ,rentals.Id);
                Console.WriteLine("CarId: {0}", rentals.CarId);
                Console.WriteLine("CustomerId: {0}", rentals.CustomerId);
                Console.WriteLine("RentDate: {0}", rentals.RentDate);
                Console.WriteLine("ReturnDate: {0}", rentals.ReturnDate);
            }

            #endregion

        }

        private static void Bolum2()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            ColorManager colorManager = new ColorManager(new EFColorDal());

            #region BrandCRUDOperation

            //Sakın ID yazma.Çünkü primary key ve kendisi otomatik yapıyor!
            Brand addBrand = new Brand()
            {
                BrandName = "Nissan"
            };

            brandManager.Add(addBrand);

            Brand updateBrand = new Brand()
            {
                Id = 1005,
                BrandName = "Nissanssss"
            };

            brandManager.Update(updateBrand);

            Brand deleteBrand = new Brand()
            {
                Id = 1005,
                BrandName = "Nissanssss"
            };

            brandManager.Delete(deleteBrand);

            foreach (var brands in brandManager.GetAll().Data)
            {
                Console.WriteLine(brands.BrandName);
            }

            #endregion

            #region ColorCRUDOperation

            Color addColor = new Color()
            {
                ColorName = "Vişne Çürüğü"
            };

            colorManager.Add(addColor);

            Color updateColor = new Color()
            {
                Id = 1002,
                ColorName = "Elma Kırmızısı"
            };

            colorManager.Update(updateColor);

            Color deleteColor = new Color()
            {
                Id = 1002,
                ColorName = "Elma Kırmızısı"
            };

            colorManager.Delete(deleteColor);

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            #endregion

            #region CarCRUDOperation

            Car car1 = new Car()
            {
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 100,
                ModelYear = "2006",
                Descriptions = "Tofaş - Dizel"
            };

            carManager.Add(car1);

            Car car2 = new Car()
            {
                Id = 8,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 85,
                ModelYear = "2007",
                Descriptions = "Renault/Kangoo - Manuel Benzin"
            };

            carManager.Update(car2);

            Car deleteCar = new Car()
            {
                Id = 1002,
                BrandId = 2,
                ColorId = 3,
                DailyPrice = 100,
                ModelYear = "2006",
                Descriptions = "Tofaş - Dizel"
            };

            carManager.Delete(deleteCar);
            var result = carManager.GetAll();
            if (result.Success != true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Descriptions);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }


            #endregion

            #region DTOUsing

            DtoUsing(carManager);

            #endregion
        }

        private static void DtoUsing(CarManager carManager)
        {
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine("Rengi: " + car.ColorName + " \nMarkası: " + car.BrandName +
                                " \nAraba Hakkında:" + car.CarName + " \nGünlük Ücreti: " + car.DailyPrice);
                Console.WriteLine("---------------------");
            }
        }

        private static void Bolum1()
        {
            //CarManager carManager = new CarManager(new EFCarDal());
            //BrandManager brandManager = new BrandManager(new EFBrandDal());
            //ColorManager colorManager = new ColorManager(new EFColorDal());

            //Console.Write("Hangi marka araba getirilsin? --> ");
            //byte brandId = Convert.ToByte(Console.ReadLine());

            //foreach (var car in carManager.GetCarsByBrandId(brandId))
            //{
            //    Console.WriteLine($"Araba Rengi: {colorManager.GetById(car.ColorId).ColorName}\n" +
            //        $"Araba Markası: {brandManager.GetById(car.BrandId).BrandName}\n" +
            //        $"Arabanın Yılı: {car.ModelYear}\n" +
            //        $"Arabanın Günlük Ücreti: {car.DailyPrice}\n" +
            //        $"Açıklama: {car.Descriptions}\n");
            //}

            //Console.Write("Hangi renk araba getirilsin? --> ");
            //byte colorId = Convert.ToByte(Console.ReadLine());

            //foreach (var car in carManager.GetCarsByColorId(colorId))
            //{
            //    Console.WriteLine($"Araba Rengi: {colorManager.GetById(car.ColorId).ColorName}\n" +
            //        $"Araba Markası: {brandManager.GetById(car.BrandId).BrandName}\n" +
            //        $"Arabanın Yılı: {car.ModelYear}\n" +
            //        $"Arabanın Günlük Ücreti: {car.DailyPrice}\n" +
            //        $"Açıklama: {car.Descriptions}\n");
            //}

            //Brand brand1 = new Brand()
            //{
            //    Id = 5,
            //    BrandName = "w"
            //};

            //brandManager.Add(brand1);

            //Console.WriteLine();

            //Car car1 = new Car()
            //{
            //    Id = 9,
            //    BrandId = 2,
            //    ColorId = 3,
            //    DailyPrice = -10,
            //    ModelYear = "2006",
            //    Descriptions = "Tofaş - Dizel"
            //};

            //carManager.Add(car1);
        }
    }
}
