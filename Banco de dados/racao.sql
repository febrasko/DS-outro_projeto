create database casa_racao;
use casa_racao;

create table enderecos(
cep int primary key, -- int ou char(8)?
estado char(2) not null,
cidade varchar(100) not null,
bairro varchar(100) not null,
rua varchar(100) not null
);

create table funcionarios(
id int primary key auto_increment,
cep_endereco int,
nome varchar(150) not null,
cargo varchar(100),
salario decimal(10,2),
nascimento date,
cpf char(11),
tel varchar(11),
numero int,
complemento varchar(20),
foreign key (cep_endereco) references enderecos(cep)
);

create table clientes(
id int primary key auto_increment,
cep_endereco int,
nome varchar(150) not null,
tel varchar(11),
-- email? --
cpf char(11),
numero int,
complemento varchar(20),
foreign key (cep_endereco) references enderecos(cep)
);

create table fornecedores(
id int primary key auto_increment,
cep_endereco int,
nome varchar(100) not null,
cnpj varchar (20),
tel varchar(11),
numero int,
complemento varchar(20),
foreign key (cep_endereco) references enderecos(cep)
);

-- produtos tem fornecedores ou fornecedores tem produtos 🤔
create table produtos(
id int primary key auto_increment,
id_fornecedor int,
nome varchar(50) not null,
valor decimal(10,2) not null,
marca varchar(100),
qtd int,
descricao text,
foreign key (id_fornecedor) references fornecedores(id)
);
SELECT p.nome as produto, f.nome as fornecedor, marca, valor, descricao, qtd
FROM produtos p
join fornecedores f on f.id = p.id_fornecedor;

create table vendas(
id int primary key,
id_funcionario int,
id_cliente int, -- opcional
datahora datetime,
valor decimal(10,2),
foreign key (id_funcionario) references funcionarios(id),
foreign key (id_cliente) references clientes(id)
);

create table vendaitem(
id int primary key auto_increment,
id_venda int,
id_produto int,
qtd int,
valoritem decimal(10,2),
foreign key (id_venda) references vendas(id),
foreign key (id_produto) references produtos(id)
);

create table agendamento(
id int primary key auto_increment,
id_cliente int,
cep_endereco int,
numero int,
complemento varchar(20),
datamensal varchar(20),
precomensal decimal(10,2),
obs text,
foreign key (id_cliente) references clientes(id),
foreign key (cep_endereco) references enderecos(cep)
);