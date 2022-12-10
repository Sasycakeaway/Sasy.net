import md5 from "md5";
import {dialogs} from "svelte-dialogs";

let totale;
let cart;
export async function initcart() {
	return await (await fetch("/api/Cart")).json();
}

export async function init_totale(){
	let cart = await initcart();
	let totale = 0;
	cart.forEach(prod => {
		totale += prod.costo;
	});
	return totale;
}

export async function pusha(ida, qty, prezzo, image) {
	const cookies = document.cookie.split(";");
	cookies.forEach(cookie => {
		if(cookie.includes("username")){
			if(cookie.split("=")[1].replace("%40", "@") == null){
				dialogs.alert("Per aggiungere prodotti al carrello devi registrarti sul sito");
				return false;
			}
		}else{
			dialogs.alert("Per aggiungere prodotti al carrello devi registrarti sul sito");
			return false;
		}

	});
	var myHeaders = new Headers();
	myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

	var urlencoded = new URLSearchParams();
	urlencoded.append("prodotto", ida);
	urlencoded.append("qty", qty);
	urlencoded.append("costo", prezzo);
	// urlencoded.append("image", image);

	var requestOptions = {
		method: "POST",
		headers: myHeaders,
		body: urlencoded,
		redirect: "follow",
	};

	fetch("/api/Cart", requestOptions)
		.then((response) => response.text())
		.then((result) => {
			if(result){
				dialogs.alert("Prodotto aggiunto al carrello");
			}else{
				dialogs.alert("Errore durante l'inserimento nel carrello");
			}
		})
		.catch((error) => {
			dialogs.alert("Errore durante l'inserimento nel carrello");
		});
}
export function pushatra(prodotti) {
	const cookies = document.cookie.split(";");
	cookies.forEach(cookie => {
		if(cookie.includes("username"))
			if(cookie.split("=")[1].replace("%40", "@") == null){
				dialogs.alert("Per aggiungere prodotti al carrello devi registrarti sul sito");
				return false;
			}else{
				dialogs.alert("Per aggiungere prodotti al carrello devi registrarti sul sito");
				return false;
			}
	});
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
