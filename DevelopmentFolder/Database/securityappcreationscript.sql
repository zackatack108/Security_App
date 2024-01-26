/*set search_path to public;
create schema if not exists securityapp;
set search_path to securityapp;*/

create table if not exists client (
	id serial primary key, 
	username text not null,
	password text not null
);

insert into client (username, password) values ('Tom Riddle', 'VoldyIsTheBest!');