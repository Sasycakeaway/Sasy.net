<script>
	import Head from '$lib/components/sacco_di_natale/head.svelte';
	import Item from '$lib/components/sacco_di_natale/item.svelte';
</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/index.css" />
</svelte:head>

<Head />
<br />
<Item />
<br />
<p class="inform">
	* I biscotti sono prodotti da Sasy's e potete scegliere tra i cavalli battaglia: PASTE DI MELIGA,
	BACI DI DAMA, DIAMANTINI AL CACAO, FROLLINI LIMONE E TIMO, BRUTTI E BUONI, BISCOTTI di PAN di
	ZENZERO, CANTUCCINI DOLCI E SALATI, BISCOTTINI AL PARMIGIANO. SI REALIZZANO ANCHE BISCOTTI SENZA
	ZUCCHERO E PER INTOLLERANTI A LATTOSIO E UOVA Suggerisco di accompagnare i nostri sacchi con una
	bottiglia di ottima BIRRA DI NATALE del BIRRIFICIO ARTIGIANALE ELVO + 10 euro VINO ROSSO DOLCE
	BRICAT dell' Azienda Agricola BORDONE + 8 euro Si possono anche comporre sacchi personalizzati per
	info whatsapp 33392733367. I LAVORI DI RICAMO SONO REALIZZATI A MANO da <a
		href="https://www.instagram.com/mammacreativa_/"
		target="_blank">MAMMACREATIVA</a
	>
</p>
<br />

<div align="center">
	<a href="mailto:sasy.vitrani@gmail.com"
		><button class="uk-button uk-button-primary ordini uk-button-large">Ordina un cesto</button></a
	>
	<h4>&nbsp;</h4>
	<h1 class="titboh">I nostri produttori:</h1>
	<h4>&nbsp;</h4>
	<ul class="uk-list">
		<li>Salumificio Geymonat &quot;maestro del gusto&quot; 2020 &#8211; Bobbio Pellice</li>
		<li>Caseificio Melli Gonnet &#8211; Bobbio Pellice</li>
		<li>Caseificio Chez Duclos &#8211; Valpelline</li>
		<li>Az. Agricola Doneg&agrave; &#8211; Mongrando</li>
		<li>Caseificio La Casa delle Capre di Daniela Leone &#8211; Sala Biellese</li>
		<li>Birrificio Artigianale ELVO &#8211; Graglia</li>
	</ul>
</div>

<br />

<style>
</style>
