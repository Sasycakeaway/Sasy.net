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

</script>

<Router>
	<Header></Header>
<!--<nav class="uk-navbar uk-navbar-container">-->
<!--	<div class="container">-->
<!--		<a class="navbar-brand" href="/">-->
<!--			<i class="svg-logo svg-lg mr-1"></i>-->
<!--			Sasy. NETa-->
<!--		</a>-->
<!--		<ul class="navbar-nav">-->
<!--		{#each links as {path, label, exact} (label) }-->
<!--			<li class="nav-item">-->
<!--				<a href="{path}" class="nav-link" class:active={exact ? pathname == path : pathname.startsWith(path)} use:link>{label}</a>-->
<!--			</li>-->
<!--		{/each}-->
<!--		</ul>-->
<!--	</div>-->
<!--</nav>-->
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