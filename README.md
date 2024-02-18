
EzBuy (Compra Fácil)

Problema/Necessidade:
Realizar compras online/varejo, seja no ramo alimentício, vestuário ou qualquer outro tipo de produtos online (como na Amazon).

Objetivo:

Facilitar os usuários de diversos tipos a realizarem suas compras e receberem em domicílio, principalmente alimentício (há pessoas que precisam de Uber para trazerem suas compras dos supermercados), o sistema terá que implementar um sistema de frete.

Requisitos Funcionais:

Cadastro de Usuário
Cadastro de Produto
Cadastro de Cliente
Cadastro de Tenant (Cliente = Supermercado, Lojas de moda, Lojas de produtos eletrônicos, etc), estratégia multi-tenant.
Venda de produto
Localização via GPS
Levar via frete o produto ao domicílio
Utilizar IA na extração de características do usuário para poder utilizar outro requisito funcional chamado de Implementação de Sistema de recomendação baseado nos gostos do usuário
Se a tenant for do tipo supermercado, implementar o sistema de gerenciamento de compras alimentícias, onde será possível o usuário cadastrar sua “cesta básica mensal” que também fará parte do sistema de recomendação.

Requisitos Não-funcionais:

Desempenho

O sistema deve processar 1000 transações por segundo.
O tempo de resposta para uma solicitação do usuário não deve exceder 2 segundos.

Segurança

A autenticação de usuário deve seguir o padrão de criptografia AES-256.
O sistema deve ser resistente a ataques de negação de serviço.

Usabilidade

A interface do usuário deve ser intuitiva para usuários novatos após 30 minutos de treinamento.
O sistema deve ser acessível para usuários com deficiência visual.

Confiabilidade

O sistema deve ter uma taxa de disponibilidade de 99,9%.
O tempo médio entre falhas (MTBF) deve ser de pelo menos 10.000 horas.

Manutenibilidade

As atualizações de software não devem interromper mais de 10% das funcionalidades existentes.
O código-fonte deve ser bem documentado, com pelo menos 80% de cobertura de documentação.

Portabilidade

O sistema deve ser compatível com os principais navegadores (Chrome, Firefox, Safari).
Deve ser possível executar o software em sistemas operacionais Windows, Linux e macOS.

Eficiência

O sistema deve utilizar no máximo 50% da capacidade de processamento do servidor em condições normais.
Os recursos de memória alocados pelo sistema devem ser liberados eficientemente após o término de uma tarefa.

Tecnologias a Serem Utilizadas (Front, Back, Banco de Dados):

.NET 8 com EntityFramework e Dapper (EF para Escrita no database e Dapper para consulta) se tiver dúvidas, verificar benchmark entre os ORMs
Angular
MySQL
Python
