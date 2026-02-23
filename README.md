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


