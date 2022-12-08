<script lang="ts">
	import { gallery } from '../shared//js/gallery';
	import { onMount } from 'svelte';
	import { useLazyImage as LazyImage } from 'svelte-lazy-image';
	import Gallery from '../shared/gallery.svelte';
	import { dialogs } from 'svelte-dialogs';
	import Fa from 'svelte-fa/src/fa.svelte';
	import { faArrowLeft } from '@fortawesome/free-solid-svg-icons/index.js';

	let gallery_raw = {
		items: []
	};

	let gallery_show = false,
		photos: any[] = [];

	onMount(async () => {
		gallery_raw = await gallery(); // Get all photos from contentful
	});
	function show_gallery(photos_raw: Array<any>) {
		gallery_show = true; // Show gallery of product
		photos = [];	// Clear array
		photos_raw.forEach((photo) => {
			photos.push(photo.fields.file.url.replace('//', 'https://')); // Push all URL in arrry
		});
		photos = photos;
	}
</script>

<svelte:head>
	<link rel="stylesheet" href="https://unpkg.com/purecss@2.1.0/build/grids-min.css" />
	<link rel="stylesheet" href="https://unpkg.com/purecss@2.1.0/build/grids-responsive-min.css" />
</svelte:head>

<link rel="stylesheet" href="/css/card.css" />

{#if !gallery_show && gallery_raw.items != null}
	<div class="pure-g">
		{#each gallery_raw.items as photos}
			<div class="pure-u-1 pure-u-sm-1-3 ">
				<div>
					<div>
						<a on:click={() => show_gallery(photos.fields.photos)}>
							<div
								class="uk-card uk-card-default but cardc"
								uk-height-viewport="expand: true;min-height: 700"
							>
								<div class="uk-card-media-top" align="center">
									<hr />
									<h3 class=" testow uk-card-title ">{photos.fields.type}</h3>
									<hr />
								</div>
								<div class="uk-card-body" align="center">
									<img
										data-src={photos.fields.preview.fields.file.url.replace('//', 'https://')}
										width="384"
										alt="preview"
										use:LazyImage
									/>
									<h4>&nbsp;</h4>
								</div>
							</div>
						</a>
					</div>
				</div>
				<br />
			</div>
		{/each}
	</div>
{:else}
	<div class="gallo">
		<div on:click={() => (gallery_show = false)}>
			<Fa icon={faArrowLeft} size="5x" />
		</div>
		<br />
		<Gallery
			on:click={(event) =>
				dialogs.alert('<img src=' + event.detail.src + ' alt="Placeholder Image" width="512px"/>')}
		>
			{#each photos as photo}
				<img src={photo} alt="biscotto" />
			{/each}
		</Gallery>
	</div>
{/if}
<br />

<style>
	.uk-card {
		margin: 10px;
	}
	.pure-g {
		margin: 20px;
	}
	hr {
		color: white;
	}

	.gallo {
		margin: 50px;
	}
</style>
