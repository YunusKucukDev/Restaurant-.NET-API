🍽️ Restaurant Microservices Architecture & Ecosystem
Bu proje, bir backend geliştirici olarak mikroservis mimarileri, dağıtık sistemler ve modern yazılım tasarım desenleri üzerindeki yetkinliklerimi sergilemek amacıyla geliştirdiğim uçtan uca bir restoran yönetim ekosistemidir. Projenin ana hedefi, her servisin kendi sorumluluğunu taşıdığı, ölçeklenebilir ve yüksek performanslı bir dijital çözüm üretmektir. 

🚀 Proje Vizyonu ve "Neden Mikroservis?"
Monolitik yapıların aksine, bu projede mikroservis mimarisini tercih etme nedenim; her servisin kendi teknoloji yığınını seçebilmesi (Polyglot Persistence) ve bağımsız olarak ölçeklenebilmesidir. Bu çalışma, karmaşık iş süreçlerini (sipariş, sepet, indirim vb.) parçalayarak yönetilebilir ve sürdürülebilir bir sistem kurma yeteneğimi yansıtmaktadır.

🏗️ Sistem Mimarisi ve Servis Detayları
Proje, birbirleriyle asenkron ve senkron protokoller üzerinden haberleşen bağımsız servislerden oluşur:

1. 🛡️ IdentityServer4 (Auth Service)
Sistemin güvenlik merkezidir. OAuth2 ve OpenID Connect protokollerini kullanarak mikroservisler arası ve kullanıcı bazlı güvenliği yönetir. Tüm istekler buradan alınan JWT (JSON Web Token) ile doğrulanır.

2. 📡 Ocelot API Gateway
İstemciden (WebUI) gelen tüm taleplerin ilk durağıdır. İçerideki servisleri dış dünyadan gizleyerek; yönlendirme (routing), kimlik doğrulama kontrolü ve yük dengeleme gibi kritik görevleri üstlenir.

3. 🍱 Catalog Microservice (MongoDB)
Restoran menüsünü, kategorileri ve ürünleri yönetir. Verilerin esnekliği ve okuma hızının kritik olması nedeniyle NoSQL (MongoDB) ile optimize edilmiştir.

4. 🛒 Basket Microservice (Redis)
Kullanıcı sepetlerini Redis In-Memory Data Store üzerinde tutar. Bu sayede sepet işlemleri milisaniyeler bazında gerçekleşir ve sistemin stateless (durumsuz) kalması sağlanarak yatayda ölçeklenme kabiliyeti artırılmıştır.

5. 🏷️ Discount Microservice (Dapper)
İndirim kuponlarını yönetir. Performansın en üst düzeyde olması amacıyla Dapper (Micro-ORM) kullanılarak MSSQL üzerinde optimize edilmiş SQL sorguları çalıştırır.

6. 📦 Order Microservice (EF Core)
Sipariş kayıtlarını, detaylarını ve adres bilgilerini yönetir. İlişkisel veri bütünlüğü ve karmaşık sorgu süreçleri için Entity Framework Core ile MSSQL üzerinde çalışır.

7. 💻 WebUI (Frontend)
Kullanıcıların sipariş verdiği arayüzdür. ASP.NET Core MVC ile geliştirilmiş olup, tüm mikroservisleri API Gateway üzerinden asenkron olarak tüketir.

🛠️ Teknik Yetkinlikler & Kütüphaneler
Mimari Desenler: Repository Pattern, DTO (Data Transfer Object) Pattern, Singleton, Dependency Injection.

Veri Yönetimi: AutoMapper (Nesne Eşleme), FluentValidation (Merkezi Doğrulama).

Güvenlik: JWT Bearer Token, Policy-Based Authorization.

DevOps & Deployment:

Docker: Tüm servisler ve veritabanları Dockerize edilmiştir.

Docker-Compose: Ekosistemin tek komutla ayağa kaldırılmasını sağlar.

Postman: Tüm API uç noktaları için detaylı test koleksiyonları mevcuttur.

🌟 Öne Çıkan Mühendislik Çözümleri
Right Tool for the Right Job: Ürünler için NoSQL, sepet için In-Memory, sipariş için RDBMS kullanarak veri depolama stratejilerini optimize ettim.

Gateway Authentication: Güvenliği her serviste ayrı ayrı yazmak yerine Ocelot üzerinden merkezileştirdim.

Clean Code: Kod tekrarını önlemek için merkezi kütüphaneler ve genişletilebilir yapılar kurdum.

🛤️ Gelişim Yol Haritası (Future Roadmap)
Kendimi geliştirmeye devam ettiğim bu projede, yakın gelecekte şu modülleri eklemeyi planlıyorum:

Payment Service: Ödeme süreçlerini yöneten izole bir mikroservis.

RabbitMQ Entegrasyonu: Sipariş verildiğinde ödeme ve bildirim servislerini asenkron olarak tetiklemek için Event-Driven mimari.

ELK Stack (Elasticsearch, Logstash, Kibana): Tüm servislerin loglarını merkezi bir noktada toplamak ve izlemek.

Unit & Integration Tests: xUnit ve Moq kullanarak %100'e yakın kod kapsamı (Code Coverage).

🏁 Kurulum ve Çalıştırma
Repoyu bilgisayarınıza klonlayın.

Ana dizinde bir terminal açın.

docker-compose up -d komutunu çalıştırın.

Tüm servisler ayağa kalktıktan sonra tarayıcınızdan https://localhost:7500 adresine gidin.


--Proje Resimlerim --
<img width="1202" height="1600" alt="folder" src="https://github.com/user-attachments/assets/97a8ab25-8371-4d06-a952-5ebb647ae5e5" />
<img width="1202" height="1600" alt="folder" src="https://github.com/user-attachments/assets/97a8ab25-8371-4d06-a952-5ebb647ae5e5" />
<img width="1919" height="1600" alt="8" src="https://github.com/user-attachments/assets/3afd7280-a6c4-425a-9fe9-a51a4bd067fc" />
<img width="1919" height="1600" alt="8" src="https://github.com/user-attachments/assets/3afd7280-a6c4-425a-9fe9-a51a4bd067fc" />
<img width="1918" height="1600" alt="7" src="https://github.com/user-attachments/assets/f77f5605-49f9-4a46-b19b-b65524854493" />
<img width="1918" height="1600" alt="7" src="https://github.com/user-attachments/assets/f77f5605-49f9-4a46-b19b-b65524854493" />
<img width="1916" height="1600" alt="6" src="https://github.com/user-attachments/assets/db33bd13-5011-4f4c-9fee-556962e6f53b" />
<img width="1916" height="1600" alt="6" src="https://github.com/user-attachments/assets/db33bd13-5011-4f4c-9fee-556962e6f53b" />
<img width="1916" height="1600" alt="5" src="https://github.com/user-attachments/assets/76deba06-02e9-44b6-bc19-021d53233604" />
<img width="1916" height="1600" alt="5" src="https://github.com/user-attachments/assets/76deba06-02e9-44b6-bc19-021d53233604" />
<img width="1912" height="1600" alt="4" src="https://github.com/user-attachments/assets/9963b6e3-f4c6-4df8-b8ce-ab866b751413" />
<img width="1912" height="1600" alt="4" src="https://github.com/user-attachments/assets/9963b6e3-f4c6-4df8-b8ce-ab866b751413" />
<img width="1914" height="1600" alt="3" src="https://github.com/user-attachments/assets/45e1ca15-77ec-4d62-bf23-01ee1d9b6b1c" />
<img width="1914" height="1600" alt="3" src="https://github.com/user-attachments/assets/45e1ca15-77ec-4d62-bf23-01ee1d9b6b1c" />
<img width="1907" height="1600" alt="2" src="https://github.com/user-attachments/assets/f13f6a03-9ecb-4d1b-96af-c3e233139d2e" />
<img width="1907" height="1600" alt="2" src="https://github.com/user-attachments/assets/f13f6a03-9ecb-4d1b-96af-c3e233139d2e" />
<img width="1917" height="1600" alt="1" src="https://github.com/user-attachments/assets/cf00b99b-5510-40a9-a097-b680062c75e5" />
<img width="1917" height="1600" alt="1" src="https://github.com/user-attachments/assets/cf00b99b-5510-40a9-a097-b680062c75e5" />

