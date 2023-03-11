                                        Обзор
Приложение представляет собой CRUD сущностей DrillBlock, DrillBlockPointSet, Hole, HolePointSet, реализованный
на ASP.NET 6. CRUD приложение лишено сервисов приложения и сервисов домена. Доменные сущности не обладают поведением,
а служат лишь контейнерами данных.
    Приложение разрабатывалось на Ubuntu 20.04 в VS Code.

                                    Что не реализовано
1. Валидации DTO и доменных сущностей - например, с помощью библиотеки FluentValidations.
2. Авторизация и аутентификация - например, с помощью JWT и IdentityServer.
3. Миддлвейр обработки ошибок.
4. Фильтры авторизации, действий, обработки исключений и т.п.
5. Контейнерезация, юнит, интеграционное и бенчмарк тестирование и многое другое.

                                Запуск приложения
Для удобства разработки база данных Postgresql развернута в Docker контейнере.
В корне репозитория содержится файл
docker-compose.yaml, создающий контейер с базой данных Posgresql.
Строка соединения базы данных и приложения находится в файлe appsettings.Development.json. 

    Для запуска и просмотра базы данных:
        $ docker-compose up -d
        $ docker exec -it crud_postgres_database /bin/bash
        =$ psql -U "CrudApp" -d "CrudDatabase"

    Для остановки базы данных:
        $ docker-compose down

При запуске приложение слушает входящие HTTP запросы по адресу localhost на порте 5051 (http://localhost:5051).
Приложение предоставляет удобную Swagger API страничку по адресу http://localhost:5051/swagger.

    Для запуска приложения:
    	$ dotnet restore
        $ dotnet run



