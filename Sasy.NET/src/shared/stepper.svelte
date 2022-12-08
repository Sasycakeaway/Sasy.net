<script lang="ts">
	export let qty;
	export let prod: string;
	import { initcart } from './js/cart.js';
	import { dialogs } from 'svelte-dialogs';
	import { onMount } from 'svelte';
	import { createEventDispatcher } from 'svelte';
	import client from './js/contentfulClient';

	const dispatch = createEventDispatcher();
	let prods: Array<Prodotto_Raw> = [];
	let cart = [];
	let totale;
	export let ida;

	onMount(async () => {
		cart = initcart();
		totale = localStorage.getItem('totale');
		const raw_prod = await client?.getEntries({
			content_type: 'prodotti'
		});
		prods = raw_prod?.items;
	});

	function minus(e) {
		cart.forEach(async (value, i) => {
			if (value.id == prod) {
				// Il prodotto esiste
				if (value.qty > 1) {
					// Il prodotto non è l'ultimo
					cart[i].qty--;
					const prodotto = prods.filter((prod_raw) => prod_raw.fields.prodottoName == prod); // Prendo il prodotto dal CMS
					if (prodotto.length > 0) {
						// Il prodotto esiste nel CMS
						cart[i].prezzo -= prodotto[0].fields.price;
						totale = prodotto[0].fields.price;
						qty--;

						localStorage.setItem('cart', JSON.stringify(cart));
						localStorage.setItem('totale', totale);

						dispatch('minus', {
							text: ida
						});
					} else dialogs.alert('Errore durante la rimozione del prodotto');
				} else {
					let resp = await dialogs.confirm('Vuoi eliminare il prodotto?');
					if (resp) {
						const prodotto = prods.filter((prod_raw) => prod_raw.fields.prodottoName == prod); // Prendo il prodotto dal CMS
						if (prodotto.length > 0) {
							// Il prodotto esiste nel CMS
							cart[i].prezzo -= prodotto[0].fields.price;
							totale -= prodotto[0].fields.price;
							cart.splice(i, 1);
							dispatch('minus', {
								text: ida
							});
						} else dialogs.alert('Errore durante la rimozione del prodotto');
					}
					localStorage.setItem('cart', JSON.stringify(cart));
					localStorage.setItem('totale', totale);
					location.reload();
				}
			}
		});
	}

	function plus(e) {
		cart.forEach((value, i) => {
			if (value.id == prod) {
				const prodotto = prods.filter((prod_raw) => prod_raw.fields.prodottoName == prod); // Prendo il prodotto dal CMS
				totale = parseInt(totale);

				if (prodotto.length > 0) {
					cart[i].qty++;
					qty++;
					cart[i].prezzo += prodotto[0].fields.price;
					totale += prodotto[0].fields.price;
				} else dialogs.alert("Errore durante l'aggiunta del prodotto");

				localStorage.setItem('cart', JSON.stringify(cart));
				localStorage.setItem('totale', totale);
				dispatch('plus', {
					text: ida
				});
			}
		});
	}
</script>

<svelte:head>
	<link rel="stylesheet" href="https://unpkg.com/purecss@2.1.0/build/grids-responsive-min.css" />
	<link
		rel="stylesheet"
		href="https://unpkg.com/purecss@2.1.0/build/pure-min.css"
		integrity="sha384-yHIFVG6ClnONEA5yB5DJXfW2/KC173DIQrYoZMEtBvGzmf0PKiGyNEqe9N6BNDBH"
		crossorigin="anonymous"
	/>
</svelte:head>

<div class="pure-g">
	<div class="pure-u-1-3" align="center">
		<button class="uk-button uk-button-default" on:click={plus}>+</button>
	</div>
	<div class="pure-u-1-3" align="center">
		<p class="qty">{qty}</p>
	</div>
	<div class="pure-u-1-3" align="center">
		<button class="uk-button uk-button-default" on:click={minus}>-</button>
	</div>
</div>

<style>
	.qty {
		text-align: center;
		position: relative;
		top: 50%;
		-ms-transform: translateY(-50%);
		-webkit-transform: translateY(-50%);
		transform: translateY(-50%);
	}
</style>
