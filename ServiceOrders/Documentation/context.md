# Контекст решения
<!-- Окружение системы (роли, участники, внешние системы) и связи системы с ним. Диаграмма контекста C4 и текстовое описание. 
-->
```plantuml
@startuml
!include https://raw.githubusercontent.com/plantuml-stdlib/C4-PlantUML/master/C4_Container.puml

Person(admin, "Администратор")
Person(moderator, "Модератор")
Person(user, "Пользователь")

System(conference_site, "Сайт заказа услуг", "Веб-сайт для просмотра и заказа услуг")



Rel(admin, conference_site, "Просмотр, добавление и редактирование информации о пользователях, услугах и заказах")
Rel(moderator, conference_site, "Модерация контента и пользователей")
Rel(user, conference_site, "Регистрация, просмотр информации об услугах, создание заказов")



@enduml
```
## Назначение систем
|Система| Описание|
|-------|---------|
| Сайт заказа услуг | Веб-интерфейс, обеспечивающий доступ к услугам. Бэкенд сервиса реализован в виде микросервисной архитектуры |
