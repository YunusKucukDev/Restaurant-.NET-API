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


<img width="1917" height="908" alt="geçmişsipariş" src="https://github.com/user-attachments/assets/a437fa55-3d87-4283-8d4c-af8cb56edaa6" />
<img width="1917" height="908" alt="geçmişsipariş" src="https://github.com/user-attachments/assets/a437fa55-3d87-4283-8d4c-af8cb56edaa6" />
<img width="1919" height="908" alt="FinalRapor" src="https://github.com/user-attachments/assets/cff5fe1f-9682-4054-b90c-fbbccc24dcb4" />
<img width="1919" height="908" alt="FinalRapor" src="https://github.com/user-attachments/assets/cff5fe1f-9682-4054-b90c-fbbccc24dcb4" />
<img width="1917" height="908" alt="Dönemselmaliyetanalizi" src="https://github.com/user-attachments/assets/1cff6613-81de-4783-a055-7e6287c5703b" />
<img width="1917" height="908" alt="Dönemselmaliyetanalizi" src="https://github.com/user-attachments/assets/1cff6613-81de-4783-a055-7e6287c5703b" />
<img width="1918" height="908" alt="Cart" src="https://github.com/user-attachments/assets/45ee66f4-1eee-4b1f-a42a-97786adef1f2" />
<img width="1918" height="908" alt="Cart" src="https://github.com/user-attachments/assets/45ee66f4-1eee-4b1f-a42a-97786adef1f2" />
<img width="420" height="813" alt="anasayfa2" src="https://github.com/user-attachments/assets/afeb2581-41df-41fe-b8f7-ed777bd521d2" />
<img width="420" height="813" alt="anasayfa2" src="https://github.com/user-attachments/assets/afeb2581-41df-41fe-b8f7-ed777bd521d2" />
<img width="1899" height="906" alt="anasayfa1" src="https://github.com/user-attachments/assets/66a85fb1-9937-44d7-99d0-c84140f645c2" />
<img width="1899" height="906" alt="anasayfa1" src="https://github.com/user-attachments/assets/66a85fb1-9937-44d7-99d0-c84140f645c2" />
<img width="1919" height="908" alt="adminŞubeİşlemleri" src="https://github.com/user-attachments/assets/fc219e00-41d9-4aac-9060-6bc54b542c16" />
<img width="1919" height="908" alt="adminŞubeİşlemleri" src="https://github.com/user-attachments/assets/fc219e00-41d9-4aac-9060-6bc54b542c16" />
<img width="1917" height="909" alt="AdminRezervasyon" src="https://github.com/user-attachments/assets/8855ab62-1767-4441-8db0-0e70ae6ca10b" />
<img width="1917" height="909" alt="AdminRezervasyon" src="https://github.com/user-attachments/assets/8855ab62-1767-4441-8db0-0e70ae6ca10b" />
<img width="1917" height="908" alt="AdminKategoriilemleri" src="https://github.com/user-attachments/assets/80b07d6d-3884-4695-beb9-ab5dbc6d730b" />
<img width="1917" height="908" alt="AdminKategoriilemleri" src="https://github.com/user-attachments/assets/80b07d6d-3884-4695-beb9-ab5dbc6d730b" />
<img width="1917" height="911" alt="adminAnasayfa" src="https://github.com/user-attachments/assets/9449a500-7fd2-4441-800b-431b5007f1a6" />
<img width="1917" height="911" alt="adminAnasayfa" src="https://github.com/user-attachments/assets/9449a500-7fd2-4441-800b-431b5007f1a6" />
<img width="1917" height="913" alt="Ürünişlemleri" src="https://github.com/user-attachments/assets/0a6079e7-154b-4185-ae8c-fde664583d25" />
<img width="1917" height="913" alt="Ürünişlemleri" src="https://github.com/user-attachments/assets/0a6079e7-154b-4185-ae8c-fde664583d25" />
<img width="1917" height="908" alt="rezervasyon2" src="https://github.com/user-attachments/assets/3fc41cdf-3ce4-4dde-a845-92674075273f" />
<img width="1917" height="908" alt="rezervasyon2" src="https://github.com/user-attachments/assets/3fc41cdf-3ce4-4dde-a845-92674075273f" />
<img width="1917" height="910" alt="rezervasyon1" src="https://github.com/user-attachments/assets/d0f4edb6-b7f7-4f38-88c5-323446e3b4e0" />
<img width="1917" height="910" alt="rezervasyon1" src="https://github.com/user-attachments/assets/d0f4edb6-b7f7-4f38-88c5-323446e3b4e0" />
<img width="1919" height="911" alt="raporlar" src="https://github.com/user-attachments/assets/fd14d1f4-4df3-46d6-85e7-a565e1109448" />
<img width="1919" height="911" alt="raporlar" src="https://github.com/user-attachments/assets/fd14d1f4-4df3-46d6-85e7-a565e1109448" />
<img width="1917" height="908" alt="PaymentSucces" src="https://github.com/user-attachments/assets/fde61bbe-d8be-43d7-8fb9-1011b4f03dce" />
<img width="1917" height="908" alt="PaymentSucces" src="https://github.com/user-attachments/assets/fde61bbe-d8be-43d7-8fb9-1011b4f03dce" />
<img width="1919" height="910" alt="payment" src="https://github.com/user-attachments/assets/1d85503b-4024-42c2-8a85-14967ff3f3c9" />
<img width="1919" height="910" alt="payment" src="https://github.com/user-attachments/assets/1d85503b-4024-42c2-8a85-14967ff3f3c9" />
<img width="1917" height="908" alt="orderDetail" src="https://github.com/user-attachments/assets/57c543d2-c64a-4cd1-938f-3df2cb8a3167" />
<img width="1917" height="908" alt="orderDetail" src="https://github.com/user-attachments/assets/57c543d2-c64a-4cd1-938f-3df2cb8a3167" />
<img width="1917" height="908" alt="order" src="https://github.com/user-attachments/assets/5e6ba344-4e59-4721-abaf-88ef20294b4a" />
<img width="1917" height="908" alt="order" src="https://github.com/user-attachments/assets/5e6ba344-4e59-4721-abaf-88ef20294b4a" />
<img width="1917" height="912" alt="menuişlmeleri" src="https://github.com/user-attachments/assets/a128c31b-f375-4a64-8e49-ab15bbc717b3" />
<img width="1917" height="912" alt="menuişlmeleri" src="https://github.com/user-attachments/assets/a128c31b-f375-4a64-8e49-ab15bbc717b3" />
<img width="1919" height="908" alt="menu1" src="https://github.com/user-attachments/assets/d05c8c39-55f6-43e3-9cb3-5a2a3a6d72ef" />
<img width="1919" height="908" alt="menu1" src="https://github.com/user-attachments/assets/d05c8c39-55f6-43e3-9cb3-5a2a3a6d72ef" />
<img width="1917" height="908" alt="indirimkuponu" src="https://github.com/user-attachments/assets/9a43e1d3-c0c1-407b-b150-6498b133fd70" />
<img width="1917" height="908" alt="indirimkuponu" src="https://github.com/user-attachments/assets/9a43e1d3-c0c1-407b-b150-6498b133fd70" />
<img width="1917" height="908" alt="gelirgidergünlükgece" src="https://github.com/user-attachments/assets/42349351-3b84-4cff-a96a-82fc74c8696a" />
<img width="1917" height="908" alt="gelirgidergünlükgece" src="https://github.com/user-attachments/assets/42349351-3b84-4cff-a96a-82fc74c8696a" />
<img width="1917" height="908" alt="gelirgidergünlük" src="https://github.com/user-attachments/assets/52b30915-f7fd-4d77-ad9f-7cd1da92af01" />
<img width="1917" height="908" alt="gelirgidergünlük" src="https://github.com/user-attachments/assets/52b30915-f7fd-4d77-ad9f-7cd1da92af01" />


