<svelte:window on:pushstate={x => pathname = x.target.location.pathname} on:popstate={x => pathname = x.target.location.pathname}/>

<script lang="ts">
import { Router, Route, link } from 'svelte-routing';
import { routes, routeLinks } from './shared/routes';
import 'uikit/dist/js/uikit.js';
import 'uikit/dist/js/uikit-icons.js';
import 'uikit/dist/css/uikit.css';
import Header from "./shared/header/Header.svelte";
let pathname = location.pathname;

let links = null;
routeLinks.subscribe(x => links = x);
function facebook() {
	window.open('https://www.facebook.com/sasy.cakeaway');
}
function instagram() {
	window.open('https://www.instagram.com/sasy_cakeaway/');
}
</script>

<Router>
	<Header></Header>
<div class="container">
	<div class="row p-4">
		<div id="content">
			{#each routes as {path,component}}
				<Route path="{path}" component="{component}" />
			{/each}
		</div>
	</div>
</div>
</Router>

<footer>
	<p class="titindirizzo uk-align-center" id="text">
		Mi trovi in Viale falchera 69 <br />
		<a href="/Sasy - Privacy - 2022.pdf">Informativa sulla privacy</a>
	</p>

	<p style="color: black" id="social">Seguici su Instagram e Facebook</p>
	<div uk-grid>
		<div id="socialimg">
			<a href="#0" on:click={instagram}
			><img
					alt="instagram"
					src="https://img.icons8.com/material-outlined/48/000000/instagram-new--v1.png"
			/></a
			>
		</div>
		<div>
			<a href="#0" on:click={facebook} alt="facebook"
			><img src="https://img.icons8.com/ios/48/000000/facebook--v1.png" /></a
			>
		</div>
	</div>
</footer>