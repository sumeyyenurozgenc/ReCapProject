# ReCapProject: Araba Kiralama Sistemi

Bu proje bir Araba Kiralama Sistemi. Her hafta yeni güncellemeler ekleyerek hem kurumsal mimariye uygun hem SOLID prensiplerine uygun hemde kendimizi tekrar etmeyeğimiz şekilde yazılmaya çalışılmaktadır. Olabildiğince kampa göre hareket edip buna uygun bir dökümantasyon yapmaktayım. Özellikle benim gibi bu projeyle uğraşan arkadaşlara bu projeyi ilerletirken bu kısımları şu şekilde oluşturdum diyebilmek, sizlerde fikir oluşturmak, anlamadığınız ya da eksik kaldığınız yerlerde destek olmaya çalışmak ve kendimi geliştirmek.

![Screenshot_7](https://user-images.githubusercontent.com/59045890/107124581-cf3a3600-68b5-11eb-9aea-48b6d4ba747c.png)

#### Solution Explorer penceresinde;

### KIRMIZI kutucuk içindekiler bizim Katmanlarımız: 
ReCap.Business, ReCap.ConsoleApp(Şuanlık UI yerine kullanılıyor), ReCap.DataAccess, ReCap.Entities

### Sarı kutucuk içindekiler bizim Abstract klasörümüz: 
Interface'lerin yer aldığı kısım

### Mor kutucuk içindekiler bizim Concrete klasörümüz: 
Abstract(Soyut) klasörü içerisinde yer alan Interfaceleri Concrete'te implemente ettiğimiz kısım. Örneğin; Interface'lerdeki metotların imzalarına göre dahil ettiğimiz bu metotları doldurduğumuz kısımlar.

### Turkuaz kutucuk içindeki bizim Console(şuanlık UI) olarak kullandığımız kısım:
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

![Screenshot_8](https://user-images.githubusercontent.com/59045890/107124973-ee39c780-68b7-11eb-8271-c27a983d05d7.png)
#### SQL Server Object Explorer penceresinde;

### Koyu Pembe:
Database Adı: ReCapDB

### Açık Pembe:
ReCapDB'de yer alan tablolarımız: Cars, Brands, Color


#### Bu tabloları oluşturmak için ReCapDB -> Mouse Sağ Click -> New Query
![Screenshot_5](https://user-images.githubusercontent.com/59045890/107125055-9059af80-68b8-11eb-87bd-0a0eb47e71a6.png)

#### Tabloların içine veriler eklemek için(Aynı Query sayfasına yazılabilir ya da ReCapDB -> Mouse Sağ Click -> New Query diyip yeni sayfada yazılabilir);
![Screenshot_6](https://user-images.githubusercontent.com/59045890/107125056-918adc80-68b8-11eb-897c-b657f92b833b.png)


### SQL kodlarını direkt kullanmak isterseniz;

### -Tablo eklemek için;
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

### -Tablolara veriler eklemek için;

	INSERT INTO Cars(BrandId,ColorId,ModelYear,DailyPrice,Descriptions) VALUES
	
	    (1,1,'2018',180,'Honda/Civic - Beyaz - Otomatik Hybrid'),

	    (2,3,'2015',170,'Mercedes - Kırmızı - Otomatik Dizel'),

	    (3,2,'2017',300,'BMW - Siyah - Otomatik Hybrid'),

	    (4,4,'2013',115,'Renault/Kangoo - Mavi - Manuel Benzin');



	INSERT INTO Colors(ColorName) VALUES('Beyaz'),('Siyah'),('Kırmızı'),('Mavi');

	INSERT INTO Brands(BrandName) VALUES ('Honda'),('Mercedes'),('BMW'),('Renault');
