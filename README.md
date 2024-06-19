# 📄 Formulários Externos
### Ploomes - Teste Técnico

---
### Sumário

1. [Objetivo do Projeto](#objetivo-do-projeto)
   1. [Tipos de Campos](#tipos-de-campos)
      - [Múltiplas Seleções vs. Múltipla Escolha](#múltiplas-seleções-vs-múltipla-escolha)
2. [Rotas da API](#rotas-da-api)
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
   4. [Respostas](#respostas)
      - [Adicionar Resposta](#adicionar-resposta)
      - [Listar Respostas](#listar-respostas)

---

## Objetivo do Projeto

O objetivo deste projeto é replicar de forma simplificada um dos módulos do sistema de CRM da Ploomes: os **Formulários Externos**. Nesta versão, o fluxo de comportamento do sistema é baseado na criação de um **Modelo de Formulário**, fazendo o vínculo com os chamados **Campos Customizados**, que são campos baseados em tipos de dados que o usuário pode personalizar para cada formulário.

## Tipos de Campos

Os Tipos de Campos pré-cadastrados no sistema são:

- **Texto Simples**
- **Número Simples**
- **Data e Hora**
- **Múltiplas Seleções**
- **Múltipla Escolha**

### Múltiplas Seleções vs. Múltipla Escolha

Os tipos de campo mais diferenciados são os de **Múltiplas Seleções** e **Múltipla Escolha**. Eles permitem que o usuário inclua diversas opções para serem selecionadas na resposta do formulário.

- **Múltiplas Seleções**: Permite que o usuário selecione diversas opções na resposta.
- **Múltipla Escolha**: Permite que o usuário selecione somente uma das opções disponíveis.

---


## Informações sobre o projeto

### Servidor
- **URL Base**: `https://externalformsapi.azurewebsites.net`


