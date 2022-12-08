<script lang="ts">
	import { initcart } from '../../shared/js/cart.js';
	import { onMount } from 'svelte';
	import Stepper from '../../shared/stepper.svelte';
	import client from '../../shared/js/contentfulClient';

	let cart = [];
	let verifica;
	let totale;
	let prods: Array<Prodotto_Raw> = [];

	function removeall() {
		cart = [];
		totale = 0;
		localStorage.setItem('cart', JSON.stringify(cart));
		localStorage.setItem('totale', totale);
		verifica = check();
	}

	function check() {
		if (JSON.stringify(cart) == '[]') {
			return '{}';
		} else {
			return JSON.stringify(cart);
		}
	}

	onMount(async () => {
		cart = initcart();
		totale = localStorage.getItem('totale');
		verifica = check();
		const raw_prod = await client?.getEntries({
			content_type: 'prodotti'
		});
		prods = raw_prod?.items;
	});

	async function min(e) {
		totale = localStorage.getItem('totale');
		const prodotto = prods.filter(
			(prod_raw) => prod_raw.fields.prodottoName == cart[e.detail.text].id
		); // Prendo il prodotto dal CMS
		if (prodotto.length > 0) {
			cart[e.detail.text].prezzo -= prodotto[0].fields.price;
			cart[e.detail.text].qty--;
		}
	}

	function plu(e) {
		totale = localStorage.getItem('totale');
		const prodotto = prods.filter(
			(prod_raw) => prod_raw.fields.prodottoName == cart[e.detail.text].id
		); // Prendo il prodotto dal CMS
		if (prodotto.length > 0) {
			cart[e.detail.text].prezzo += prodotto[0].fields.price;
			cart[e.detail.text].qty++;
		}
	}

	function bin(e) {
		let temp;

		totale = localStorage.getItem('totale');

		cart.forEach((prod, i) => {
			if (prod.id == e) {
				temp = i;
			}
		});

		const prodotto = prods.filter((prod_raw) => prod_raw.fields.prodottoName == e); // Prendo il prodotto dal CMS
		if (prodotto.length > 0) {
			totale -= prodotto[0].fields.price;
		}

		cart = cart.filter((prod) => prod.id != e);

		localStorage.setItem('cart', JSON.stringify(cart));
		localStorage.setItem('totale', totale.toString());

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
{#if verifica == '{}'}
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
											<p>{prod.id}</p>
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
												id={prod.id}
												on:click={() => bin(prod.id)}
											/>
										</div>
									</div>
								</div>
								{#if prod.id != 'Il trasformista'}
									<Stepper qty={prod.qty} ida={i} prod={prod.id} on:minus={min} on:plus={plu} />
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
						<p>{prod.id}</p>
					{/each}
				</div>
				<div class="col">
					{#each cart as prod}
						<p>{prod.prezzo}&euro;</p>
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
{#if verifica != '{}'}
	<div align="center">
		<a href="/ecommerce/pagamenti"
			><button class="uk-button uk-button-primary">Completa l'ordine</button></a
		>
	</div>
{/if}
<br />
