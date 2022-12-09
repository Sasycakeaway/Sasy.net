<script>
	import Head from '../shared/head.svelte';
	import Prod from '../shared/prod.svelte';
	import SvelteSeo from 'svelte-seo';
	import { onMount } from 'svelte';
	import GdprBanner from '../shared/Cookies_Banner/Banner.svelte';
	
	let choices = {
		necessary: {
			label: "Cookies dell'e-commerce",
			description:
				"Usiamo questi cookies per l'utilizzo dell'e-commerce, rimaranno sul tuo PC e noi non potremo vederli.",
			value: true
		},
		tracking: {
			label: 'Google cookies',
			description:
				'Sono i cookies utilizzati da Youtube e Maps, non dipendono da noi in nessun modo.',
			value: true
		},
		marketing: {
			label: 'Paypal cookies',
			description:
				'Se deciderai di acquistare con PayPal, verranno salvati dei cookies dipendenti da PayPal.',
			value: true
		}
	};
	let mobile = false;
	onMount(async () => {
		if (/Android|webOS|iPhone|iPad|iPod|Opera Mini/i.test(navigator.userAgent)) {
			mobile = true;
			document.getElementById('ifname').style.width = '300px';
			document.getElementById('ifname').style.height = '200px';
			document.getElementById('comitato')?.classList.remove('comitato');
			document.getElementById('comitato')?.classList.add('comitato_mobile');
		}
	});
</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/index.css" />
	<link rel="stylesheet" href="https://unpkg.com/purecss@2.1.0/build/grids-min.css" />
	<link rel="stylesheet" href="https://unpkg.com/purecss@2.1.0/build/grids-responsive-min.css" />
	<script
			async
			src="https://cdn.jsdelivr.net/npm/vanilla-lazyload@latest/dist/lazyload.min.js"
	></script>
	<style>
		.comitato_mobile {
			/**Container del comitato per telefono*/
			margin: 50px;
		}
	</style>
	<script>
		// Set the options globally
		// to make LazyLoad self-initialize
		window.lazyLoadOptions = {
			// Your custom settings go here
		};

		// Listen to the initialization event
		// and get the instance of LazyLoad
		window.addEventListener("LazyLoad::Initialized", function (event) {
			window.lazyLoadInstance = event.detail.instance;
		}, false);
	</script>
</svelte:head>
<SvelteSeo
	jsonLd={{
		'@context': 'https://schema.org',
		'@type': 'Restaurant',
		image: [
			'https://www.sasycakeaway.com/images/slide/Biscotti/Sasy_Macaron1.jpeg',
			'https://www.sasycakeaway.com/images/slide/Torte/Sasy_creamtart01.jpeg',
			'https://www.sasycakeaway.com/images/slide/Uova/WhatsApp%20Image%202021-03-26%20at%2001.18.52.jpeg',
			'https://www.sasycakeaway.com/images/slide/Pasta%20di%20zucchero/IMG-20200614-WA0020.jpg'
		],
		name: "Sasy's Cake Away",
		address: {
			'@type': 'PostalAddress',
			streetAddress: 'Viale falchera 69',
			addressLocality: 'Torino',
			addressRegion: 'IT',
			postalCode: '10156',
			addressCountry: 'IT'
		},
		review: {
			'@type': 'Review',
			reviewRating: {
				'@type': 'Rating',
				ratingValue: '5',
				bestRating: '5'
			},
			author: {
				'@type': 'Person',
				name: 'Sabrina Vitrani'
			}
		},
		geo: {
			'@type': 'GeoCoordinates',
			latitude: 45.1263404,
			longitude: -7.7086123
		},
		url: 'https://www.sasycakeaway.com/',
		telephone: '+3339273367',
		servesCuisine: 'Pasticceria',
		priceRange: '$$',
		openingHoursSpecification: [
			{
				'@type': 'OpeningHoursSpecification',
				dayOfWeek: ['Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday', 'Sunday'],
				opens: '10:00',
				closes: '12:00'
			}
		],
		menu: 'https://www.sasycakeaway.com/gallery',
		acceptsReservations: 'True'
	}}
/>
<Head {mobile} />
<GdprBanner
	cookieName="Login"
	description="Accetti l'utilizzo di cookies per l'utilizzo dell'e-commerce?"
	heading="Utilizzo cookies"
	{choices}
/>

<br />
<div class="prodi">
	<Prod />
</div>
<br />
<div class="uk-card uk-card-default but cardc comitato" id="comitato">
	<div class="center">
		<img class="comitato_image" src="/images/box_natale.jpeg" alt="comitato_logo" width="700" />
		<div style="text-align:center">
		<p class="comitato_text">
			Per questo natale scegli il nostro box colazione Santa Klaus. E' un regalo solidale a supporto
			delle iniziative del Comitato Mahmud, aiutando così i bambini siriani e ucraini che stanno
			vivendo in condizione estreme. All'interno troverete un sacchetto di krumiri ( o melighe o
			nocciolotti a scelta) è un preparato homemade per 250 ml di cioccolata calda (dovrete
			aggiungere solo il latte e troverete le indicazioni circa la preparazione)
		</p>
		
			<img
				src="/images/comitato_logo.jpg"
				alt="Logo comitato"
				width="256px"
				class="comitato_image"
			/>

			<p class="comitato_text">
				Il Comitato Mahmud nasce nel 2014 per aiutare i bambini più in difficoltà nel mondo.
				Quest'anno abbiamo sostenuto una casa famiglia ucraina ospitata vicino a Torino e stiamo
				sostenendo un campo in Siria, a Idlib con cibo tutti i mesi e attività per bambini e
				bambine.
			</p>
		</div>
	</div>
</div>
<div align="center">
	<a href="/all_prod">
		<button class="uk-button uk-button-primary uk-button-large but">Scopri i nostri prodotti</button
		>
	</a>
	<p class="info">
		Per prenotazioni ed ordini chiama il 333/9273367 oppure scrivi a Sasy.vitrani@gmail.com
	</p>
	<br />
	<iframe
			class="lazy"
		width="1280"
		height="720"
		data-src="https://www.youtube.com/embed/jF6h8jJJuhc"
		title="YouTube video player"
		frameborder="0"
		allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture"
		allowfullscreen
		id="ifname"></iframe>
	<br />
	<h4>Sasy's su LIVE SOCIAL</h4>
	<p>
		La mia storia di imprenditrice appassionata, raccontata a Francesca Corso ai microfoni di Radio
		Veronica One
	</p>
	<a> www.radioveronicaone.it</a> - <a>www.radiolivesocial.it</a>
</div>
<br />

<style>
	.comitato {
		margin: 50px 150px 50px 150px;
		text-align: center;
	}
	.comitato_image {
		padding: 20px;
		border-radius: 30px;
	}
	.comitato_text {
		font-size: 20px;
		font-family: 'Poppins', sans-serif;
		font-weight: 600;
		padding: 20px;
	}
</style>
