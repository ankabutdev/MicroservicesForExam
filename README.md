# Mening Loyiham

Bu mening 100 Days of Code chellendjida qatnashish va imtihonga tayyorlanish uchun yaratilgan. Men endi quyidagi texnologiyalardan foydalanmoqdaman:

## Texnologiyalar

- **Docker:** Ma'lum bir murojaatni umumiy hamma ishlatishi uchun konteynerlashtirish.
- **Microservice:** Loyiha, bir nechta xizmatlarni alohida xizmatlar sifatida ishlatadi.
- **Docker Compose:** Ma'lum bir loyhaning barcha xizmatlarini bir joyda ishga tushirishim uchun.

- **Postgresql:** Ma'lum bir ma'lumotlar bazasini saqlash uchun.

- **CQRS, MediatR:** Barcha so'rovlar va buyurtmalar uchun CQRS patternini va MediatR kutubxonasini ishlatish.

- **Clean Architecture:** Loyiha kodlarini tozalash va tuzish uchun masofaviy arxitektura.

- **Caching => Redis:** Ma'lumotlar keshlash uchun Redisni ishlatish.

- **JWT:** Maxfiylik uchun JSON Web Token (JWT) autentifikatsiyasi.

- **API Gateway:** Barcha xizmatlarga kirishni boshqarish uchun API Gateway.

- **Fluent API:** Qulay, chaqaloq va ma'lumotlar kiritish uchun Fluent API ishlatish.

## Talablar
 Sizning kampyuteringizda shu dasturlar o'rnatilgan bo'lishi kerak
 **docker** va **Sql Server**

## Loyiha Haqida

Loyiha quyidagi Servicelarga ega:

1. **Game-Club**
2. **Nikoh-FHDYO**
3. **OLX**
4. **Kindergarten**

## Loyiha O'rnatish

Loyiha kodlarini o'rnatish uchun quyidagi bosqichlarni bajarishni unutmang:
1. **Loyihani clone qilasiz**
**HTTPS**
```bash
https://github.com/ankabutdev/MicroservicesForExam.git
```
**SSH**
```bash
git@github.com:ankabutdev/MicroservicesForExam.git
```
2. **Dockerni ishga tushirasiz**\
***ESLATMA***\
*Docker composeni ishga tushurishdan oldin hamma containerlarni toxtatib o'chirib tashlang o'chirib tashlashni tavsiya etaman*\
**Toxtatish uchun**
```bash
docker container prune
```
3. **Ishga tushirish uchun**
```bash
docker-compose up
```
(example)\
  ***GameClub***\
**Barcha Get All So'rovlari**\
     - /admins\
     - /computers\
     - /players\
     - /sochs\
     <br />
**Get By Id** (example)\
     - /admins/2\
     - /computers/2\
     - /players/2\
     - /sochs/2\
     <br />
**DELETE** (example)\
     - /admins/2\
     - /computers/2\
     - /players/2\
     - /sochs/2\
     <br />
**Barcha POST So'rovlari**\
 bodyda jo'natiladi!\
     - /admins\
     - /computers\
     - /players\
     - /sochs\
 <br />
 **PUT** (example)\
 ma'lumotlari bodyda Id esa urlda\
     - /admins/2\
     - /computers/2\
     - /players/2\
     - /sochs/2\
 <br />
