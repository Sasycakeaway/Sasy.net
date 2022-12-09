<script lang="ts">
	import { useLazyImage as lazyImage } from 'svelte-lazy-image';
	import { onMount } from 'svelte';
	import client from '../shared/js/contentfulClient';
	import { Circle2 } from 'svelte-loading-spinners';

	let abouts: Array<About> = [];
	let loading = true;

	async function get_time() {
		let raw_about = await client.getEntries({
			content_type: 'about'
		});
		raw_about.items.forEach((element) => {
			try {
				abouts.push({
					point: element.fields.point,
					description: element.fields.description.content[0].content[0].value,
					image: element.fields.image.fields.file.url.replace('//', 'https://'),
					id: element.fields.id
				});
			} catch {
				abouts.push({
					point: element.fields.point,
					description: element.fields.description.content[0].content[0].value,
					image: '',
					id: element.fields.id
				});
			}
		});
		abouts.sort((a, b) => a.id - b.id);
		loading = false;
		abouts = abouts;
	}

	onMount(() => get_time());
</script>

<svelte:head>
	<title>About</title>
	<link rel="stylesheet" href="/css/about.css" />
</svelte:head>
{#if loading}
	<div align="center">
		<br />
		<Circle2 size="256" />
	</div>
{:else}
	<div class="container">
		<div class="timeline">
			{#each abouts as about}
				<div class="timeline-row">
					<div class="timeline-time">
						<p>{about.point}</p>
					</div>
					<div class="timeline-content">
						<img data-src={about.image} class="img" alt="profilo" use:lazyImage />
						<br />
						<p>
							{about.description}
						</p>
					</div>
				</div>
			{/each}
		</div>
	</div>
{/if}
