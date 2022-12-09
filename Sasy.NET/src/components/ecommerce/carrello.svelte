<script lang="ts">
	import { initcart } from '../../shared/js/cart.js';
	import { onMount } from 'svelte';
	import Stepper from '../../shared/stepper.svelte';
	import client from '../../shared/js/contentfulClient';
	import {dialogs} from "svelte-dialogs";

	let cart = [];
	let verifica;
	let totale;
	let prods: Array<Prodotto_Raw> = [];

	function totale_calculator(){
		let tot = 0;
		cart.forEach(prod => {
			tot += prod.qty * prod.costo;
		});
		return tot;
	}
	
	function removeall() {
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

		fetch("/api/Cart", requestOptions)
				.then((response) => response.text())
				.then(async (result) => {
					if (!result) {
						dialogs.alert("Errore durante l'inserimento nel carrello");
					} else {
						cart = await initcart();
						totale = totale_calculator();
					}
				})
				.catch((error) => {
					console.error(error);
					dialogs.alert("Errore durante l'inserimento nel carrello");
				});
	}

	function check() {
		if (JSON.stringify(cart) == '[]') {
			return '{}';
		} else {
			return JSON.stringify(cart);
		}
	}

	function fill_cart_image(){
		cart.forEach(function (prod, i) {
			const prodotto = prods.filter(
					(prod_raw) => prod_raw.fields.prodottoName == prod.prodotto
			);
			cart[i].image = prodotto[0].fields.headerPhoto.fields.file.url.replace("//", "https://")
		});
	}
	
	onMount(async () => {
		cart = await initcart();
		totale = totale_calculator();
		verifica = check();
		const raw_prod = await client?.getEntries({
			content_type: 'prodotti'
		});
		prods = raw_prod?.items;
		fill_cart_image();
	});

	async function min(e) {
		cart = await initcart();
		totale = totale_calculator();
		fill_cart_image();
	}

	async function plu(e) {
		cart = await initcart();
		totale = totale_calculator();
		fill_cart_image();
	}

	async function bin(e) {
		var myHeaders = new Headers();
		myHeaders.append("Content-Type", "application/x-www-form-urlencoded");
		var urlencoded = new URLSearchParams();
		urlencoded.append("prodotto", e);
		urlencoded.append("all", "false");
		urlencoded.append("nuke", "true");

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
					}else{
						cart = await initcart();
						totale = totale_calculator();
						fill_cart_image();
					}
				})
				.catch((error) => {
					console.error(error);
					dialogs.alert("Errore durante l'inserimento nel carrello");
				});

	}
	
</script>

<svelte:head>
	<link rel="stylesheet" href="/css/cart.css" />
	<link
		href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css"
		rel="stylesheet"
		integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3"
		crossorigin="anonymous"
	/>
	<script
		src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"
		integrity="sha384-ka7Sk0Gln4gmtz2MlQnikT1wXgYsOg+OMhuP+IlRH9sENBO0LRn5q+8nbTov4+1p"
		crossorigin="anonymous"
	></script>
</svelte:head>
<br />
{#if cart.length == 0}
	<h1 align="center">Carrello vuoto, aggiungi prodotti al carrello visitando le pagine del sito</h1>
{:else}
	<div class="list">
		<ul class="list-group">
			<li class="list-group-item" align="center">
				<button class="uk-button uk-button-danger" on:click={removeall}
					>Cancella tutti i prodotti nel carrello</button
				>
			</li>
			{#each cart as prod, i}
				<li class="list-group-item" id={prod.id + 'item'}>
					<div class="container">
						<div class="row">
							<div class="col">
								{#if prod.id != 'Il trasformista'}
									<img src={prod.image} alt="Foto del prodotto" class="imgcart" />
								{:else}
									<img
										src={'/images/Il trasformista.png'}
										alt="Foto del prodotto"
										class="imgcart"
										width="256px"
									/>
								{/if}
							</div>
							<div class="col">
								<div class="container">
									<div class="row">
										<div class="col">
											<p />
											<p>{prod.prodotto}</p>
											{#if prod.id != 'Cupcake' && prod.id != 'Muffin' && prod.id != 'Cakepop' && prod.id != 'Zeppole di San Giovanni' && prod.id == 'Il Trasformista'}
												<p>Peso: {cart[i].qty * 250}g</p>
											{:else if prod.id == 'Il trasformista'}
												<p>
													{JSON.stringify(prod.ingredienti)
														.replace('[', '')
														.replace(']', '')
														.replace('"', '')}
												</p>
											{:else}
												<p>Quantità: {cart[i].qty}</p>
											{/if}
										</div>
										<div class="col">
											<p />
										</div>

										<div class="col center">
											<img
												alt="cestino"
												src="https://img.icons8.com/external-kosonicon-solid-kosonicon/48/000000/external-bin-cleaning-kosonicon-solid-kosonicon.png"
												class="cestino"
												id={prod.prodotto}
												on:click={() => bin(prod.prodotto)}
											/>
										</div>
									</div>
								</div>
								{#if prod.id != 'Il trasformista'}
									<Stepper qty={prod.qty} ida={i} prod={prod.prodotto} costo={prod.costo} on:minus={min} on:plus={plu} />
								{/if}
							</div>
						</div>
					</div>
				</li>
			{/each}
		</ul>
	</div>
{/if}
<br />
<div align="center">
	<div class="uk-card uk-card-default uk-card-body uk-width-1-2@m">
		<h3>Prezzo totale:</h3>
		<br />
		<div class="container">
			<div class="row">
				<div class="col">
					{#each cart as prod}
						<p>{prod.prodotto}</p>
					{/each}
				</div>
				<div class="col">
					{#each cart as prod}
						<p>{(prod.costo * prod.qty)}&euro;</p>
					{/each}
				</div>
			</div>
		</div>
		<br />
		{#if totale == null}
			<h4>Totale: 0&euro;</h4>
		{:else}
			<h4>Totale: {totale}&euro;</h4>
		{/if}
	</div>
</div>
<br />
{#if cart.length != 0}
	<div align="center">
		<a href="/ecommerce/pagamenti"
			><button class="uk-button uk-button-primary">Completa l'ordine</button></a
		>
	</div>
{/if}
<br />
