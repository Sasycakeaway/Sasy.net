<script>
	let mobile = false;
	import { onMount } from 'svelte';
	import emailjs from '@emailjs/browser';
	import { dialogs } from 'svelte-dialogs';
	let nome = '',
		email = '',
		text = '',
		cognome = '',
		ntel = '',
		privacy = false,
		prom = false;
	onMount(async () => {
		if (/Android|webOS|iPhone|iPad|iPod|Opera Mini/i.test(navigator.userAgent)) {
			document.getElementById('map').className = '';
			document.getElementById('map').style.width = '350px';
			document.getElementById('map').style.height = '350px';
		}
	});
	function manda() {
		if (privacy && prom) {
			emailjs.send(
				'service_ccwtjlr',
				'template_7gaqbjl',
				{
					nome: nome,
					cognome: cognome,
					email: email,
					ntel: ntel,
					testo: text
				},
				'XI3aGphpOi4C1--qr'
			);
		} else {
			dialogs.alert(
				"Devi accettare l'informativa sulla privacy e il consenso alle comunicazioni per finalit&agrave; promozionali per mandare un messaggio a Sasy"
			);
		}
	}
</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/why.css" />
	<link
		rel="stylesheet"
		href="https://unpkg.com/purecss@2.1.0/build/pure-min.css"
		integrity="sha384-yHIFVG6ClnONEA5yB5DJXfW2/KC173DIQrYoZMEtBvGzmf0PKiGyNEqe9N6BNDBH"
		crossorigin="anonymous"
	/>
	<link rel="stylesheet" href="https://unpkg.com/purecss@2.1.0/build/grids-responsive-min.css" />
</svelte:head>
<br />
<h1>Contattaci per avere informazioni sui nostri prodotti o per fare ordini</h1>
<br />
<div class="contatti">
	<fieldset class="contatti">
		<div class="uk-margin">
			{#if nome == ''}
				<p>Inserire il proprio nome</p>
			{/if}
			<input class="uk-input" type="text" placeholder="Nome" bind:value={nome} />
		</div>

		<div class="uk-margin">
			{#if cognome == ''}
				<p>Inserire il proprio cognome</p>
			{/if}
			<input class="uk-input" type="text" placeholder="Cognome" bind:value={cognome} />
		</div>
		<div class="uk-margin">
			{#if email == ''}
				<p>Inserire una email</p>
			{/if}
			<input class="uk-input" type="email" placeholder="E-mail" bind:value={email} />
		</div>
		<div class="uk-margin">
			{#if ntel == ''}
				<p>Inserire un numero di telefono</p>
			{/if}
			<input class="uk-input" type="tel" placeholder="Numero di telefono" bind:value={ntel} />
		</div>
		<div class="uk-margin">
			{#if text == ''}
				<p>Inserire un messaggio</p>
			{/if}
			<textarea class="uk-textarea" rows="5" placeholder="Messaggio" bind:value={text} />
		</div>
		<div class="uk-margin uk-grid-small uk-child-width-auto uk-grid">
			<label
				><input type="checkbox" bind:checked={privacy} /> Accetto l'<a
					href="/Sasy - Privacy - 2022.pdf">informativa sulla privacy</a
				> di Sasy's Cake Away</label
			>
		</div>
		<div class="uk-margin uk-grid-small uk-child-width-auto uk-grid">
			<label
				><input type="checkbox" bind:checked={prom} /> Accetto il consenso alle comunicazioni per finalit&agrave;
				promozionali di Sasy's Cake Away</label
			>
		</div>
	</fieldset>
	<center>
		<button class="uk-button uk-button-primary" on:click={manda}>Invia</button>
	</center>
</div>
<br />
<div align="center">
	<iframe
		title="Posizione Sasy's Cake Away"
		class="mappa"
		id="map"
		src="https://www.google.com/maps/embed?pb=!1m14!1m8!1m3!1d11259.999086265521!2d7.7086123!3d45.1263404!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x3a57226dc53caa17!2sSasy&#39;s%20cake%20away!5e0!3m2!1sit!2sit!4v1649366843756!5m2!1sit!2sit"
		style="border:0;"
		allowfullscreen=""
		loading="lazy"
		referrerpolicy="no-referrer-when-downgrade"
		height="500px"
	/>
</div>
<!-- <section>
  <input type="text" >

 
</section> -->
<br />
