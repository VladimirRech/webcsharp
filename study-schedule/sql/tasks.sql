use manjaro
go

create table tasks
(
    ID int identity(1,1) not null primary key,
    CREATION_DATE datetime not null,
    UPDATE_DATE datetime not null,
    TITLE varchar(100) not null,
    REMOVED bit not null default(0),
    NOTES varchar(2000),
    DUE_DATE datetime
);
go

create index idx_tasks_title 
on tasks (TITLE, REMOVED);

create index idx_tasks_due_date
on tasks (DUE_DATE, REMOVED);

-- Sample data
insert into tasks (CREATION_DATE, UPDATE_DATE, TITLE, NOTES, DUE_DATE)
values            (getdate(), getdate(), 'Ler tutorial da Microsoft e definir tarefas iniciais de implementação', 'Usar os links que estão dentro da pasta do projeto no Git.', NULL),
                  (getdate(), getdate(), 'Iniciar desenvolvimento - resolver problema com requisição', 'Descobrir por que requisições estão retornando o status 307.', NULL),
                  (getdate(), getdate(), 'Encontrar tutorial para API microserviço com dotnet core', 'O tutorial deve contemplar o uso de banco de dados.', '2022-08-11 12:00:00'),
                  (getdate(), getdate(), 'Implementar api de tasks e draft de métodos','Criar API para inserção de tarefas. Implementar os endpoints apenas definindo a assintatura e um retorno padrão', '2022-08-12 12:00:00'),
                  (getdate(), getdate(), 'Implementar classe tasks', '', NULL),
                  (getdate(), getdate(), 'Criar tabelas no banco de dados', '', NULL),
                  (getdate(), getdate(), 'Criar configurações de conexão com o banco com Entity', '', NULL);
go