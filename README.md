
# Bryan Parking Lot

Este projeto representa uma API construída em ASP.NET CORE que faz alusão a um estacionamnto, como aqueles que tem no centro da sua cidade :)

Com relação 1:1, UM cliente pode estacionar UM carro, levando em consideração que não trabalhamos com diária!

![e3f1c18d-20a6-40f9-8675-bdb688dd1944](https://github.com/bielgennaro/BryanParkingLot/assets/102267952/ff509b18-b1e2-492d-b08c-b57a6a4e82d8)


## Stack utilizada

**Front-end:** Angular

**Back-end:** ASP.NET, EntityFramework, Sqlite

**Documentação:** Swagger


## Rodando os testes

Para rodar as migrations, rode o seguinte comando

```bash
  dotnet ef migrations add <nomeDaMigration>
```
Logo em seguida(irá rodar a migration mais recente!):
```bash
  dotnet ef database update
```

## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/bielgennaro/BryanParkingLot
```

Entre no diretório do projeto

```bash
  cd BryanParkingLot
```

Rode um build

```bash
    dotnet run build
```

E em seguida

```bash
    dotnet run
```

