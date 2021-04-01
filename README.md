# Api Porter Group Challenge
Project developed to satisfy all the requirements for porter group challenge.


## Generate migrations:

Run the below command:
```console
dotnet ef migrations add Init --startup-project .\src\ApiRestPorter.Web\ --project .\src\ApiRestPorter.Infrastructure\
```


## Running project through terminal:

```console
dotnet run --project .\src\ApiRestPorter.Web\
```

You can access the api docs with the following url:
https://localhost:5000/swagger/index.html

## Running through Docker:

```console
docker-compose build
docker-compose up
```

You can access the api docs with the following url:
localhost:8888/swagger/index.html
