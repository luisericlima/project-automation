# Teste Automatizado com Selenium e xUnit

Este projeto contém um teste automatizado de interface utilizando **Selenium WebDriver**, **xUnit** e **FluentAssertions** para validar o título da página inicial do Google.

## O que é testado?

O teste acessa a página inicial do Google e verifica se o título da página contém a palavra `"Google"`. Caso a página não carregue corretamente, uma captura de tela é salva automaticamente na pasta `/screenshots`.

## 🛠️ Tecnologias Utilizadas

- [.NET 9 ou superior](https://dotnet.microsoft.com/)
- [Selenium WebDriver](https://www.selenium.dev/)
- [xUnit](https://xunit.net/)
- [FluentAssertions](https://fluentassertions.com/)
- [ChromeDriver](https://sites.google.com/a/chromium.org/chromedriver/)

## Como Executar os Testes

Necessário o SDK do .NET está instalado. 

Para rodar os testes execute o comando:

```bash
dotnet test
```

## 📸 Captura de Tela em Caso de Erro
Se o teste falhar, será gerada automaticamente uma imagem (.png) da tela no momento do erro. O arquivo é salvo na pasta screenshots com um nome contendo a data e hora do erro.


## Exemplo de Teste
Teste bem-sucedido
```
[Fact]

public void GoogleHomePage_DeveConterTituloGoogle()
{
    Driver.Navigate().GoToUrl("https://www.google.com");
    Driver.Title.Should().Contain("Google");
}
```
Este teste acessa a página correta do Google e valida se o título contém a palavra "Google".

Teste de falha proposital
```
[Fact]
public void GoogleHomePage_DeveConterTituloGoogle()
{
    using var driver = new ChromeDriver();

    driver.Navigate().GoToUrl("https://www.gogle.com");
    driver.Title.Should().Contain("Google");
}
```
<img width="1904" height="933" alt="erro_20250804_123644" src="https://github.com/user-attachments/assets/3a85f89f-ab79-4ab4-bded-db5db1a96639" />

Obs: A URL "https://www.gogle.com" está propositalmente errada para demonstrar a captura de tela em caso de falha.

## 📁 Estrutura de Pastas
```
TestesAutomatizados/
├── .github/
│   └── workflows/
│       └── dotnet-tests.yml
├── screenshots/
│   └── erro_YYYYMMDD_HHmmss.png
├── tests/
│   ├── BaseTest.cs
│   ├── GoogleHomePageTests.cs
│   └── ScreenshotConfiguration.cs
├── .gitignore
├── automation-mereo.csproj
├── automation-mereo.sln
└── README.md
```


