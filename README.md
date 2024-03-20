# Micro-serviço fiap-restaurant-pedido

## Documentação de arquitetura

Foi utilizado o padrão de `coreografia` por se tratar de um sistema com poucos micros-serviços e também com poucas iterações entre suas partes. Por conta disto fica mais cabível o uso deste padrão, fazendo com que o desenvolvimento seja mais rápido, como também a manutenção e entendimento do fluxo seja mais simples oferecendo um desenvolvimento mais ágil.

https://miro.com/app/board/uXjVNjeyIsI=/?share_link_id=668299120113

## OWASP

Verificação original: <a href="./assets/owasp-zap-antes/documento.html">Documento</a>

Verificação após correção: <a href="./assets/owasp-zap-depois/documento.html">Documento</a>

## Exemplo de request de Pedido

```json
{
  "TipoPagamento": 1,
  "Produtos": [
    {
      "NomeProduto": "Hamburguer",
      "ValorProduto": "8.49",
      "Observacao": "Sem tomate"
    },
    {
      "NomeProduto": "Sorverte de Chocolate",
      "ValorProduto": "3.5"
    },
    {
      "NomeProduto": "Coca Cola Pequena",
      "ValorProduto": "5",
      "Observacao": "Sem gelo"
    }
  ]
}
```
