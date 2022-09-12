# ContactApp

Proje geliştirilirken mongodb veri tabanı ve rebbitmq message broken kullanılmıştır. 

Projenin bir bütün olarak çalışması için uygulamanın çalışacağı sunucuda rabbitmq ve mongodb kurulu olmalıdır. 

- MongoDB connection string bilgileri her iki servisin api projesinin __appsettings.json__ dosyası içerisinden gerekli konfigurasyona göre değiştirilmelidir. 
- RabbitMQ bağlantı ve kullanıcı adı şifre bilgileri __Report.Shares.RabbitMq__ klasöründeki __RabbitMQConstants__ sınıfı içerisinden değiştirilmelidir. 

Çalıştırılması gereken projeler; 
- src/Services/ContactService/Contact.API
- src/Services/ReportService/Report.API
- src/Services/ReportService/BackgroundService/reportBgService
