LogConverter

Descrição
O LogConverter é uma aplicação de console desenvolvida para converter arquivos de log do formato "MINHA CDN" para o formato "Agora". A extração de dados desses arquivos auxilia na tomada de decisões para o planejamento de negócios e desenvolvimento. Este projeto utiliza boas práticas de POO, SOLID, testes unitários e mocks.

Índice
Descrição
Índice
Funcionalidades
Tecnologias Utilizadas
Estrutura do Projeto
Instalação
Uso
Testes
Contribuição
Licença
Funcionalidades
Download de arquivos de log de uma URL especificada.
Conversão de logs do formato "MINHA CDN" para o formato "Agora".
Criação de arquivos de saída no formato especificado.
Testes unitários para garantir a robustez da aplicação.
Suporte a paralelismo nos testes para otimização de tempo.
Tecnologias Utilizadas
.NET 8.0
C#
xUnit
Moq
Microsoft.Extensions.DependencyInjection
Microsoft.Extensions.Hosting
Microsoft.Extensions.Http

Estrutura do Projeto
Copiar código
LogConverterProject
│
├── LogConverter.sln
│
├── LogConverter
│   ├── LogConverter.csproj
│   ├── Interfaces
│   │   ├── IFileDownloader.cs
│   │   ├── ILogFormatter.cs
│   │   ├── ILogParser.cs
│   │
│   ├── Models
│   │   └── LogEntry.cs
│   │
│   ├── Services
│   │   ├── FileDownloader.cs
│   │   ├── LogFormatterService.cs
│   │   └── LogParserService.cs
│   │
│   ├── Program.cs
│
├── LogConverter.Tests
│   ├── LogConverter.Tests.csproj
│   ├── FileDownloaderTests.cs
│   ├── LogFormatterServiceTests.cs
│   ├── LogParserServiceTests.cs
│   └── AdditionalLogTests.cs

Instalação
Clone o repositório:

sh
Copiar código
git clone https://github.com/your-username/LogConverter.git
Navegue até o diretório do projeto:

sh
Copiar código
cd LogConverterProject
Restaure as dependências:

sh
Copiar código
dotnet restore
Uso
Para executar a aplicação de conversão de logs, utilize o seguinte comando:

sh
Copiar código
dotnet run --project LogConverter/LogConverter.csproj
A aplicação irá baixar um arquivo de log de uma URL especificada, converter o log para o formato "Agora" e salvar o resultado em um caminho especificado.

Exemplo de uso:
sh
Copiar código
dotnet run --project LogConverter/LogConverter.csproj "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt" "C:\testeTTTN\outputTest.txt"
Testes
Para executar os testes unitários, utilize o seguinte comando:

sh
Copiar código
dotnet test
Os testes irão verificar a funcionalidade dos componentes principais da aplicação, incluindo o downloader de arquivos, o parser de logs e o formatter de logs.

Contribuição
Se você quiser contribuir para este projeto, siga estas etapas:

Faça um fork deste repositório.
Crie um branch: git checkout -b <branch_name>.
Faça suas alterações e confirme-as: git commit -m '<mensagem_de_commit>'.
Envie para o branch original: git push origin <nome_do_projeto>/<local>.
Crie a solicitação de pull.
Como alternativa, consulte a documentação do GitHub sobre como criar uma solicitação de pull.

Licença
Este projeto está licenciado sob a Licença MIT. Veja o arquivo LICENSE para mais detalhes.