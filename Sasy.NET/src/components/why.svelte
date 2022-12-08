<script>
	import Carousel from '../shared/carousel.svelte';
	import Head from '../shared/head.svelte';
	import Prod from '../shared/prod.svelte';
</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/why.css" />
</svelte:head>
<br />
<div
	class="uk-card uk-card-default uk-grid-collapse uk-child-width-1-2@s uk-margin cardone"
	uk-grid
>
	<div class="uk-card-media-left uk-cover-container ">
		<img src="/images/harry.jpg" alt="" uk-cover />
		<canvas width="800" height="800" />
	</div>
	<div>
		<div class="uk-card-body">
			<h1 style="color:#682bad" class="tit">Perchè scegliere Sasy's?</h1>
			<ul class="uk-list">
				<li class="det">
					Sasy's si sceglie per la sua originalità nel proporre un prodotto
					<a style="color: #5c44bd;font-weight: bold;">ARTISTICO</a> e di alta
					<a style="color: #5c44bd;font-weight: bold;">QUALITA'</a>.
				</li>
				<li class="det">
					Sasy's si sceglie per la cura maniacale nella <a style="color: #5c44bd;font-weight: bold;"
						>RICERCA</a
					>
					di abbinamenti di
					<a style="color: #5c44bd;font-weight: bold;">COLORI</a>
					e <a style="color: #5c44bd;font-weight: bold;">SAPORI</a>.
				</li>
				<li class="det">
					Sasy's si sceglie per il suo lievito madre che è stato <a
						style="color: #5c44bd;font-weight: bold;">TRAMANDATO</a
					>
					con amore e dedizione
					<a style="color: #5c44bd;font-weight: bold;">DA PIU' DI CENTO ANNI</a>
					e che viene rinfrescato con
					<a style="color: #5c44bd;font-weight: bold;">RIGOROSA ATTENZIONE</a>.
				</li>
				<li class="det">
					Sasy's si sceglie per la passione che infonde in tutte le sue
					<a style="color: #5c44bd;font-weight: bold;">CREAZIONI</a>. E' questo il suo vero
					<a style="color: #5c44bd;font-weight: bold;">INGREDIENTE SEGRETO</a>!
				</li>
				<li class="det">
					Sasy's si sceglie per l'attenzione alla qualità degli ingredienti: burro e panna Corman,
					pasta di zucchero Saracino, farina Molino Dallagiovanna, arancia candita Agrimontana,
					cioccolato Callebaut e Valrhona, latte Bio Tapporosso, zucchero Eridania.
				</li>
				<li class="det">
					Sasy's si sceglie perchè..... provate uno dei miei dolci e scrivetelo voi lasciando un <a
						style="color: #5c44bd;font-weight: bold;">COMMENTO</a
					> sulla mia pagina facebook
				</li>
			</ul>
		</div>
	</div>
</div>

<style>
	.uk-card {
		border-color: transparent;
	}
</style>
