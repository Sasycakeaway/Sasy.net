import { writable } from 'svelte/store';
export let totale = parseInt(localStorage.getItem('totale'));
export const cartstore = writable('cart');
export const totstore = writable('totale');
let cart = JSON.parse(localStorage.getItem('cart'));
export function initcart() {
	if (localStorage.getItem('cart') == null) {
		cart = [];
	} else {
		cart = JSON.parse(localStorage.getItem('cart'));
	}
	return cart;
}

export function pusha(ida, qty, prezzo, image) {
	let count = 0;
	for (var i = 0; i < cart.length; i++) {
		if (cart[i].id == ida) {
			count++;
			cart[i].qty = cart[i].qty + qty;
		}
	}
	if (count == 0) {
		cart.push({ id: ida, qty: qty, prezzo: prezzo * qty, image: image });
	}
	totale += prezzo * qty;
	totstore.set(totale);
	totstore.subscribe((value) => {
		localStorage.setItem('totale', value);
	});
	cartstore.set(JSON.stringify(cart));
	cartstore.subscribe((value) => {
		localStorage.setItem('cart', value);
	});
}
export function pushatra(prodotti) {
	let trasformista = [];
	prodotti.forEach((prod) => {
		if (document.getElementById(prod).checked) trasformista.push(prod);
	});
	if (trasformista.length == 0) {
		alert(
			'Non hai selezionato nessun ingrediente, il trasformista non è stato aggiunto al carrello.'
		);
	} else if (trasformista.length > 6) {
		alert('Sono stati selezionati più di 6 ingredienti, rimuovere quelli in eccesso.');
		trasformista = [];
	} else {
		cart.push({
			id: 'Il trasformista',
			ingredienti: trasformista,
			prezzo: 18
		});
		totale = totale + 18;
		totstore.set(totale);
		totstore.subscribe((value) => {
			localStorage.setItem('totale', value);
		});
		cartstore.set(JSON.stringify(cart));
		cartstore.subscribe((value) => {
			localStorage.setItem('cart', value);
		});
	}
}
