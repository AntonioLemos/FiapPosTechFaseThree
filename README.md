# Projeto de Arquitetura .NET

## Visão Geral

Este projeto é uma aplicação .NET dividida em quatro APIs, cada uma com funcionalidades distintas. Utilizamos GitHub Actions para automatizar a construção e publicação das imagens Docker, garantindo um build isolado para cada API.

## Estrutura do Projeto

O projeto é composto pelas seguintes APIs:

- **API de Cadastro**: Responsável pela criação de novos registros.
- **API de Alteração**: Permite modificar registros existentes.
- **API de Exclusão**: Facilita a remoção de registros.
- **API de Consulta**: Fornece funcionalidades para leitura dos dados.

## Arquitetura

- **Microserviços**: As APIs são implementadas como microserviços, com três delas utilizando filas para comunicação assíncrona.
- **Fila**: Utilizamos RabbitMQ com MassTransit para gerenciar as filas de mensagens. As APIs de Cadastro, Alteração e Exclusão possuem filas dedicadas.
- **Banco de Dados**: Optamos por um único banco de dados, pois apenas duas tabelas são necessárias para os microserviços.

## Observabilidade

- **OpenTelemetry**: Implementado para rastreamento e monitoramento das APIs.
- **Prometheus**: Utilizado para coleta e armazenamento de métricas.
- **Grafana**: Empregado para visualização das métricas coletadas pelo Prometheus.

## Automatização e Build

Criamos quatro workflows no GitHub Actions para isolar a construção e publicação das imagens Docker:

1. **Workflow 1**: API de Cadastro
2. **Workflow 2**: API de Alteração
3. **Workflow 3**: API de Exclusão
4. **Workflow 4**: API de Consulta

![image](https://github.com/user-attachments/assets/a89a59c7-bfe9-4581-9b90-d41f3800b74b)

## Docker Compose

O projeto utiliza Docker Compose para gerenciar e orquestrar os seguintes serviços:

- **sqlserver**: Banco de dados SQL Server. Mapeia a porta `1433` e utiliza o volume `sqlserver-data` para persistência.
- **rabbitmq**: Broker de mensagens RabbitMQ. Mapeia as portas `15672` (administração) e `5672` (mensagens).
- **consultaapi, cadastroapi, alteraapi, deletaapi**: APIs para consulta, criação, alteração e exclusão de registros, respectivamente. Cada uma expõe portas específicas e se conecta à rede `monitoring`. Utilizam o endpoint `Otel__Endpoint` para integração com OpenTelemetry.
- **otlp-collector**: Coletor OpenTelemetry para rastreamento e monitoramento. Mapeia várias portas e monta a configuração do coletor.
- **prometheus**: Sistema de monitoramento. Mapeia a porta `9090` e utiliza o volume `prometheus-data`.
- **grafana**: Plataforma de visualização de métricas. Mapeia a porta `3000` e utiliza o volume `grafana-data`.
- **node_exporter**: Exportador de métricas do sistema operacional para o Prometheus. Coleta métricas do host.
- **consumer** e **productor**: Serviços para processamento e produção de mensagens. Expõem portas específicas e se conectam à rede `monitoring`.

Todos os serviços estão conectados à rede `monitoring` para garantir a comunicação e integração entre eles.

![image](https://github.com/user-attachments/assets/a5d9cefc-4a9f-44e1-bed4-0261a60e957a)

## Implementação das Filas

As APIs de Cadastro, Alteração e Exclusão interagem com filas específicas do RabbitMQ para garantir comunicação assíncrona eficaz. A API de Consulta não utiliza filas.

## Testes

O projeto inclui testes de integração e unitários para garantir a qualidade e a funcionalidade das APIs.

## Observabilidade e Monitoramento

- **OpenTelemetry**: Fornece rastreamento detalhado das operações.
- **Prometheus**: Coleta métricas de desempenho.
- **Grafana**: Exibe dados coletados pelo Prometheus.

![image](https://github.com/user-attachments/assets/475efb1d-d5ae-4b70-b16f-09c066f2780e)
