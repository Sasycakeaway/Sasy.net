<script>
	import PdfViewer from 'svelte-pdf';
	let ingredienti = false;
	function download_ingredienti() {
		window.open('/elenco_ingredienti.pdf');
	}
</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/index.css" />
</svelte:head>
{#if ingredienti == false}
	<br />
	<div align="center">
		<div class="uk-card uk-card-default uk-card-body uk-width-1-2@m infor">
			<h3 class="uk-card-title">
				Secondo le normative vigenti puoi trovare in allegato gli ingredienti dei miei prodotti con
				evidenziati i relativi allergeni.
			</h3>
			<h6>&nbsp;</h6>
			<p>
				Ti ricordo di SEGNALARE all'atto della prenotazione EVENTUALI ALLERGIE o INTOLLERANZE
				ALIMENTARI E' importante per la tua sicurezza e per preservare la tua salute o quella dei
				tuoi cari.
			</p>
			<h6>&nbsp;</h6>
			<a href="#0" on:click={() => (ingredienti = true)}
				><button class="uk-button uk-button-primary uk-button-large but"
					>Scarica l'elenco ingredienti</button
				></a
			>
		</div>
	</div>
	<br />
{:else}
	<PdfViewer url="/elenco_ingredienti.pdf" scale="1.5" />
	<br />
{/if}
