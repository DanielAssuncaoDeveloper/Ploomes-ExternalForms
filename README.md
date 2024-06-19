# 📄 Formulários Externos
### Ploomes - Teste Técnico

---
## Sumário

1. [Objetivo do Projeto](#objetivo-do-projeto)
   1. [Tipos de Campos](#tipos-de-campos)
      - [Múltiplas Seleções vs. Múltipla Escolha](#múltiplas-seleções-vs-múltipla-escolha)
2. [Informações sobre o projeto](#informações-sobre-o-projeto)
3. [Rotas da API](#rotas-da-api)
   1. [Formulários](#formulários)
      - [Criar Formulário](#criar-formulário)
      - [Listar Formulários](#listar-formulários)
      - [Atualizar Formulário](#atualizar-formulário)
      - [Alterar Ativação de Formulário](#alterar-ativação-de-formulário)
   2. [Campos Personalizados](#campos-personalizados)
      - [Criar Campo Personalizado](#criar-campo-personalizado)
      - [Listar Campos Personalizados](#listar-campos-personalizados)
      - [Atualizar Campo Personalizado](#atualizar-campo-personalizado)
      - [Alterar Ativação de Campo Personalizado](#alterar-ativação-de-campo-personalizado)
   3. [Tipos de Campo](#tipos-de-campo)
      - [Listar Tipos de Campo](#listar-tipos-de-campo)
   4. [Respostas dos Formulários](#respostas-dos-formulários)
      - [Adicionar Resposta](#adicionar-resposta)
      - [Listar Respostas](#listar-respostas)

---

# Objetivo do Projeto

O objetivo deste projeto é replicar de forma simplificada um dos módulos do sistema de CRM da Ploomes: os **Formulários Externos**. Nesta versão, o fluxo de comportamento do sistema é baseado na criação de um **Modelo de Formulário**, fazendo o vínculo com os chamados **Campos Customizados**, que são campos baseados em tipos de dados que o usuário pode personalizar para cada formulário.

## Tipos de Campos

Os Tipos de Campos pré-cadastrados no sistema são:

- `TypeFieldId:` 01 - (**Texto Simples**)
- `TypeFieldId:` 03 - (**Número Simples**)
- `TypeFieldId:` 06 - (**Data e Hora**)
- `TypeFieldId:` 10 - (**Múltiplas Seleções**)
- `TypeFieldId:` 11 - (**Múltipla Escolha**)

### Múltiplas Seleções vs. Múltipla Escolha
>
>Os tipos de campo mais diferenciados são os de **Múltiplas Seleções** e **Múltipla >Escolha**. Eles permitem que o usuário inclua diversas opções para serem selecionadas na >resposta do formulário.
>
>- **Múltiplas Seleções**: Permite que o usuário selecione diversas opções na resposta.
>- **Múltipla Escolha**: Permite que o usuário selecione somente uma das opções disponíveis.
>
---


# Informações sobre o projeto

### Servidor
- **URL Base**: `https://externalformsapi.azurewebsites.net`

### Modelagem do BD
![image](https://github.com/DanielAssuncaoDeveloper/Ploomes-ExternalForms/assets/119459482/a583c657-1127-4edc-918b-481f5976ae98)

---

# Rotas da API
## Formulários

### Criar Formulário

- URL: `/api/FormModel` </br>
- Método: <b>POST</b>

Corpo da Requisição: 
```json
{
  "name": "Exemplo de Formulário",
  "description": "Descrição do formulário"
}
```

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
{
  "id": 1
}
```

---
### Atualizar Formulário

- URL: `/api/FormModel/{id}` </br>
- Método: <b>PUT</b>
- Parâmetros de rota:
   - `id` (<b>integer</b>, obrigatório)

Corpo da Requisição: 
```json
{
  "name": "Exemplo de Formulário",
  "description": "Descrição do formulário"
}
```

Resposta de Sucesso:
- Código: <b>200 OK</b>


---
### Listar Formulários

- URL: `/api/FormModel` </br>
- Método: <b>GET</b>
- Parâmetros de Consulta:
   - `Name` (<b>string</b>, opcional)
   - `Description` (<b>string</b>, opcional)
   - `ShowInactivated` (<b>boolean</b>, opcional)
   - `Limit` (<b>integer</b>, opcional)
   - `Page` (<b>integer</b>, opcional)


Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
[
  {
    "id": 0,
    "name": "string",
    "description": "string",
    "isInactive": true,
    "lastUpdate": "2024-06-19T13:58:25.589Z"
  }
]
```

---
### Alterar Ativação de Formulário 

- URL: `/api/FormModel/{id}/ChangeActivation` </br>
- Método: <b>PUT</b>
- Parâmetros de rota:
   - `Id` (<b>integer</b>, obrigatório)

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
{
  "isInactive": true
}
```

---
<br>

## Campos Personalizados

### Criar Campo Personalizado
- URL: `/api/FormModel/{idFormModel}/CustomField` </br>
- Método: <b>POST</b>
- Parâmetros de rota:
   - `IdFormModel` (<b>integer</b>, obrigatório)

Corpo da Requisição: 
```json
{
  "name": "string",
  "description": "string",
  "fieldTypeId": 0,
  "isRequired": true,
  "multipleSelections": [
    {
      "name": "string"
    }
  ]
}
```

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
{
  "id": 1
}
```

---

### Atualizar Campo Personalizado

- URL: `api/FormModel/CustomField/{id}` </br>
- Método: <b>PUT</b>
- Parâmetros de rota:
   - `id` (<b>integer</b>, obrigatório)

Corpo da Requisição: 
```json
{
  "name": "string",
  "description": "string",
  "fieldTypeId": 0,
  "isRequired": true,
  "multipleSelections": [
    {
      "name": "string"
    }
  ]
}
```

Resposta de Sucesso:
- Código: <b>200 OK</b>


---
### Listar Campos Personalizados

- URL: `/api/FormModel/{idFormModel}/CustomField` </br>
- Método: <b>GET</b>
- Parâmetros de Consulta:
   - `ShowInactivated` (<b>boolean</b>, opcional)
   - `Limit` (<b>integer</b>, opcional)
   - `Page` (<b>integer</b>, opcional)
- Parâmetro de Rota:
   - `Id` (<b>integer</b>, obrigatório)
 

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
[
  {
    "id": 0,
    "name": "string",
    "description": "string",
    "isRequired": true,
    "lastUpdate": "2024-06-19T14:13:49.041Z",
    "fieldType": {
      "id": 0,
      "name": "string",
      "dataType": {
        "id": 0,
        "name": "string"
      }
    },
    "multipleSelections": [
      {
        "id": 0,
        "name": "string"
      }
    ]
  }
]
```

---
### Alterar Ativação de Campo Personalizado 

- URL: `/api/FormModel/CustomField/{id}/ChangeActivation` </br>
- Método: <b>PUT</b>
- Parâmetros de rota:
   - `Id` (<b>integer</b>, obrigatório)

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
{
  "isInactive": true
}
```

---
<br>

## Tipos de Campos

### Listar Tipos de Campos

- URL: `/api/TypeField` </br>
- Método: <b>GET</b>

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
[
  {
    "id": 0,
    "name": "string",
    "dataType": {
      "id": 0,
      "name": "string"
    }
  }
]
```

---
<br>

## Respostas dos Formulários

### Adicionar Resposta


- URL: `/api/FormModel/{idFormModel}/Answer` </br>
- Método: <b>POST</b>
- Parâmetros de rota:
   - `IdFormModel` (<b>integer</b>, obrigatório)

Corpo da Requisição: 
```json
{
  "answerFields": [
    {
      "customFieldId": 0,
      "dataType": 0,
      "textAnswer": "string",
      "dateTimeAnswer": "2024-06-19T14:27:32.182Z",
      "numericAnswer": 0,
      "multipleSelectionsIdAnswer": [
        0
      ]
    }
  ]
}
```

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
{
  "id": 1
}
```

---

### Listar Respostas dos Formulários

- URL: `/api/FormModel/{idFormModel}/Answer` </br>
- Método: <b>GET</b>
- Parâmetros de rota:
   - `IdFormModel` (<b>integer</b>, obrigatório)

Resposta de Sucesso:
- Código: <b>200 OK</b>
- Exemplo:
```json
[
  {
    "id": 0,
    "answerFields": [
      {
        "customField": {
          "id": 0,
          "name": "string"
        },
        "fieldType": {
          "id": 0,
          "name": "string"
        },
        "textAnswer": "string",
        "datetimeAnswer": "2024-06-19T14:28:44.462Z",
        "numericAnswer": 0,
        "multipleSelectedAnswer": [
          {
            "id": 0,
            "name": "string"
          }
        ]
      }
    ]
  }
]
```
