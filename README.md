🍽️ Restaurant Microservices Project

Backend-focused • Learning-oriented • Real-world inspired

Bu proje, yeni mezun bir backend geliştirici olarak mikroservis mimarisi, dağıtık sistemler ve modern .NET backend geliştirme konularında kendimi geliştirmek ve öğrendiklerimi gerçekçi bir senaryo üzerinden göstermek amacıyla geliştirilmiştir.

Amacım; yalnızca çalışan bir uygulama yapmak değil,
neden böyle tasarladım, nerede neyi kullandım sorularına mantıklı cevaplar verebilen bir yapı kurmaktır.

🎯 Proje Amacı

Bu projede özellikle şunları öğrenmeye ve uygulamaya odaklandım:

Mikroservis mimarisinin temel prensipleri

Servislerin sorumluluklarına göre ayrılması

Farklı veri saklama çözümlerinin doğru yerde kullanılması

Token tabanlı kimlik doğrulama (JWT)

API Gateway kullanımı

Docker ile çok servisli uygulama çalıştırma

Bu proje benim için bir öğrenme + uygulama sürecinin çıktısıdır.

🧠 Neden Mikroservis?

Monolit bir yapı yerine mikroservis tercih etmemin nedeni:

Her servisin tek bir işi yapmasını sağlamak

Gerçek hayatta sık kullanılan mimarileri öğrenmek

Servislerin birbirinden bağımsız çalışabilmesini görmek

İleride yeni servisler eklenebilecek bir yapı kurmak

Bu proje, mikroservis mimarisini temel seviyeden ileri seviyeye doğru öğrenme amacıyla tasarlanmıştır.

🏗️ Genel Mimari

Sistem; bir API Gateway, bir Authentication servisi ve farklı iş alanlarına ayrılmış mikroservislerden oluşur.

İstemci (WebUI), tüm istekleri Ocelot API Gateway üzerinden yapar.
Servisler doğrudan dış dünyaya açık değildir.

🔐 IdentityServer4 – Authentication Service

Kullanıcı kimlik doğrulama

JWT token üretimi

OAuth2 / OpenID Connect temelleri

Servislerin güvenli şekilde haberleşmesi

Bu servis sayesinde güvenlik her serviste ayrı ayrı yazılmamıştır.

🚪 Ocelot API Gateway

Tek giriş noktası

İstek yönlendirme (routing)

Token kontrolü

Servislerin dışarıdan gizlenmesi

API Gateway kullanarak merkezi bir kontrol noktası oluşturmayı hedefledim.

🍱 Catalog Microservice (MongoDB)

Ürünler

Kategoriler

Menü bilgileri

Esnek veri yapısı ve okuma performansı nedeniyle MongoDB kullanılmıştır.

🛒 Basket Microservice (Redis)

Kullanıcı sepet bilgileri

Hızlı okuma / yazma

Geçici veri yönetimi

Sepet verileri için Redis (In-Memory) kullanılarak performans kazanımı hedeflenmiştir.

🏷️ Discount Microservice (Dapper)

İndirim kuponları

Kampanyalar

Bu serviste performansı daha yakından gözlemlemek için Dapper kullanılmıştır.

📦 Order Microservice (EF Core)

Siparişler

Sipariş detayları

Adres bilgileri

İlişkisel veri yapısı nedeniyle EF Core + MSSQL tercih edilmiştir.

💻 WebUI (ASP.NET Core MVC)

Kullanıcı arayüzü

API Gateway üzerinden servis tüketimi

Token bazlı istekler

Frontend, backend servisleri test edebilmek için sade tutulmuştur.

🧩 Kullanılan Teknolojiler & Araçlar

ASP.NET Core

Entity Framework Core

Dapper

MongoDB

Redis

IdentityServer4

Ocelot

AutoMapper

FluentValidation

Docker & Docker Compose

Postman

🐳 Kurulum
docker-compose up -d


Tüm servisler ayağa kalktıktan sonra WebUI üzerinden uygulama kullanılabilir.

🚀 Öğrenme & Geliştirme Planı

Bu projeyi geliştirmeye devam ediyorum. Planladığım eklemeler:

Payment Microservice

RabbitMQ ile asenkron iletişim

Notification Service

Unit & Integration Tests

Merkezi loglama (ELK)

✨ Son Söz

Bu proje;

Mikroservis mimarisini öğrenme sürecimi

Backend geliştirme yaklaşımımı

Gerçek hayata yakın bir sistem kurma isteğimi

yansıtan bir çalışmadır.

<img width="1202" height="1600" alt="folder" src="https://github.com/user-attachments/assets/149e4e0e-6c99-44e9-be75-b3273f0e7e7b" />
<img width="1919" height="1600" alt="8" src="https://github.com/user-attachments/assets/d784bea8-c4cf-403a-8217-5063d6fe9d5a" />
<img width="1918" height="1600" alt="7" src="https://github.com/user-attachments/assets/3de97721-31fa-485e-8b07-10a5d2cdebd1" />
<img width="1916" height="1600" alt="5" src="https://github.com/user-attachments/assets/6fedcb65-993c-4ecf-843d-9548a954dd3c" />
<img width="1912" height="1600" alt="4" src="https://github.com/user-attachments/assets/958f5716-1ea7-4a09-9ee2-1d1be403973f" />
<img width="1914" height="1600" alt="3" src="https://github.com/user-attachments/assets/1492bbb3-c9bf-4ad3-a8c5-4f217b301eaa" />
<img width="1907" height="1600" alt="2" src="https://github.com/user-attachments/assets/86e855fe-807e-462b-86fc-f3452dc0b1c8" />
<img width="1917" height="1600" alt="1" src="https://github.com/user-attachments/assets/a61c80f1-84b1-4bff-b0bc-c8762cfb408d" />

