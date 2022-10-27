create database pet_shop;
use pet_shop;

create table cadFuncionarios(
nmFunc varchar(100),
dtNascimento date,
cpf char(11),
endereco varchar(200),
tel varchar(11),
cdFunc int(4) zerofill primary key auto_increment
);
insert into cadFuncionarios
values('Cleyton','20020923','12345678901','Rua das Camélias','40028922',01),
('Jerisvaldo','20001024','12344578901','Rua das Freiras','40046722',02),
('Lukaos','19781113','33345678902','Rua do Sofrimento','1195679022',03),
('Scania','20050407','12345678903','Rua Catarse','11940028922',04);
select*from cadFuncionarios;

create table cadProdutos(
cdProd int(4) zerofill primary key auto_increment,
nmProd varchar(50),
valor decimal (18,2),
Qtd int,
undMedida varchar (10),
marca varchar (100)
);
insert into cadProdutos
values(01, 'Shampoo de cachorro', 10,'12', 'Litros', 'Milas Kei'),
(02, 'Ração de cachorro', 15.37,'20', 'Kilos', 'Pedgree'),
(03, 'Ração de gato', 17.35, '13','Kilos', 'Whiskas'),
(04, 'Shampoo de gato', 20,'14', 'Litros', 'Mindasei');
select*from cadProdutos;

create table cadFornecedor(
cdForn int(4) zerofill primary key auto_increment,
cnpj varchar (20),
nmForn varchar(100),
prodForn varchar(100),
endereco varchar(100),
tel varchar(11)
);
insert into cadFornecedor
values(01,'1234567891234','Ração dukão','Ração de cachorro','Rua das cabras','11923456789'),
(02,'1234567891234','Ração dugato','Ração de gato','Rua das cabras','11923456789'),
(03,'1234567891234','Shmpooo dukão','shampoo de cachorro','Rua das pratas','11923456789'),
(04,'1234567891234','Shampoo dugato','shampoo de cachorro','Rua risos','11923456789');
select*from cadFornecedor;

create table agendamento(
cdAgendamento int(4) zerofill primary key auto_increment,
nmResponsavel varchar (100),
nmAnimal varchar(100),
tpServiço varchar(30),
dtAgendamento date,
obs varchar(500)
);
insert into agendamento
values(01,'Valdo','plinio','banho','20220305','cobrir orelhas'),
(02,'Lucia','floco','tosa','20220305','cortar unhas'),
(03,'Mateus','bolão','banho','20220706','cobrir orelhas'),
(04,'Eduardo','plinio','tosa','20220412','manter pelo do peito');
select*from agendamento;