<script lang="ts">
	import client from '../shared/js/contentfulClient';
	import { onMount } from 'svelte';
	import { apebox } from '../shared/js/pasticceria';
	import Checkbox from '../shared/apebox/check.svelte';
	import { dialogs } from 'svelte-dialogs';
	import { documentToHtmlString } from '@contentful/rich-text-html-renderer';
	import { useLazyImage as LazyImage } from 'svelte-lazy-image';
	import { BLOCKS, MARKS } from '@contentful/rich-text-types';

	let header = {
			title: '',
			description: ''
		},
		apeboxes: Array<Apebox> = [];

	const options = {
		renderMark: {
			[MARKS.BOLD]: (text) => `<custom-bold>${text}<custom-bold>`
		},
		renderNode: {
			[BLOCKS.UL_LIST]: (node, next) =>
				`<ul class="uk-list uk-list-disc sud">${next(node.content)}</ul >`
		}
	};

	onMount(async () => {
		const raw_header = await client?.getEntries({
			content_type: 'apeboxHeader'
		});
		header.title = raw_header.items[0].fields.title;
		header.description = raw_header.items[0].fields.description;

		const raw_body = await client?.getEntries({
			content_type: 'apebox'
		});
		raw_body?.items.forEach((element) => {
			apeboxes.push({
				title: element.fields.title,
				price: element.fields.price,
				list: documentToHtmlString(element.fields.list, options),
				photo: element.fields.photo.fields.file.url.replace('//', 'https://')
			});
		});
		apeboxes = apeboxes;
	});
</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/fresca.css" />
</svelte:head>
<br />
<div class="uk-section-default">
	<div class="uk-section uk-light uk-background-cover apehead" style="background: #84739b;">
		<div class="uk-container" align="center">
			<h3 class="tit" style="color:white">{header.title}</h3>
			<div>
				<p class="det" style="color:white">
					{header.description}
				</p>
			</div>
		</div>
	</div>
</div>
<br />
<div class="tot">
	<div class="uk-grid-column-small uk-grid-row-large uk-child-width-1-3@s uk-text-center" uk-grid>
		{#each apeboxes as ape}
			<div>
				<div>
					<div class="uk-card uk-card-default" uk-height-viewport="expand: true;min-height: 1200">
						<div class="uk-card-body">
							<img data-src={ape.photo} class="cardimg" alt="" use:LazyImage />

							<h3 class="uk-card-title nomi">{ape.title}</h3>
							{@html ape.list}
							<p class="testisp">{ape.price} &euro;</p>
							<button
								class="uk-button uk-button-primary carbut"
								id="Benvenuti al nord"
								on:click={() => apebox('Benvenuti al nord', ape.price, ape.image)}
								>Aggiungi al carrello</button
							>
						</div>
					</div>
				</div>
			</div>
		{/each}
		<div>
			<div>
				<div class="uk-card uk-card-default" uk-height-viewport="expand: true;min-height: 1200">
					<div class="uk-card-body">
						<img data-src="/images/Il trasformista.png" alt="" use:LazyImage />

						<p />
						<h3 class="uk-card-title trasf">APEBOX "IL TRASFORMISTA"</h3>

						<p>Il box lo trasformi tu come vuoi con gli ingredienti degli altri box a scelta!</p>
						<button
							class="uk-button uk-button-primary carbut"
							id="Il trasformista"
							on:click={() => dialogs.modal(Checkbox)}>Aggiungi al carrello</button
						>
					</div>
				</div>
			</div>
		</div>
		<div>
			<div>
				<div class="uk-card uk-card-default" uk-height-viewport="expand: true;min-height: 1200">
					<div class="uk-card-body">
						<h3 class=" testisp">Si possono accompagnare i box con:</h3>
						<ul class="uk-list uk-list-disc sud">
							<li>PROSECCO cantine Maschio 20 cl - &euro;2.50</li>
							<li>BOLLICINE cantine Maschio Ros&egrave; 20cl - &euro;2.50</li>
							<li>APEROL SPRITZ 17.5cl - &euro;2.00</li>
							<li>CRODINO o SANBITTER 10cl - &euro;1.20</li>
							<li>
								NEBBIOLO &quot;Vatep&egrave;&quot; superiorie Cantine Bordone 750 cl - &euro; 8.00
							</li>
							<li>BARBERA cantine Bordone 750 cl - &euro; 6.00</li>
						</ul>

						<h3 class="testisp">Puoi regalarti anche i dolcini di Sasy&lsquo;s</h3>

						<ul class="uk-list uk-list-disc sud">
							<li>TIRAMIS&Uacute;</li>
							<li>PANNA COTTA</li>
							<li>BUNET</li>
							<li>CHEESECAKE</li>
							<li>BAVARESE AI 3 CIOCCOLATI</li>
						</ul>

						<p class="testisp prezzi">3.50 &euro;</p>

						<div class="uk-card-media-bottom" />
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<br />
