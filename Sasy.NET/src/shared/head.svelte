<script>
	import { onMount } from 'svelte';
	onMount(() => {
		if (/Android|webOS|iPhone|iPad|iPod|Opera Mini/i.test(navigator.userAgent)) {
			document.getElementById('pric').classList.remove('uk-width-xlarge');
			document.getElementById('pric').classList.add('uk-width-medium');
			document.getElementById('pric').style.marginLeft = '31px';
		}
	});
</script>

<link rel="stylesheet" href="/css/card.css" />
<div class="uk-section-default but ">
	<div
		class="uk-section uk-light uk-background-cover but "
		style="background-image: url(/images/head.jpg)"
	>
		<div id="pric" class="uk-container sezione but cardc uk-width-xlarge margine">
			<br />

			<div align="center">
				<p class="titolo ">LABORATORIO ARTIGIANALE DI PASTICCERIA DOLCE e SALATA</p>
				<p class="sub">Impresa Alimentare Domestica</p>
				<p>--------------------------------------</p>
				<p class="cit">
					"Insieme progetteremo la tua torta, e il tuo evento diventerà indimenticabile"
				</p>
				<p class="firma">Sabrina Vitrani</p>
			</div>
		</div>
	</div>
</div>

<style>
	.margine {
		margin-left: 50px;
	}
</style>
