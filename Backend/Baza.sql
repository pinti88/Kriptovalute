

use master;
go

drop database if exists kriptovalute;
go

create database kriptovalute collate Croatian_CI_AS; 
go

use kriptovalute;
go

use kriptovalute;

create table korisnici(
korisnik_id int not null primary key identity(1,1),
ime varchar(50) not null,
prezime varchar(50) not null,
email varchar(50),
telefonski_broj varchar(50)
);

create table walleti(
wallet_id int not null primary key identity(1,1),
mreza varchar(50),
korisnik_id int not null references korisnici(korisnik_id),
kljuc varchar(50) not null
);

create table kriptovalute(
kripto_id int not null primary key identity(1,1),
ime varchar(50),
simbol varchar(50),
cijena decimal(10,2),
Trzisna_vrijednost decimal (15,2),
volumen decimal(15,2)
);

create table kriptowalleti(
wallet_id int not null references walleti(wallet_id),
kripto_id int not null references kriptovalute(kripto_id)
);


create table transakcije( 
transakcija_id int not null primary key identity(1,1),
 kolicina decimal(15,2),
 kripto_id int not null references kriptovalute(kripto_id),
 naknada decimal(10,2)
 );

 insert into korisnici(ime, prezime,email,telefonski_broj)
 values
('Ivan', 'Ivić', 'ivan.ivic@email.com', '1234567890'),
('Ana', 'Anić', 'ana.anic@email.com', '0987654321'),
('Marko', 'Marković', 'marko.markovic@email.com', '1122334455'),
('Jovana', 'Jovanović', 'jovana.jovanovic@email.com', '2233445566'),
('Nikola', 'Nikolić', 'nikola.nikolic@email.com', '3344556677'),
('Petar', 'Petrović', 'petar.petrovic@email.com', '4455667788'),
('Maja', 'Majić', 'maja.majić@email.com', '5566778899'),
('Luka', 'Lukić', 'luka.lukic@email.com', '6677889900'),
('Milena', 'Milenković', 'milena.milenkovic@email.com', '7788990011'),
('Jelena', 'Jelenković', 'jelena.jelenkovic@email.com', '8899001122');

insert into walleti(mreza, korisnik_id,kljuc)
values 
('Bitcoin', 1, '1A1zP1eP5QGefi2DMPTfTL5SLmv7DivfNa'),
('Dogecoin', 2, '0x5bD72B66d9a31E5329A7124E63F1C9cF1F9f00E5'),
('Solana', 3, 'B2D9zD27yG55cWs7eGGzV3TChmjEx5G9gTTmFAmYzqV'),
('Ripple', 4, '1N2F1Mb7KGVpPTp5H5u1u3h7sX3dZaAhY'),
('Ethereum', 5, '0x0F8c92c23B4439B6023A60D790129e97C16756a'),
('Solana', 6, 'B6ERmi9gZaNqxhwALnNBHwr8rYKnKBG5XTVo1dMhkEC'),
('Dogecoin', 7, '1A9HX3HFgPyfw75eH8xVckFWxz3y6XvHDk'),
('Ethereum', 8, '0x6F1FDC8c95A7dB63510abD4F9B772fe006e3Bc4D'),
('Ripple', 9, 'B5TBsKw2g9UNuBbeDAfugC9TmtMR1DbK5b6U6DFhNe73'),
('Bitcoin', 10, '1BQdf7kLgHg5TVK9qbz5HjUbAEMt9MhZL6');

insert into kriptovalute(ime, simbol, cijena, Trzisna_vrijednost, volumen)
values
('Bitcoin', 'BTC', 95000.00, 640000000000.00, 5000000000.00),
('Ethereum', 'ETH', 3500.00, 240000000000.00, 3000000000.00),
('Solana', 'SOL', 240.00, 8000000000.00, 150000000.00),
('Ripple', 'XRP', 1.45, 24000000000.00, 2000000000.00),
('Dogecoin', 'DOGE', 0.40, 11000000000.00, 20000000000.00);

insert into kriptowalleti(wallet_id, kripto_id) 
values 
(1, 1),(2, 2),(3, 3), (4, 1), (5, 2), (6, 3), (7, 1), (8, 2), (9, 3), (10,1); 

insert into transakcije(kolicina, kripto_id, naknada)
values  
(1.00, 1, 0.01),   
(10.00, 2, 0.1),    
(100.00, 3, 0.5),   
(200.00, 4, 0.2),   
(500.00, 5, 5.00);  

