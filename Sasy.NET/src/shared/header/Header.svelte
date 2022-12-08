<script lang="ts">
	import { onMount } from 'svelte';
	import { get_all_types } from '../js/get_all_types';
	let mobile = false;
	let types: Array<DropdownProd> = [];
	onMount(async () => {
		types = await get_all_types();
		if (
			/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)
		) {
			mobile = true;
		}
	});
</script>

<svelte:head>
	<link rel="stylesheet" href="/css/head.css" />
</svelte:head>
<div class="header">
	<header>
		<nav class="uk-navbar uk-navbar-container " uk-navbar>
			<div class="uk-navbar-left">
				{#if mobile}
					<a
						class="uk-navbar-toggle"
						uk-navbar-toggle-icon
						href="#"
						uk-toggle="target: #offcanvas-nav"
					/>
					<a style="color:black;" href="/" id="sas">Sasy's Cake Away</a>
				{/if}
				{#if mobile == false}
					<ul class="uk-navbar-nav">
						<li class="firma"><a href="/">Sasy's Cake Away</a></li>

						<li><a href="/about">Chi sono</a></li>
						<li><a href="/why">Perchè Sasy's</a></li>
						<li>
							<a href="#">I miei prodotti</a>
							<div class="uk-navbar-dropdown but">
								<ul class="uk-nav uk-navbar-dropdown-nav">
									<li><a href="/apebox">Apebox</a></li>
									<li><a href="/decorati">Biscotti decorati</a></li>
									{#each types as type}
										<li>
											<a
												href={'/prodotti?prod=' + type.type}
												on:click={() => (location.href = '/prodotti?prod=' + type.type)}
												>{type.name}</a
											>
										</li>
									{/each}
								</ul>
							</div>
						</li>
						<li><a href="/gallery">Galleria fotografica</a></li>
						<li><a href="/contatti">Contatti</a></li>
						<li><a href="/elenco_ingredienti.pdf">Elenco ingredienti</a></li>
					</ul>
				{/if}
			</div>
			{#if mobile == false}
				<div class="uk-navbar-right">
					<ul class="uk-navbar-nav">
						<li><a href="/ecommerce/login/">Login</a></li>
						<li><a href="/ecommerce/registrati/">Registrati</a></li>
						<li>
							<a href="/ecommerce/carrello/"
								><img
									class="cart"
									src="https://img.icons8.com/external-flatart-icons-lineal-color-flatarticons/256/000000/external-cart-supermarket-flatart-icons-lineal-color-flatarticons.png"
								/></a
							>
						</li>
					</ul>
				</div>
			{/if}

			<div id="offcanvas-nav" uk-offcanvas="overlay: true">
				<div class="uk-offcanvas-bar " style="background-color:white">
					<ul class="uk-nav">
						<li class="uk-active">
							<a href="/" style="color:black">Sasy's Cake Away</a>
						</li>
						<li><a href="/about">Chi sono</a></li>
						<li><a href="/why">Perchè Sasy's</a></li>
						<li class="uk-parent">
							<ul uk-accordion>
								<li>
									<a class="uk-accordion-title" href="#0" style="color:black;"
									>I miei prodotti</a>
									<div class="uk-accordion-content">
										<ul class="uk-nav-sub">
											<li><a href="/apebox">Apebox</a></li>
											<li><a href="/decorati">Biscotti decorati</a></li>
											{#each types as type}
												<li>
													<a
														href={'/prodotti?prod=' + type.type}
														on:click={() => (location.href = '/prodotti?prod=' + type.type)}
														>{type.name}</a
													>
												</li>
											{/each}
										</ul>
									</div>
								</li>
							</ul>
								<li><a href="/gallery" style="background-color:white" >Galleria fotografica</a></li>
								<li><a href="/contatti">Contatti</a></li>
								<li><a href="/ingredienti">Elenco ingredienti</a></li>
								<li><a href="/ecommerce/login/">Login</a></li>
								<li><a href="/ecommerce/registrati/">Registrati</a></li>
								<li>
									<a href="/ecommerce/carrello/"
										><img
											class="cart"
											src="https://img.icons8.com/external-flatart-icons-lineal-color-flatarticons/256/000000/external-cart-supermarket-flatart-icons-lineal-color-flatarticons.png"
										/></a
									>
								</li>
					</ul>
				</div>
			</div>
		</nav>
	</header>
</div>

<style>
	.header {
		width: 100%;
		padding: 0;
		margin: 0;
		margin: 2px solid green;
	}
	.cart {
		width: 64px;
	}
	.uk-nav-sub > li > a {
		color: black;
	}
	.uk-nav > li > a {
		color: black;
	}
	.uk-accordion-title{
		font-size: 1em;
		line-height: 0;
	}
</style>
