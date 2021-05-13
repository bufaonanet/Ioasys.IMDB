# Ioasys.IMDB

Projeto de uma API que o site IMDb irá consultar para exibir seu conteúdo, e contem as seguintes funcionalidades:

# Administrador
 - Cadastro
 - Edição
 - Exclusão lógica (desativação)
 - Listagem de usuários não administradores ativos
 - 
# Usuário
- Cadastro
- Edição
- Exclusão lógica (desativação)

# Filmes
 - Cadastro (somente um usuário administrador poderá realizar esse cadastro)
 - Apenas os usuários poderão votar nos filmes
 - Voto (a contagem de votos será feita por usuário de 0-4 que indica quanto o usuário gostou do filme)
 - Listagem
   - Opção de filtros por  nome.
   - Opção de trazer registros paginados

# Tecnologias utilizadas
 - A API construída em .NET Core 3.1 WebAPI
 - Banco de Dados Relacional SQL Server Express LocalDB
 - ORM Entity Frameworkcore 3.1
 
# Observações:  
 - As entidades criadas na API utilizaram a abordagemCode First, onde ha a criação das entidaes para a geração de Migrations para as tabelas.  É necessário rodar as migrações, ou rodar os scripts no projeto para a criação do banco e tabelas.
 - Foi utilizado o padrões REST na construção das rotas e retornos
 - API contem documentação com Swagger com autenticação
 - Utilizado Autorização e Autenticação via padrão JWT com token no formato Bearer
 - Foi utilizado o XUnit para teste unitário
 
