# 🍞 Baker - Bakery Web Site & Admin Panel

Baker, pastane/fırın işletmeleri için geliştirilmiş ASP.NET Core tabanlı bir web uygulamasıdır. Proje iki ana bölümden oluşur:

- 🔌 `BakerApi`: Ürün, kategori, şef, servis, galeri, mesaj, abone ve site içeriklerini yöneten REST API.
- 🖥️ `BakerWebUI`: API'den veri tüketen MVC/Razor tabanlı vitrin sitesi ve admin paneli.

Uygulamanın vitrin tarafında ziyaretçiler ürünleri, hizmetleri, ekip üyelerini, referansları ve iletişim formunu görüntüleyebilir. Admin panelinde ise site içerikleri yönetilebilir; ürün, kategori, servis, şef, galeri, mesaj ve abone kayıtları üzerinde listeleme, ekleme, güncelleme ve silme işlemleri yapılabilir.

## 🛠️ Kullanılan Teknolojiler

- 🧠 ASP.NET Core MVC / Web API
- 🗃️ Entity Framework Core
- 💾 SQL Server
- 🧩 Razor View Components
- 📘 Swagger / Swashbuckle
- 🎨 Bootstrap tabanlı Baker teması
- 🟣 Purple Admin yönetim paneli teması


## 🚀 Temel Özellikler

- 📊 Ana sayfada dinamik ürün, kategori, şef ve referans sayıları
- 🛍️ Ürünlerin kategori ve fiyat bilgileriyle listelenmesi
- 📖 Hakkımızda, servisler, ekip, referanslar ve galeri bölümleri
- 📩 İletişim formu ile ziyaretçi mesajı gönderme
- 📧 Bülten aboneliği
- 📊 Admin dashboard üzerinde genel proje özeti
- ⚙️ Ürün, kategori, servis, servis detayı, şef, galeri, mesaj ve abone yönetimi
- 🔄 API üzerinden CRUD işlemleri

## 🗄️ Veritabanı

Proje Entity Framework Core ile SQL Server kullanır.

## 🔌 API Katmanı

`BakerApi` projesi uygulamanın veri sağlayıcı katmanıdır. Controllerlar veritabanındaki tabloları dış dünyaya REST endpointleri olarak açar.

Başlıca controllerlar:

- 📦 `ProductsController`: Ürün listeleme, ürün-kategori ilişkili listeleme, ürün sayısı, ekleme, güncelleme, silme
- 🗂️ `CategoryController`: Kategori listeleme, kategori sayısı, ekleme, güncelleme, silme
- 👨‍🍳 `ChefController`: Şef listeleme, şef sayısı, ekleme, güncelleme, silme
- 🛎️ `ServiceController`: Servisleri ve servis detaylarını listeleme
- 📄 `ServiceDetailController`: Servislere bağlı detay maddelerini yönetme
- 🖼️ `GalleryController`: Galeri görsellerini yönetme
- 💬 `ContactController`: Ziyaretçi mesajlarını alma ve yönetme
- 📧 `SubscribeController`: Bülten abonelerini yönetme
- ⭐ `TestimonialController`: Referans/yorum kayıtlarını yönetme
- 📖 `AboutController` ve `AboutDetailController`: Hakkımızda alanı ve detay maddelerini yönetme
- 📍 `AddressInfoController`: Adres ve iletişim bilgilerini yönetme

## 🖥️ Web UI Katmanı

`BakerWebUI`, MVC yapısında hazırlanmıştır. Vitrin sayfası `DefaultController` ve View Component yapılarıyla oluşturulur. Admin tarafında ise her yönetim alanı için ayrı controller bulunur.

Önemli View Componentler:

- 🧭 `_DefaultNavbarComponentPartial`: Site navigasyonu
- 🌟 `_DefaultFeatureComponentPartial`: Hero alanı
- 📊 `_DefaultStatisticComponentPartial`: Ürün, şef, kategori ve referans sayıları
- 📖 `_DefaultAboutComponentPartial`: Hakkımızda bölümü
- 🛍️ `_DefaultProductComponentPartial`: Ürün kartları
- 🛎️ `_DefaultServiceComponentPartial`: Servisler bölümü
- 👨‍🍳 `_DefaultChefComponentPartial`: Ekip/şef bölümü
- 💬 `_DefaultTestimonialComponentPartial`: Referanslar bölümü
- 🔚 `_DefaultFooterComponentPartial`: Footer ve galeri
---
## Ekran Görüntüleri ve Açıklamalar

### 1. Ana Sayfa Hero Alanı

![Ana Sayfa Hero](docs/screenshots/1.png)

Ziyaretçinin siteye ilk girdiğinde gördüğü karşılama alanıdır. Üst menü, sosyal medya bağlantıları, telefon bilgisi ve marka başlığı burada yer alır. Hero görseli fırın temasını güçlendirir ve kullanıcıyı ana içeriklere yönlendirir.

### 2. İstatistik Alanı

![İstatistik Alanı](docs/screenshots/2.png)

Bu bölüm API'den gelen dinamik sayıları gösterir. Ürün sayısı, şef sayısı, kategori sayısı ve referans sayısı ViewBag üzerinden çekilir. Böylece admin panelinde yapılan değişiklikler ana sayfadaki istatistiklere yansır.

### 3. Hakkımızda Bölümü

![Hakkımızda Bölümü](docs/screenshots/3.png)

Pastanenin/fırının hakkımızda kısmını anlatan alandır. 

### 4. Ürünler Bölümü

![Ürünler Bölümü](docs/screenshots/4.png)

Ürünler kart yapısıyla listelenir. Her kartta ürün adı, fiyatı, kategori adı ve ürün görseli bulunur. 

### 5. Servisler Bölümü

![Servisler Bölümü](docs/screenshots/5.png)

Fırının sunduğu hizmetleri açıklar. 

### 6. Ekip Bölümü

![Ekip Bölümü](docs/screenshots/6.png)

Şef ve çalışan bilgilerini gösterir. 

### 7. Referanslar ve Bülten Aboneliği

![Referanslar ve Bülten](docs/screenshots/7.png)

Müşteri yorumları ve bülten aboneliği formu burada bulunur.

### 8. Footer ve Galeri

![Footer ve Galeri](docs/screenshots/8.png)

Footer alanında adres, telefon, e-posta, hızlı bağlantılar, sosyal medya ikonları ve fotoğraf galerisi yer alır. 
### 9. İletişim Formu

![İletişim Formu](docs/screenshots/9.png)

Ziyaretçiler ad, e-posta, konu ve mesaj bilgileriyle iletişim formu gönderebilir.

### 10. Başarılı Mesaj Bildirimi

![Başarılı Mesaj Bildirimi](docs/screenshots/10.png)

İletişim formu başarıyla gönderildiğinde kullanıcıya SweetAlert tarzında başarılı mesaj bildirimi gösterilir.

### 11. Admin Dashboard

![Admin Dashboard](docs/screenshots/11.png)

Admin panelinin ana ekranıdır. Ürün, kategori, mesaj, şef, abone ve toplam içerik sayıları gösterilir. Ayrıca son eklenen ürünler ve kategori dağılımı listelenir.

### 12. Hakkımızda Yönetimi

![Hakkımızda Yönetimi](docs/screenshots/12.png)

Ana sayfadaki hakkımızda içeriği buradan yönetilir. Başlık ve açıklama alanları listelenir; düzenleme, silme ve detay yönetimi yapılabilir.

### 13. Ürün Yönetimi

![Ürün Yönetimi](docs/screenshots/13.png)

Admin, ürünleri görsel, ad, fiyat ve kategori bilgileriyle görüntüler. Ürünler düzenlenebilir veya silinebilir.

### 14. Ürün Güncelleme

![Ürün Güncelleme](docs/screenshots/14.png)

Var olan ürünün adı, fiyatı, kategorisi ve görsel URL bilgisi güncellenir. Kategori seçimleri API'den çekilir.

### 15. Yeni Ürün Kaydı

![Yeni Ürün Kaydı](docs/screenshots/15.png)

Yeni ürün ekleme formudur. Ürün adı, fiyat, kategori ve görsel URL bilgileriyle kayıt yapılır.

### 16. Kategori Listesi

![Kategori Listesi](docs/screenshots/16.png)

Ürün kategorileri listelenir. Kategoriler düzenlenebilir, silinebilir veya yeni kategori eklenebilir.

### 17. Kategori Güncelleme

![Kategori Güncelleme](docs/screenshots/17.png)

Seçilen kategorinin adı güncellenir. Güncelleme sonrası vitrin ve ürün kartlarındaki kategori bilgileri de değişir.

### 18. Yeni Kategori Kaydı

![Yeni Kategori Kaydı](docs/screenshots/18.png)

Yeni kategori ekleme formudur. Bu kategoriler ürün ekleme/güncelleme formlarında seçenek olarak kullanılır.

### 19. Servis Yönetimi

![Servis Yönetimi](docs/screenshots/19.png)

Ana servis başlıkları listelenir. Servisler düzenlenebilir, silinebilir ve detayları yönetilebilir.

### 20. Servis Güncelleme

![Servis Güncelleme](docs/screenshots/20.png)

Servis adı, görsel bağlantısı ve açıklama metni güncellenir. Bu bilgiler ana sayfadaki servisler bölümüne yansır.

### 21. Yeni Servis Kaydı

![Yeni Servis Kaydı](docs/screenshots/21.png)

Yeni servis ekleme formudur. Servis adı, görsel URL ve açıklama bilgileri alınır.

### 22. Servis Detay Listesi

![Servis Detay Listesi](docs/screenshots/22.png)

Seçili servise ait alt detaylar listelenir. Örneğin "Kaliteli Ürünler", "Kişiye Özel Üretim", "Online Sipariş" gibi maddeler bu bölümden yönetilir.

### 23. Şef Listesi

![Şef Listesi](docs/screenshots/23.png)

Sitede görünen ekip üyeleri listelenir. Fotoğraf, ad soyad ve unvan bilgileri bulunur.

### 24. Şef Güncelleme

![Şef Güncelleme](docs/screenshots/24.png)

Var olan şef kaydının adı, görevi ve fotoğraf URL bilgisi güncellenir.

### 25. Yeni Şef Kaydı

![Yeni Şef Kaydı](docs/screenshots/25.png)

Yeni ekip üyesi ekleme formudur. Girilen kayıt ana sayfadaki ekip bölümünde görüntülenir.

### 26. Galeri Listesi

![Galeri Listesi](docs/screenshots/26.png)

Footer ve galeri alanında kullanılan görseller listelenir. Görsel bağlantısı görüntülenir, düzenleme ve silme işlemleri yapılabilir.

### 27. Galeri Güncelleme

![Galeri Güncelleme](docs/screenshots/27.png)

Kayıtlı galeri görselinin URL bilgisi güncellenir.

### 28. Yeni Galeri Kaydı

![Yeni Galeri Kaydı](docs/screenshots/28.png)

Yeni galeri görseli ekleme formudur. Eklenen görseller site footer galerisinde kullanılabilir.

### 29. Gelen Mesajlar

![Gelen Mesajlar](docs/screenshots/29.png)

Ziyaretçilerin iletişim formundan gönderdiği mesajlar burada listelenir. Admin mesajları inceleyebilir ve silebilir.

### 30. Abone Yönetimi

![Abone Yönetimi](docs/screenshots/30.png)

Bültene abone olan kullanıcıların e-posta adresleri listelenir. Admin gereksiz kayıtları silebilir.


