# Sistema de Pagamento Biométrico

Aplicação desktop em C#/.NET para cadastro biométrico de clientes, tokenização de cartão e confirmação de pagamento com validação por impressão digital.

> English version below.

## Visão geral

Este projeto foi desenvolvido como uma aplicação Windows Forms para simular um fluxo de pagamento em posto de combustível:

1. Cadastro da impressão digital do cliente com SDK Nitgen NBioBSP.
2. Armazenamento dos dados biométricos em Oracle.
3. Cadastro do cliente e tokenização de cartão via API.
4. Verificação biométrica antes da escolha do combustível.
5. Confirmação de pagamento usando o token do cartão cadastrado.

## Principais recursos

- Cadastro biométrico com geração de identificador único.
- Captura e verificação de digital usando `NITGEN.SDK.NBioBSP`.
- Armazenamento de FIR textual/binário e hash SHA-256 da digital.
- Persistência em Oracle com `Oracle.ManagedDataAccess`.
- Integração HTTP com `RestSharp`.
- Fluxo de cadastro de cliente, tokenização de cartão e processamento de pagamento.
- Interface desktop em Windows Forms.

## Stack

- C# / .NET 8
- Windows Forms
- SDK Nitgen NBioBSP
- Oracle Database
- RestSharp
- Newtonsoft.Json
- Integração de pagamentos em ambiente sandbox

## Configuração

O projeto não deve versionar tokens, senhas ou strings de conexão reais. Configure os valores por variáveis de ambiente ou pelo `app.config` local.

Variáveis aceitas:

```powershell
$env:ORACLE_CONNECTION_STRING = "User Id=...;Password=...;Data Source=..."
$env:ASAAS_ACCESS_TOKEN = "seu-token-sandbox"
$env:ASAAS_BASE_URL = "https://api-sandbox.asaas.com/v3"
```

Também é possível preencher localmente:

```xml
<add key="OracleConnectionString" value="..." />
<add key="AsaasAccessToken" value="..." />
<add key="AsaasBaseUrl" value="https://api-sandbox.asaas.com/v3" />
```

## Segurança

- Tokens e senhas reais foram removidos do código.
- Se algum token já foi publicado anteriormente no histórico do repositório, ele deve ser revogado/rotacionado no provedor.
- Dados de cartão não devem ser logados em console, arquivo ou interface.
- O projeto deve ser tratado como ambiente de estudo/sandbox, não como implementação pronta para produção.

## Como executar

Pré-requisitos:

- Windows
- .NET SDK compatível com .NET 8
- Oracle Database acessível
- SDK Nitgen NBioBSP instalado
- Credenciais de sandbox da API de pagamentos

Comandos:

```powershell
dotnet restore
dotnet build
dotnet run --project .\ProjetoFinal\ProjetoFinal.csproj
```

---

# Biometric Payment System

Desktop C#/.NET application for customer biometric enrollment, card tokenization, and payment confirmation using fingerprint verification.

## Overview

This project was built as a Windows Forms application simulating a fuel-station payment flow:

1. Enroll customer fingerprint with the Nitgen NBioBSP SDK.
2. Store biometric data in Oracle.
3. Register customer data and tokenize card details through an external API.
4. Verify fingerprint before fuel selection.
5. Confirm payment using the saved card token.

## Key features

- Biometric enrollment with unique customer identifier.
- Fingerprint capture and verification using `NITGEN.SDK.NBioBSP`.
- Storage of textual/binary FIR data and SHA-256 fingerprint hash.
- Oracle persistence with `Oracle.ManagedDataAccess`.
- HTTP integration with `RestSharp`.
- Customer registration, card tokenization, and payment processing flow.
- Windows Forms desktop UI.

## Tech stack

- C# / .NET 8
- Windows Forms
- Nitgen NBioBSP SDK
- Oracle Database
- RestSharp
- Newtonsoft.Json
- Sandbox payment API integration

## Configuration

The repository must not contain real tokens, passwords, or connection strings. Use environment variables or a local `app.config`.

Supported environment variables:

```powershell
$env:ORACLE_CONNECTION_STRING = "User Id=...;Password=...;Data Source=..."
$env:ASAAS_ACCESS_TOKEN = "your-sandbox-token"
$env:ASAAS_BASE_URL = "https://api-sandbox.asaas.com/v3"
```

## Security notes

- Real tokens and passwords were removed from source code.
- If any token was previously published in repository history, revoke/rotate it in the provider dashboard.
- Card data must not be logged to console, files, or UI.
- This is a study/sandbox project, not a production-ready payment implementation.
