<script lang="ts">
	import { onMount } from 'svelte';
	import { initcart, pushatra } from '../js/cart.js';
	let cart;
	let totale;
	onMount(() => {
		cart = initcart();
		totale = localStorage.getItem('totale');
		if ((totale = null)) totale = 0;
	});
	import { DialogContent } from 'svelte-dialogs';
	let trasformista = [];
	let prodotti = [
		'Selezione di formaggi misti dal Nord Italia',
		'Selezione di affettati misti dal Nord Italia',
		'Selezione di formaggi misti del Sud Italia',
		'Selezione di affettati misti del Sud Italia',
		'Bottoncini di pane con lardo',
		'Focaccia genovese con patè di olive taggiasche',
		'Minipiada di crudo di parma',
		'Tocchetti di frico su pane nero',
		'Cassatine siciliane salate',
		'Babà alla crema di pecorino',
		'Biscottini salati della casa',
		'Tette delle monache salate',
		'Flan di zucchine con salsa di toma',
		'Tartellette alla crema di piselli e bacon',
		'Insalata di riso alla cantonese',
		'Quiche lorrein',
		'Tartellette alla crema di parmigiano',
		'Brutti e buoni salati'
	];
	function checktra() {
		pushatra(prodotti);
	}
</script>

<DialogContent>
	<svelte:fragment slot="body">
		<p class="uk-text-meta uk-text-default">Puoi selezionare solo 6 ingredienti</p>
		{#each prodotti as ingredienti}
			<input class="form-check-input" type="checkbox" id={ingredienti} name={ingredienti} />
			<label class="form-check-label" for={ingredienti}>{ingredienti}</label><br />
		{/each}
		<br />
		<button class="uk-button uk-button-primary" on:click={checktra}>Aggiungi al carrello</button>
	</svelte:fragment>
</DialogContent>
