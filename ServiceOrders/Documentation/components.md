# Компонентная архитектура
<!-- Состав и взаимосвязи компонентов системы между собой и внешними системами с указанием протоколов, ключевые технологии, используемые для реализации компонентов.
Диаграмма контейнеров C4 и текстовое описание. 
-->
## Компонентная диаграмма

```plantuml
@startuml
!include https://raw.githubusercontent.com/plantuml-stdlib/C4-PlantUML/master/C4_Container.puml

AddElementTag("microService", $shape=EightSidedShape(), $bgColor="CornflowerBlue", $fontColor="white", $legendText="microservice")
AddElementTag("storage", $shape=RoundedBoxShape(), $bgColor="lightSkyBlue", $fontColor="white")

Person(admin, "Администратор")
Person(moderator, "Модератор")
Person(user, "Пользователь")

System_Ext(web_site, "Клиентский веб-сайт", "HTML, CSS, JavaScript, React", "Веб-интерфейс")

System_Boundary(conference_site, "Сайт заказа услуг") {
   Container(client_service, "Сервис авторизации", "C++", "Сервис управления пользователями", $tags = "microService")    
   Container(post_service, "Сервис услуг", "C++", "Сервис управления услугами", $tags = "microService") 
   Container(blog_service, "Сервис заказов", "C++", "Сервис управления заказами", $tags = "microService")   
   ContainerDb(db, "База данных", "MySQL", "Хранение данных об услугах, заказах и пользователях", $tags = "storage")
   
}

Rel(admin, web_site, "Просмотр, добавление и редактирование информации о пользователях, услугах и заказах")
Rel(moderator, web_site, "Модерация контента и пользователей")
Rel(user, web_site, "Регистрация, просмотр информации об услугах, создание заказов")

Rel(web_site, client_service, "Работа с пользователями", "localhost/person")
Rel(client_service, db, "INSERT/SELECT/UPDATE/DELETE", "SQL")

Rel(web_site, post_service, "Работа с услугами", "localhost/service")
Rel(post_service, db, "INSERT/SELECT/UPDATE/DELETE", "SQL")

Rel(web_site, blog_service, "Работа с заказами", "localhost/order")
Rel(blog_service, db, "INSERT/SELECT/UPDATE/DELETE", "SQL")

@enduml
```
## Список компонентов  

### Сервис авторизации
**API**:
-	Создание нового пользователя
      - входные параметры: login, пароль, имя, фамилия, email, обращение (г-н/г-жа)
      - выходные параметры: отсутствуют
-	Поиск пользователя по логину
     - входные параметры:  login
     - выходные параметры: идентификатор пользователя, имя, фамилия, email, обращение (г-н/г-жа)
-	Поиск пользователя по маске имени и фамилии
     - входные параметры: маска фамилии, маска имени
     - выходные параметры: идентификатор пользователя, login, имя, фамилия, email, обращение (г-н/г-жа)

### Сервис услуг
**API**:
- Создание услуги
  - Входные параметры: название услуги, категория, информация об услуге, цена
  - Выходные параметры: идентификатор услуги
- Получение списка услуг
  - Входные параметры: отсутствуют
  - Выходные параметры: массив услуг, где для каждой указаны ее идентификатор, название, категория, информация и цена

### Сервис заказов
**API**:
- Добавление услуги в заказ
  - Входные параметры: id пользователя, идентификатор услуги, дата заказа
  - Выходные параметры: идентификатор заказа
- Получение заказа для пользователя
  - Входные параметры: логин пользователя
  - Выходные параметры: идентификатор заказа, дата заказа, массив услуг с названиями и ценами



### Модель данных
```puml
@startuml

class Order {
  id
  date
  user_id
  service_ids
}

class User {
  id
  login
  first_name
  last_name
  email
  title
}

class Service {
  id
  title
  category
  info
  price
}

User <- Order
Order "1" --> "0..*" Service : Contains

@enduml
```