<script>
	import { onMount } from 'svelte';
	let divclass = '';
	onMount(async () => {
		if (/Android|webOS|iPhone|iPad|iPod|Opera Mini/i.test(navigator.userAgent)) {
		} else {
			divclass = 'bloccot';
		}
	});
</script>

<svelte:head>
	<link rel="preconnect" href="https://fonts.googleapis.com" />
	<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
	<link
		href="https://fonts.googleapis.com/css2?family=Poppins:ital,wght@0,300;0,400;0,600;1,200&display=swap"
		rel="stylesheet"
	/>
</svelte:head>
<link rel="stylesheet" href="/css/natale.css" />
<div class="uk-section-default">
	<div class="uk-section uk-light uk-background-cover" style="background-color:#062a44">
		<div style="margin: 20px">
			<h1
				style="color:#f5e01f;     font-size: 30px; font-family: 'Poppins', sans-serif;font-weight: 600;"
			>
				IL SACCO DI BABBO NATALE
			</h1>
			<h4>&nbsp;</h4>
			<p class="testo">
				Dopo il successo dello scorso anno, anche per questo Natale vi proponiamo, oltre ai nostri
				biscotti, prodotti di piccole <a style="color:#faec92;">REALT&Agrave; ARTIGIANALI</a>
				presenti sul nostro <a style="color:#faec92;">TERRITORIO</a>. Un regalo lontano dai clamori
				dei colossi del web, che
				<a style="color:#faec92;">SOSTIENE</a>
				la produttivit&agrave; locale e la
				<a style="color:#faec92;">QUALIT&Agrave;</a>
				che solo le nostre piccole imprese possono garantire. Ci affidiamo a persone come noi,
				<a style="color:#faec92;">INNAMORATE</a>
				del loro lavoro, che mettono l' ANIMA nei loro manufatti, che pensano ai propri clienti come
				fossero la loro <a style="color:#faec92;">FAMIGLIA</a>, che vivono della
				<a style="color:#faec92;"> GIOIA</a>
				e dei
				<a style="color:#faec92;">SORRISI</a>
				che ricevono assieme al loro giusto compenso!
				<a style="color:#faec92;"> Un Babbo Natale a Km 0, biologico e molto green.</a>
			</p>
		</div>
		<div class="bloccot" />
	</div>
</div>
