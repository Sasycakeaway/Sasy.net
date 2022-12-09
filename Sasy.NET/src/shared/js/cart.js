let totale;
let cart;
export function initcart() {
	const cart_store = localStorage.getItem('cart');
	if ( cart_store == null) {
		return [];
	} else {
		return JSON.parse(cart_store);
	}
}

export function init_totale(){
	const totale_store = localStorage.getItem('totale');
	if(totale == null)
		return 0;
	else 
		return totale;
}

export function pusha(ida, qty, prezzo, image) {
	cart = initcart();
	totale = init_totale();
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
	localStorage.setItem('totale', totale);
	localStorage.setItem('cart', JSON.stringify(cart));
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
		localStorage.setItem('totale', totale);
		localStorage.setItem('cart', JSON.stringify(cart));
	}
}
