<script lang="ts">
	import client from './js/contentfulClient';
	import { onMount } from 'svelte';
	import { useLazyImage as lazyImage } from 'svelte-lazy-image';
	import { Circle2 } from 'svelte-loading-spinners';
	let cards: Array<Card> = [];
	let loading: boolean = true;

	async function get_cards() {
		let raw_card = await client.getEntries({
			content_type: 'cardDescription'
		});

		raw_card.items.forEach(
			(element: {
				fields: {
					description: string;
					href: string;
					descriptionTrue: { content: { content: { value: string }[] }[] };
					icon: { fields: { file: { url: string } } };
				};
			}) => {
				cards.push({
					nome: element.fields.description,
					description: element.fields.descriptionTrue.content[0].content[0].value,
					href: element.fields.href,
					icon: element.fields.icon.fields.file.url.replace('//', 'https://')
				});
			}
		);

		loading = false;
		cards = cards; // Trigger svelte update
	}

	onMount(() => get_cards());
</script>

<link rel="stylesheet" href="/css/card.css" />
<div>
	{#if loading}
		<div align="center">
			<Circle2 size="256" />
		</div>
	{:else}
		{#each cards as card}
			<div class="pure-u-1 pure-u-sm-1-4">
				<div>
					<div>
						<a on:click={() => location.href = card.href} href="#0">
							<div
								class="uk-card uk-card-default but cardc"
								uk-height-viewport="expand: true;min-height: 640"
							>
								<div class="uk-card-media-top" align="center">
									<h6>&nbsp;</h6>
									<img data-src={card.icon} alt="card icon" use:lazyImage />
								</div>
								<div class="uk-card-body" align="center">
									<a style="background-color: white;"
										><h3 class=" testow uk-card-title ">{card.nome}</h3></a
									>
									<p>
										{card.description}
									</p>
									<h4>&nbsp;</h4>
								</div>
							</div>
						</a>
					</div>
				</div>
			</div>
		{/each}
	{/if}
</div>

<style>
	.uk-card {
		margin: 10px;
	}
</style>
