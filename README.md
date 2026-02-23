🍽️ Restaurant Microservices Project

Bu proje, yeni mezun bir backend geliştirici olarak mikroservis mimarisi, dağıtık sistemler ve modern .NET ekosistemi üzerindeki yetkinliklerimi sergilemek amacıyla geliştirilmiş, uçtan uca bir restoran yönetim ekosistemidir.

> **Motto:** Sadece çalışan bir kod değil; "neden bu teknoloji?" sorusuna mimari cevaplar verebilen sürdürülebilir bir yapı.

---

## 🎯 Proje Odak Noktaları

Bu çalışmada özellikle aşağıdaki modern yazılım geliştirme pratiklerine odaklanılmıştır:
* **Microservices Orchestration:** Servislerin sorumluluklarına göre (Domain-Driven) ayrıştırılması.
* **Polyglot Persistence:** İhtiyaca göre farklı veri saklama çözümlerinin (NoSQL, Relational, In-Memory) entegrasyonu.
* **Centralized Security:** IdentityServer4 ile merkezi kimlik doğrulama ve yetkilendirme.
* **API Management:** Ocelot üzerinden trafik yönetimi ve güvenlik kalkanı.

---

## 🏗️ Genel Mimari ve Teknoloji Yığını

Sistem, bir **API Gateway** arkasında konumlanmış, birbiriyle izole ve kendi veri kaynaklarına sahip mikroservislerden oluşur.

### 🛠️ Teknolojik Altyapı
| Servis / Araç | Teknoloji | Veri Kaynağı | Açıklama |
| :--- | :--- | :--- | :--- |
| **API Gateway** | Ocelot | - | Tüm istekler için tek giriş noktası ve yönlendirme. |
| **Auth Service** | IdentityServer4 | MSSQL | JWT & OAuth2 tabanlı merkezi güvenlik. |
| **Catalog** | .NET 8 API | **MongoDB** | Esnek şema ve yüksek okuma performansı. |
| **Basket** | .NET 8 API | **Redis** | In-Memory hızında sepet yönetimi. |
| **Order** | .NET 8 API | **MSSQL (EF Core)** | İlişkisel veri ve kompleks sorgu yönetimi. |
| **Discount** | .NET 8 API | **PostgreSQL (Dapper)** | Mikro-ORM ile yüksek performanslı kupon yönetimi. |
| **Web UI** | ASP.NET Core MVC | - | Kullanıcı deneyimi ve servis tüketimi. |

---

## 🧠 Mimari Kararlar: "Neden?"

* **Neden MongoDB (Catalog)?** Menü öğeleri ve ürün özellikleri sık sık değişebildiği için esnek (schemaless) bir yapıya ihtiyaç duyulmuştur.
* **Neden Redis (Basket)?** Kullanıcı sepeti gibi geçici ama hızlı erişilmesi gereken veriler için en optimize çözüm olduğu için tercih edilmiştir.
* **Neden Dapper (Discount)?** İndirim hesaplamaları gibi basit ama yoğun işlemlerde EF Core'un getirdiği yükü azaltmak ve ham SQL performansına yaklaşmak hedeflenmiştir.
* **Neden IdentityServer4?** Her serviste ayrı ayrı Auth katmanı yazmak yerine, güvenliği merkezi bir otoriteye devrederek (SoC) standartlara uygun bir yapı kurulmuştur.

---

## 🧩 Kullanılan Kütüphaneler & Araçlar
* **AutoMapper:** Nesne eşleme (DTO mapping) süreçlerini optimize etmek için.
* **FluentValidation:** İş kurallarını ve validasyonları temiz bir yapıda tutmak için.
* **Docker & Docker Compose:** Tüm ekosistemi tek bir komutla ayağa kaldırabilmek için.
* **SignalR:** Anlık sipariş takibi ve canlı destek modülleri için.

---

## 🐳 Kurulum ve Çalıştırma

Projeyi yerel ortamınızda çalıştırmak için Docker yüklü olması yeterlidir:

```bash
# Projeyi klonlayın
git clone [https://github.com/YunusKucukDev/Restaurant-.NET-API](https://github.com/YunusKucukDev/Restaurant-.NET-API)

# Proje dizinine gidin
cd Restaurant-.NET-API

# Tüm servisleri ayağa kaldırın
docker-compose up -d

<img width="1917" height="908" alt="indirimkuponu" src="https://github.com/user-attachments/assets/7ae67c2e-3cfb-4329-9f8a-19990fe33574" />
<img width="1917" height="908" alt="gelirgidergünlükgece" src="https://github.com/user-attachments/assets/b721f848-6543-469b-845d-b1724aa3c332" />
<img width="1917" height="908" alt="gelirgidergünlük" src="https://github.com/user-attachments/assets/1865a3ba-5853-444c-abef-d5b613eaf9d9" />
<img width="1917" height="908" alt="geçmişsipariş" src="https://github.com/user-attachments/assets/206dcb07-9e6d-4af8-9432-44d84efc41fc" />
<img width="1919" height="908" alt="FinalRapor" src="https://github.com/user-attachments/assets/98f23a66-16e9-4037-abb4-b3423254ecd2" />
<img width="1917" height="908" alt="Dönemselmaliyetanalizi" src="https://github.com/user-attachments/assets/ed0c0926-ad79-4686-a0fe-ab74939844db" />
<img width="1918" height="908" alt="Cart" src="https://github.com/user-attachments/assets/23b61d33-dfe0-4614-84b5-4dda278eaa83" />
<img width="420" height="813" alt="anasayfa2" src="https://github.com/user-attachments/assets/32e9c79b-b963-4c1e-9fd1-00eca0d9f30e" />
<img width="1899" height="906" alt="anasayfa1" src="https://github.com/user-attachments/assets/a68d5830-91bb-4d41-9fbe-729f37593652" />
<img width="1919" height="908" alt="adminŞubeİşlemleri" src="https://github.com/user-attachments/assets/029a9b99-4409-4e24-be5d-5a675408ba8c" />
<img width="1917" height="909" alt="AdminRezervasyon" src="https://github.com/user-attachments/assets/49fc43d3-2419-47e9-ba9f-97a607c39554" />
<img width="1917" height="908" alt="AdminKategoriilemleri" src="https://github.com/user-attachments/assets/6a09ebda-9be0-480c-8b33-e6a34997e8e1" />
<img width="1917" height="911" alt="adminAnasayfa" src="https://github.com/user-attachments/assets/428ddf85-c882-4dd2-92f2-e0209ec28508" />
<img width="1917" height="913" alt="Ürünişlemleri" src="https://github.com/user-attachments/assets/9837f126-29f3-469f-a82b-d0efa4f6dece" />
<img width="1917" height="908" alt="rezervasyon2" src="https://github.com/user-attachments/assets/89036c10-3fe6-4706-9c77-aa2b33da87ac" />
<img width="1917" height="910" alt="rezervasyon1" src="https://github.com/user-attachments/assets/fcb842ba-d676-439c-80da-5dd7710d20eb" />
<img width="1919" height="911" alt="raporlar" src="https://github.com/user-attachments/assets/6d153cb1-d6e9-436e-a494-a32301d8532f" />
<img width="1917" height="908" alt="PaymentSucces" src="https://github.com/user-attachments/assets/5804255b-6f3f-4367-a6f9-2900c878a70a" />
<img width="1919" height="910" alt="payment" src="https://github.com/user-attachments/assets/0cdf1d43-a8c0-48b6-b543-e7828b23327f" />
<img width="1917" height="908" alt="orderDetail" src="https://github.com/user-attachments/assets/5b5914e1-40bd-4661-8c9c-d0e2ddcdd78d" />
<img width="1917" height="908" alt="order" src="https://github.com/user-attachments/assets/2791dc6a-4b31-4c08-af97-f8b8846414ca" />
<img width="1917" height="912" alt="menuişlmeleri" src="https://github.com/user-attachments/assets/ccdba448-a30b-4bf0-b026-740a0b0c6632" />
<img width="1919" height="908" alt="menu1" src="https://github.com/user-attachments/assets/9e30c977-907d-4acb-8e7d-28b29c40eacb" />


