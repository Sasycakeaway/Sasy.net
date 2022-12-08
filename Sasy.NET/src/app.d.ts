// See https://kit.svelte.dev/docs/types#app
// for information about these interfaces
// and what to do when importing types
declare namespace App {}

declare interface User {
	CF: string;
	Nascita: string;
	News: boolean;
	PK_Email: string;
	Password: string;
	Telefono: string;
	Timestamp: Date;
}

declare interface Data {
	user: User;
}

declare interface Ordini {
	FK_Email: string;
	PK_Id: string;
	Totale: number;
	Cart: string;
	Timestamp: Date;
	Nome: string;
	Cognome: string;
	Indirizzo: string;
	Cap: string;
	Domicilio: string;
}

declare interface DataOrder {
	ordini: Array<Ordini>;
}

declare interface Card {
	nome: string;
	description: string;
	href: string;
	icon: string;
}

declare interface About {
	point: string;
	description: string;
	image: string;
	id: number;
}

declare interface Prodotto {
	nome: string;
	description: string;
	image: string;
	shortDescription: string;
	citazione: string;
	is_single_page: boolean;
	gallery: Array<string>;
	buyable: boolean;
	price: number;
	buyPhrase: string;
}

declare interface Prod{
	prodottoName: string;
	description: string;
	image: string;
	shortDescription: string;
	citazione: string;
	is_single_page: boolean;
	gallery: Array<string>;
	buyable: boolean;
	price: number;
	buyPhrase: string;
}
declare interface Prodotto_Raw {
	fields: Prod
}


declare interface FromForm {
	prod: string;
}

declare interface DropdownProd {
	type: string;
	name: string;
	description: string;
	image: string;
}

declare interface Header_Info {
	title: string;
	subtitle: string;
	image: string;
}

declare interface Register_Response {
	success: boolean;
	message: string;
	email: string;
	newsremove: string;
}

declare interface Reset_Password {
	id: string;
	email: string;
	success: boolean;
}

declare interface Apebox {
	title: string;
	price: number;
	list: string;
	photo: string;
}
