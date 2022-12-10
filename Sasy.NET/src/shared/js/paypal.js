import { dialogs } from 'svelte-dialogs';
import { v4 as uuidv4 } from 'uuid';
import emailjs from '@emailjs/browser';
import {initcart} from "./cart";

async function delete_cart(){
	var myHeaders = new Headers();
	myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

	var urlencoded = new URLSearchParams();
	urlencoded.append("all", "true");

	var requestOptions = {
		method: "DELETE",
		headers: myHeaders,
		body: urlencoded,
		redirect: "follow",
	};

	return await (await fetch("/api/Cart", requestOptions)).text();
}
async function putorder(nome, cognome, indirizzo, cap, domicilio, totale, cittavar, spedizione) {
	let id = uuidv4();
	let email = "";
	var myHeaders = new Headers();
	myHeaders.append('Content-Type', 'application/x-www-form-urlencoded');

	var urlencoded = new URLSearchParams();
	urlencoded.append('id', id);
	urlencoded.append('nome', nome);
	urlencoded.append('cognome', cognome);
	urlencoded.append('indirizzo', indirizzo + ' ' + cittavar);
	urlencoded.append('cap', cap);
	urlencoded.append('domicilio', domicilio);
	urlencoded.append('totale', totale);
	urlencoded.append('cart', JSON.stringify(await initcart()));
	urlencoded.append('spedizione', spedizione);
	const cookies = document.cookie.split(";");
	cookies.forEach(cookie => {
		if(cookie.includes("username"))
			email = cookie.split("=")[1].replace("%40", "@");
	});
	var requestOptions = {
		method: 'POST',
		headers: myHeaders,
		body: urlencoded,
		redirect: 'follow'
	};

	fetch('/api/AddOrder', requestOptions)
		.then((response) => response.json())
		.then(async (result) => {
			if (result == 1 && await delete_cart()) {
				try {
					await emailjs.send('service_ccwtjlr', 'template_cavi0no', {
						id: id,
						nome: nome,
						cognome: cognome,
						indirizzo: indirizzo,
						email: email
					});
					location.href = '/ecommerce/ordercomplete';
				} catch (error) {
					console.log(error);
				}
				localStorage.clear();
			}else{
				dialogs
					.alert(
						"Errore durante la registrazione dell'ordine, contattarci, fornendo i dettagli del pagamento per richiedere il rimborso"
					)
					.then(() => (location.href = '/'));
			}
		})
		.catch((err) => {
			dialogs.alert(
				"Errore durante la registrazione dell'ordine, contattarci, fornendo i dettagli del pagamento per richiedere il rimborso"
			);
			console.error(err);
		});
}
export async function init(
	totale,
	nome,
	cognome,
	indirizzo,
	cap,
	domicilio,
	cittavar,
	spedizione
) {
	emailjs.init('XI3aGphpOi4C1--qr');

	if (spedizione)	// Se i prodotti vengono spediti dobbiamo aggiungere 8 euro
		totale = (parseInt(totale) + 8).toString();
	console.log(totale);
	putorder(nome, cognome, indirizzo, cap, domicilio, totale, cittavar, spedizione);
	try {
		await paypal_sdk.Buttons({
			createOrder: function (data, actions) {
				return actions.order.create({
					purchase_units: [
						{
							amount: {
								value: totale
							}
						}
					]
				});
			},
			onApprove: function (data, actions) {
				console.log('approve');
				return actions.order.capture().then(async function (details) {
	 				putorder(nome, cognome, indirizzo, cap, domicilio, cart, totale, cittavar, spedizione);
				});
			},
			onError: function (err) {
				dialogs.alert(
					"Errore durante la registrazione dell'ordine, contattarci, fornendo i dettagli del pagamento per richiedere il rimborso"
				);
			}
		})
			.render('#paypal');
	} catch (error) {
		console.error('failed to render the PayPal Buttons', error);
	}
}