# ReCapProject: Araba Kiralama Sistemi

Bu proje bir Araba Kiralama Sistemi hakkında. Her hafta yeni güncellemeler ekleyerek hem kurumsal mimariye uygun hem SOLID prensiplerine uygun hemde kendimizi tekrar etmeyeğimiz şekilde yazılmaya çalışılmaktadır. Olabildiğince kampa göre hareket edip buna uygun bir dökümantasyon yapmaktayım. Özellikle benim gibi bu projeyle uğraşan arkadaşlara bu projeyi ilerletirken bu kısımları şu şekilde oluşturdum diyebilmek, sizlerde fikir oluşturmak, anlamadığınız ya da eksik kaldığınız yerlerde destek olmaya çalışmak ve kendimi geliştirmek...

Burada her yapılan değişiklik Bölüm 1 - 8. Gün, Bölüm 2 - 9. Gün vb. tarzında olacaktır ve yapılan değişiklikler başta yer alacaktır.

## BÖLÜM 1 - 8. Gün

1) Brand ve Color nesneleri ekleyiniz(Entity)

	Brand-->Id,Name

	Color-->Id,Name

2) Sql Server tarafında yeni bir veritabanı kurunuz. Cars,Brands,Colors tablolarını oluşturunuz. (Araştırma)

3) Sisteme Generic IEntityRepository altyapısı yazınız.

4) Car, Brand ve Color nesneleri için Entity Framework altyapısını yazınız.

5) GetCarsByBrandId , GetCarsByColorId servislerini yazınız.

6) Sisteme yeni araba eklendiğinde aşağıdaki kuralları çalıştırınız.

	Araba ismi minimum 2 karakter olmalıdır

	Araba günlük fiyatı 0'dan büyük olmalıdır.
	

### Solution Explorer penceresinde;

![Screenshot_7](https://user-images.githubusercontent.com/59045890/107124581-cf3a3600-68b5-11eb-9aea-48b6d4ba747c.png)

#### KIRMIZI kutucuk içindekiler bizim Katmanlarımız: 
ReCap.Business, ReCap.ConsoleApp(Şuanlık UI yerine kullanılıyor), ReCap.DataAccess, ReCap.Entities

#### Sarı kutucuk içindekiler bizim Abstract klasörümüz: 
Interface'lerin yer aldığı kısım

#### Mor kutucuk içindekiler bizim Concrete klasörümüz: 
Abstract(Soyut) klasörü içerisinde yer alan Interfaceleri Concrete'te implemente ettiğimiz kısım. Örneğin; Interface'lerdeki metotların imzalarına göre dahil ettiğimiz bu metotları doldurduğumuz kısımlar.

#### Turkuaz kutucuk içindeki bizim Console(şuanlık UI) olarak kullandığımız kısım:
Bir sınıfın yeni bir instance(örnek)'ını oluşturup (

	CarManager carManager = new CarManager();

) verileri eklediğimiz, sildiğimiz, güncellediğimiz (

	Car car = new Car() 
	{
		Id=1, 
		BrandId=2, 
		ColorId=3, 
		Description = "Kırmızı Otomatik Araba"
	}; 

) ve bir sürü yeni kodlar yazacağımız kısım.

### SQL Server Object Explorer penceresinde;

![Screenshot_8](https://user-images.githubusercontent.com/59045890/107124973-ee39c780-68b7-11eb-8271-c27a983d05d7.png)

#### Koyu Pembe:
Database Adı: ReCapDB

#### Açık Pembe:
ReCapDB'de yer alan tablolarımız: Cars, Brands, Color


#### Bu tabloları oluşturmak için ReCapDB -> Mouse Sağ Click -> New Query
![Screenshot_5](https://user-images.githubusercontent.com/59045890/107125055-9059af80-68b8-11eb-87bd-0a0eb47e71a6.png)

#### Tabloların içine veriler eklemek için(Aynı Query sayfasına yazılabilir ya da ReCapDB -> Mouse Sağ Click -> New Query diyip yeni sayfada yazılabilir);
![Screenshot_6](https://user-images.githubusercontent.com/59045890/107125056-918adc80-68b8-11eb-897c-b657f92b833b.png)


#### SQL kodlarını direkt kullanmak isterseniz;

#### -Tablo eklemek için;
	CREATE TABLE Colors(

	    Id int PRIMARY KEY IDENTITY(1,1),

		ColorName nvarchar(50),

	)

	CREATE TABLE Brands(

	    Id int PRIMARY KEY IDENTITY(1,1),

	    BrandName nvarchar(50),
	)

	CREATE TABLE Cars(
	
	    Id int PRIMARY KEY IDENTITY(1,1),

	    BrandId int,

	    ColorId int,

	    ModelYear nvarchar(25),

	    DailyPrice decimal,

	    Descriptions nvarchar(200),

	    FOREIGN KEY (ColorId) REFERENCES Colors(Id),

	    FOREIGN KEY (BrandId) REFERENCES Brands(Id)
	)

#### -Tablolara veriler eklemek için;

	INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions) VALUES
	
	    (1,1,'2018',180,'Honda/Civic - Beyaz - Otomatik Hybrid'),

	    (2,3,'2015',170,'Mercedes - Kırmızı - Otomatik Dizel'),

	    (3,2,'2017',300,'BMW - Siyah - Otomatik Hybrid'),

	    (4,4,'2013',115,'Renault/Kangoo - Mavi - Manuel Benzin');



	INSERT INTO Colors(ColorName) VALUES('Beyaz'),('Siyah'),('Kırmızı'),('Mavi');

	INSERT INTO Brands(BrandName) VALUES ('Honda'),('Mercedes'),('BMW'),('Renault');
	
	
## BÖLÜM 2 - Code Refactoring - 9. Gün

1. CarRental Projenizde Core katmanı oluşturunuz.

2. IEntity, IDto, IEntityRepository, EfEntityRepositoryBase dosyalarınızı 9. gün dersindeki gibi oluşturup ekleyiniz.

3. Car, Brand, Color sınıflarınız için tüm CRUD operasyonlarını hazır hale getiriniz.

4. Console'da Tüm CRUD operasyonlarınızı Car, Brand, Model nesneleriniz için test ediniz. GetAll, GetById, Insert, Update, Delete.

5. Arabaları şu bilgiler olacak şekilde listeleyiniz. CarName, BrandName, ColorName, DailyPrice. (İpucu : IDto oluşturup 3 tabloya join yazınız)


Bu bölümde Code Refactoring yaptık. CRUD işlemleri her veritabanında ortak olduğu için bunu Core katmanına aldık. Böylece Core katmanımızda tüm projelerde yer alması gereken temel şeyler yer alacak.

Çoğu kısmı dersi izleyipte çoğu kişi yapmıştır lakin DTO(Data Transfer Object) kısmında veritabanına bizim belirlediğimiz tablolardan belirlediğimiz alanları tek bir yerden getirme ile ilgili olan kısım biraz kafa karıştırıcı. Bu yüzden de burada bunu açıklamaya çalışacağım.

#### 5. şartta bize CarName, BrandName, ColorName, DailyPrice getirmemizi istiyor fakat BrandName Brand tablosunda, ColorName Color tablosunda ve biz bunu Car tablosundan çağırmak istediğimizde sadece ColorId ve BrandId'ye erişebiliyoruz.

#### Bu engeli aşmak için de  tabiki bir çözüm var. 

### İlk önce neden kendi tablomuzu yapmayı düşünmeyelim?
Yani DTO kısmı aslında benim yukarıda dediğim "bizim belirlediğimiz tablolardan(birbirlerine ait ID'ler yer alan) belirlediğimiz alanları tek bir yerden getirme kısmını yapmamıza izin verir" kısmı yapmaya olanak verir.

Aşağıdaki resimde hangi alanları istiyorsam yazdım. 

### Not: Bu bir Car sınıfına özgü birşey ve içerisinde BrandId, ColorId yer aldığı için benim geri kalan tüm işlemlerimi Car'a ait yerlerde EFCarDal, ICarService ve CarManager'da yapmam lazım.

![Screenshot_11](https://user-images.githubusercontent.com/59045890/107271469-537aed80-6a5d-11eb-8ddb-2c0abf6f0421.png)

Resimde görüldüğü üzere EFCarDal içerisinde Car, Color, Brand tablolarını birleştirip hangi alanları istiyorsam o alanları yer aldığı tablodan çektim.

![Screenshot_10](https://user-images.githubusercontent.com/59045890/107269948-61c80a00-6a5b-11eb-9c2a-b623dbd853ce.png)

Ve Program.cs'de foreach ile çağırıp çalıştırdığımda resimdeki gibi bilgileri elde etmekteyim.

![Screenshot_9](https://user-images.githubusercontent.com/59045890/107269946-612f7380-6a5b-11eb-8963-cbcde70fb641.png)

Evet arkadaşlar Color, Brand, Car için tüm CRUD işlemleri Program.cs'de yapıldı ve hepsini kendiye alakalı #region'ların içine koydum. "+" olan yere tıkladığınızda BrandCRUDOperation, ColorCRUDOperation, CarCRUDOperation ve DTOUsing'in içeriğini görebilirsiniz.

![Screenshot_12](https://user-images.githubusercontent.com/59045890/107414163-aec2e380-6b22-11eb-8c25-40c610b94af6.png)

## BÖLÜM 3 - Code Refactoring - 10. Gün

#### Ödev 1
Car Rental Projenizde;

1. Core katmanında Results yapılandırması yapınız.
   
2. Daha önce geliştirdiğiniz tüm Business sınıflarını bu yapıya göre refactor (kodu iyileştirme) ediniz.

#### Ödev 4
CarRental projenizde;

1. Kullanıcılar tablosu oluşturunuz. Users-->Id,FirstName,LastName,Email,Password

2. Müşteriler tablosu oluşturunuz. Customers-->UserId,CompanyName
   ***Kullanıcılar ve müşteriler ilişkilidir.

3. Arabanın kiralanma bilgisini tutan tablo oluşturunuz. Rentals-->Id, CarId, CustomerId, RentDate(Kiralama Tarihi), ReturnDate(Teslim Tarihi). Araba teslim edilmemişse ReturnDate null'dır.

4. Projenizde bu entity'leri oluşturunuz.

5. CRUD operasyonlarını yazınız.

6. Yeni müşteriler ekleyiniz.

7. Arabayı kiralama imkanını kodlayınız. Rental-->Add

8. Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.



SQL Server Object Explorer ReCapDB'mde User, Customer, Rental tablolarını eklemek için;

	CREATE TABLE Users(
	    Id int PRIMARY KEY IDENTITY(1,1),
	    FirstName nvarchar(30),
	    LastName nvarchar(30),
	    Email nvarchar(150),
	    Password nvarchar(20),
	)

	CREATE TABLE Customers(
	    Id int PRIMARY KEY IDENTITY(1,1),
		UserId int,
	    CompanyName nvarchar(200)
	)

	CREATE TABLE Rentals(
	    Id int PRIMARY KEY IDENTITY(1,1),
	    CarId int,
	    CustomerId int,
	    RentDate nvarchar(25),
	    ReturnDate nvarchar(25),
	    FOREIGN KEY (CarId) REFERENCES Cars(Id),
	    FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
	)

Sonuç resimdeki gibidir --> 
![Screenshot_13](https://user-images.githubusercontent.com/59045890/107851613-62c2b800-6e1c-11eb-9502-d06c3f86c294.png)

#### Sakın ama sakın ReCapDBContext'in içine bu tabloları eklemeyi unutmayın!
Çünkü bu tabloların **Entities** (User, Customer, Rental), **DataAccess** (IUserDal, ICustomerDal, IRentalDal, EFUserDal, EFCustomerDal, EFRentalDal), **Business** (IUserService, ICustomerService, IRentalService, UserManager, CustomerManager, RentalManager) katmanları çalışır vaziyette olur. Ama Program.cs'de Managerların->Add metotlarını çağırmak isteyinde o tablolar **SET** edilmediği için tabloları bulamaz ve hata verir! (Tecrübeyle kanıtlanmıştır 😁)

![Screenshot_2](https://user-images.githubusercontent.com/59045890/107851692-dd8bd300-6e1c-11eb-963c-bf91b1f5f6bd.png)


#### Resimde görüldüğü üzere biz Data Field'ını GET özelliği verdik sadece yani ReadOnly'dir ama biz Constructor'da Data'ya dışarıdan bir veriyi SET ettik. Nasıl böyle birşey olabilir?

![Screenshot_3](https://user-images.githubusercontent.com/59045890/107858714-bea23680-6e46-11eb-9e47-bbcfe6020293.png)

### Bunun cevabı: Getter'lar(resimde get olarak tanımladığımız yer) ReadOnly'dir ve sadece Constructor'da Set edebilirsin!!! Yani Constructor dışında Set etme yapamazsın eğer bir Field'a set özelliği vermediysen!

## BÖLÜM 3 - WebAPI Katmanı ekleme ve Swagger Kullanımı - 11. Gün

#### Ödev 1
CarRental projenizde;

1. WebAPI katmanını kurunuz.
2. Business katmanındaki tüm servislerin Api karşılığını yazınız.

Evet arkadaşlar, ben burada API'lerimi test ederken **Swagger** kullanmayı tercih ettim. Postman'a nazaran kullanımı daha kolay. Çünkü Postman'da her metot için tek tek Controller'a bakıp düzenlemem gerekiyorken Swagger'da WebAPI katmanı altında yer alan tüm Controller'larımı ve onlara ait tüm API'leri hem görmemi hemde tek yerde hepsini denememe imkan veriyor.

### Swagger'ı projemizde kullanmak için;
1. **WebAPI** projemize gelip mouse sağ click ile **Manage Nuget Packages...** açın.
2. Browse kısmına NSwag.AspNetCore yazın ve indirin. (Resimdeki gibi)

![Screenshot_4](https://user-images.githubusercontent.com/59045890/108245419-506cb500-7161-11eb-8143-ceea78651e90.png)

3. İndirdikten sonra WebAPI'nin altında Startup.cs'yi açın. Resimdeki gibi sırayla **ConfigureServices** kısmına **services.addSwaggerDocument();** yazın. Sonra da altında yer alan Configure metodunun için sırayla **app.UseOpenAPI(); app.UserSwaggerUi3();** yazın. (Burayla işiniz bitti.)

![Screenshot_12](https://user-images.githubusercontent.com/59045890/108245688-a2add600-7161-11eb-9eb9-56c85c915ada.png)

![Screenshot_6](https://user-images.githubusercontent.com/59045890/108245423-51054b80-7161-11eb-9e19-815be62dfe0a.png)

4. Şimdi Projeyi WebAPI'den başlatın. (WebAPI'ye Set as Startup Project demeyi unutmayın. Çünkü projemizi artık buradan kontrol edicez)
5. Proje Chrome'da açılınca resimdeki gibi localhost:port numarasının sonuna **/swagger/index.html** eklemeyi unutmayın.

![Screenshot_7](https://user-images.githubusercontent.com/59045890/108245426-51054b80-7161-11eb-8498-99a93d354f33.png)

6. Swagger açılınca karşınızda bizim Controller'larımız ve onlara ait API'leri yer almaktadır.

![Screenshot_8](https://user-images.githubusercontent.com/59045890/108245417-4fd41e80-7161-11eb-817a-c6011a80c4d7.png)

#### Örneğin ben tüm markaları listelemek istersem (Brands/getall) ;

1. **Brands**'in altında yer alan **getall**'a tıklayın içerisinde **Try it out** tıklayın.

![Screenshot_9](https://user-images.githubusercontent.com/59045890/108247432-b3f7e200-7163-11eb-956a-96527c0cacfa.png)

2. **Execute** tuşuna basın.

![Screenshot_10](https://user-images.githubusercontent.com/59045890/108247442-b65a3c00-7163-11eb-83e8-5aac1018db08.png)

3. Ve görüldüğü üzere sonuç karşımızda.

![Screenshot_11](https://user-images.githubusercontent.com/59045890/108247443-b65a3c00-7163-11eb-8f14-df6cb3159f92.png)

### NOT: Burada dönen değer JSON formatıdır!



