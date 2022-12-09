<script lang="ts">
	export let qty;
	export let prod: string;
	export let costo;
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
		const raw_prod = await client?.getEntries({
			content_type: 'prodotti'
		});
		prods = raw_prod?.items;
	});

	async function minus(e) {
		if(qty == 1){
			let response = await dialogs.confirm("Vuoi rimuovere il prodotto dal carrello?");
			if(response){
				var myHeaders = new Headers();
				myHeaders.append("Content-Type", "application/x-www-form-urlencoded");
				var urlencoded = new URLSearchParams();
				urlencoded.append("prodotto", prod);
				urlencoded.append("all", "false");
				urlencoded.append("nuke", "false");
				
				var requestOptions = {
					method: "DELETE",
					headers: myHeaders,
					body: urlencoded,
					redirect: "follow",
				};

				fetch("/api/Cart", requestOptions)
						.then((response) => response.text())
						.then(async (result) => {
							if (!result) {
								dialogs.alert("Errore durante l'inserimento nel carrello");
							} else {
								dispatch('minus', {
									text: ida
								});
							}
						})
						.catch((error) => {
							console.error(error);
							dialogs.alert("Errore durante l'inserimento nel carrello");
						});
			}
		}else{
			var myHeaders = new Headers();
			myHeaders.append("Content-Type", "application/x-www-form-urlencoded");
			var urlencoded = new URLSearchParams();
			urlencoded.append("prodotto", prod);
			urlencoded.append("all", "false");
			urlencoded.append("nuke", "false");
			
			var requestOptions = {
				method: "DELETE",
				headers: myHeaders,
				body: urlencoded,
				redirect: "follow",
			};

			fetch("/api/Cart", requestOptions)
					.then((response) => response.text())
					.then(async (result) => {
						if (!result) {
							dialogs.alert("Errore durante l'inserimento nel carrello");
						} else {
							dispatch('minus', {
								text: ida
							});
						}
					})
					.catch((error) => {
						console.error(error);
						dialogs.alert("Errore durante l'inserimento nel carrello");
					});
		}
		
	}

	function plus(e) {
		var myHeaders = new Headers();
		myHeaders.append("Content-Type", "application/x-www-form-urlencoded");
		console.log(prod);
		var urlencoded = new URLSearchParams();
		urlencoded.append("prodotto", prod);
		urlencoded.append("qty", "1");
		urlencoded.append("costo", costo);
		
		var requestOptions = {
			method: "POST",
			headers: myHeaders,
			body: urlencoded,
			redirect: "follow",
		};

		fetch("/api/Cart", requestOptions)
				.then((response) => response.text())
				.then(async (result) => {
					if (!result) {
						dialogs.alert("Errore durante l'inserimento nel carrello");
					} else {
								dispatch('plus', {
									text: ida
								});
					}
				})
				.catch((error) => {
					console.error(error);
					dialogs.alert("Errore durante l'inserimento nel carrello");
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
