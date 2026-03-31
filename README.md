# Password Validation API

## Sobre o projeto

Este projeto é uma API para validação de senhas com base em regras pré estabelecidas. Dado uma senha como entrada, a API retorna um booleano indicando se a senha é válida ou não.

O principal objetivo desta implementação foi construir uma solução \*\*simples, bem estruturada e extensível\*\*, aplicando boas práticas de desenvolvimento como \*\*Clean Architecture, SOLID e patterns\*\*.

---

## Regras de validação

Uma senha é considerada válida quando atende a **todos os critérios abaixo**:

* Possui **9 ou mais caracteres**
* Contém **ao menos 1 dígito**
* Contém **ao menos 1 letra minúscula**
* Contém **ao menos 1 letra maiúscula**
* Contém **ao menos 1 caractere especial**
* Caracteres especiais permitidos: `!@#$%^&*()-+`
* **Não possui caracteres repetidos**
* **Não contém espaços em branco**

---

## Como executar

### Pré-requisitos

* .NET 6 ou superior

### Executando a aplicação

```bash
dotnet restore
dotnet run
```

A API estará disponível em:

```
http://localhost:5000/api/password/validate
```

---

## Exemplo de uso

### Request

```json
{
  "password": "AbTp9!fok"
}
```

### Response

```json
{
  "valid": true
}
```

---

## Arquitetura adotada

A solução foi desenvolvida utilizando como base a \*\*Clean Architecture (versão simplificada)\*\*, com separação de responsabilidades:

```
Controller  -> Camada de entrada (HTTP)
Application -> Orquestração do caso de uso
Domain      -> Regras de negócio
```

### Objetivo dessa abordagem

* Manter o domínio **independente**
* Garantir **baixo acoplamento**
* Facilitar **testes e evolução do sistema**

---

## Modelagem da solução

### Regras independentes

As validações foram desenvolvidas como regras independentes através da interface `IPasswordRule`.

Isso permite:

* Adicionar novas regras sem alterar código existente (**Open/Closed Principle**).
* Testar regras isoladamente.
* Evitar estruturas complexas com múltiplos `if`.

Essa abordagem segue o padrão **Strategy Pattern**, onde cada regra representa uma estratégia de validação.

---

### Orquestração centralizada

A classe `PasswordValidation` é responsável por executar todas as regras e consolidar o resultado.

Essa separação garante:

* Clareza de responsabilidades.
* Facilidade de manutenção.
* Melhor organização do domínio.

---

### UseCase como ponto de entrada da regra de negócio

O `ValidatePasswordUseCase` atua como orquestrador da aplicação:

* Recebe a entrada.
* Executa a validação.
* Realiza logging.

Essa abordagem mantém o controller simples e desacoplado da lógica de negócio.

---

## Observabilidade

A aplicação possui logs básicos implementados no UseCase, registrando:

* Início da validação.
* Resultado da validação.
* Regras que falharam.

Importante:

* A senha **não é logada**, garantindo segurança
* Apenas informações não sensíveis (como tamanho da senha) são utilizadas.

---

##  Decisões importantes

### Retorno HTTP sempre 200

A API retorna sempre `200 OK`, independentemente do resultado da validação.

Motivação:

* Senha inválida **não é erro da API**
* É um resultado esperado da regra de negócio.

O status HTTP representa o sucesso da requisição, enquanto o resultado da validação é retornado no corpo da resposta.

---

### Simplicidade vs complexidade

A solução foi propositalmente mantida simples, evitando overengineering.

Por exemplo:

* Não foi utilizado DDD completo.
* Não há camada de infraestrutura (pois não há persistência).
* Não foram criadas abstrações desnecessárias.

Ainda assim, conceitos importantes foram aplicados, como:

* Separação de camadas.
* Isolamento do domínio.
* Modelagem explícita das regras.

---

## Testes

A solução contempla testes unitários para:

* Regras individuais.
* Validador principal.
* Cenários completos.

Execução:

```bash
dotnet test
```

---

## Possíveis evoluções futuras

* Retornar detalhes de erro na API.
* Implementar métricas.
* Adicionar tracing (OpenTelemetry).
---

## Conclusão

A solução foi desenvolvida priorizando:

* Clareza e legibilidade.
* Baixo acoplamento.
* Facilidade de extensão.
* Aderência aos requisitos do desafio.

Com isso, foi possível construir uma API simples, mas com fundamentos sólidos de engenharia de software.

---
