<script lang="ts">
	import { get_all_types } from '../shared/js/get_all_types';
	import { onMount } from 'svelte';
	import { useLazyImage as lazyImage } from 'svelte-lazy-image';
	import { Circle2 } from 'svelte-loading-spinners';

	let prods: Array<DropdownProd> = [];

	let loading = true;


	onMount(async () => {
		prods = await get_all_types();
		loading = false;
	});

</script>

<svelte:head>
	<title>Home</title>
	<link rel="stylesheet" href="/css/fresca.css" />
	<link rel="stylesheet" href="/css/why.css" />
	<link rel="stylesheet" href="/css/lievitati.css" />
	<link rel="stylesheet" href="/css/cardtorte.css" />
</svelte:head>

<br>
{#if loading}
	<center>
		<br />
		<Circle2 size="512" />
		<h3>Loading...</h3>
	</center>
{:else}
	
		<div class="tot">
			<div
				class="uk-grid-column-small uk-grid-row-large uk-child-width-1-3@s uk-text-center"
				uk-grid
			>
				{#each prods as prod}
					<div>
						<div>
							<div
								class="uk-card uk-card-default uk-height-max-large"
								uk-height-viewport="expand: true;min-height: 700"
							>
								<div class="uk-card-body">
									<a
										href={'/prodotti?prod=' + prod.type}
                                        on:click={() => (location.href = '/prodotti?prod=' + prod.type)}
									>
										<h3 class="uk-card-title">{prod.name}</h3>
									</a>
									<p>
										{prod.description}
									</p>
								</div>
								<div class="uk-card-media-bottom">
									<img data-src={prod.image} class="cardimg" alt="icon" use:lazyImage />
								</div>
							</div>
						</div>
					</div>
				{/each}
			</div>
		</div>
		<br />
{/if}
<!-- loading -->
<style>
	.prod {
		width: 60%;
	}
	.imgcenter {
		width: 400px;
	}
	.icon {
		margin-left: 300px;
	}
	.cover {
		/* Add the blur effect */
		filter: blur(8px);
		-webkit-filter: blur(8px);
	}
</style>
