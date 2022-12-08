<script>
	import { onMount } from 'svelte';
	onMount(() => {
		if (/Android|webOS|iPhone|iPad|iPod|Opera Mini/i.test(navigator.userAgent)) {
		} else {
			document.getElementById('card').style.width = '60%';
		}
	});
</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/why.css" />
</svelte:head>
<br />
<h1 class="tit">Frolla al cacao con panna cotta</h1>
<br />
<div class="" align="center">
	<div class="uk-card uk-card-default" id="card">
		<hr />
		<img src="/images/cropan.webp" alt="" class="imgcenter" />
		<div>
			<div class="uk-card-body">
				<p class="det" style="color:black;">
					Un connubio di sapori particolare e ricercato: panna cotta tradizionale o al caffè per una
					tartelletta moderna dal sapore unico.
				</p>
			</div>
		</div>
	</div>

	<br />
	<!-- <button class="uk-button uk-button-primary carbut" id="Bignole" on:click={(event) => biscotti(event)}>Aggiungi al carrello</button> -->
	<br />
	<!-- <p class="citprod" style="color:rgb(195, 0, 255)">"Preparare dolci è molto più che saper eseguire ricette: è un vero e proprio gesto d’amore"</p> -->
</div>

<style>
	.uk-card {
		width: 80%;
	}
	.imgcenter {
		width: 50%;
	}
</style>
