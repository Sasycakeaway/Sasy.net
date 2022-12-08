<script lang="ts">
    import { get_prod_and_filter } from '../shared/js/get_prod_and_filter';
    import { get_page_header_type } from '../shared/js/get_all_types';
    import { onMount } from 'svelte';
    import { useLazyImage as lazyImage } from 'svelte-lazy-image';
    import Fa from 'svelte-fa/src/fa.svelte';
    import { faArrowLeft } from '@fortawesome/free-solid-svg-icons/index.js';
    import { biscotti } from '../shared/js/pasticceria';
    import { Circle2 } from 'svelte-loading-spinners';

    let prods: Array<Prodotto> = [];
    let name: string,
        description: string,
        image: string,
        all: boolean = true,
        cit: string,
        header_info: Header_Info = { title: '', subtitle: '', image: '' },
        is_buyable: boolean,
        price: number,
        alert_string: string;

    let loading: boolean = true;
    const query = window.location.search;
    const prodotto = new URLSearchParams(query).get('prod');
    
    onMount(async () => {
        prods = await get_prod_and_filter(prodotto);
        header_info = await get_page_header_type(prodotto);
        loading = false;
    });

    function update_prod(
        na: string,
        desc: string,
        img: string,
        citazione: string,
        buyable: boolean,
        price_raw: number,
        alt_str: string
    ) {
        name = na;
        description = desc;
        image = img;
        cit = citazione;
        is_buyable = buyable;
        price = price_raw;
        alert_string = alt_str;
        all = false;
    }
</script>

<svelte:head>
    <title>Home</title>
    <link rel="stylesheet" href="/css/fresca.css" />
    <link rel="stylesheet" href="/css/why.css" />
    <link rel="stylesheet" href="/css/lievitati.css" />
</svelte:head>

{#if loading}
    <center>
        <br />
        <Circle2 size="512" />
        <h3>Loading...</h3>
    </center>
{:else}
    {#if all}
        <br />
        <div class="uk-section-default">
            <div
                    class="uk-section uk-light uk-background-cover imghead"
                    style={'background-image: url(' + header_info.image + ')'}
            >
                <div class="uk-container" align="center">
                    <h3 class="tit" style="color:white;">
                        {header_info.title}
                    </h3>
                    <div>
                        <p class="det" style="color: #d5ddb6;">
                            {header_info.subtitle}
                        </p>
                    </div>
                </div>
            </div>
        </div>
    {/if}
    <br />

    <link rel="stylesheet" href="/css/cardtorte.css" />
    {#if all && !prods[0].is_single_page}
        <!--  Se la lista dei prodotti è selezionata -->
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
                                    uk-height-viewport="expand: true;min-height: 600"
                            >
                                <div class="uk-card-body">
                                    <a
                                            on:click={() =>
											update_prod(
												prod.nome,
												prod.description,
												prod.image,
												prod.citazione,
												prod.buyable,
												prod.price,
												prod.buyPhrase
											)}
                                    >
                                        <h3 class="uk-card-title">{prod.nome}</h3>
                                    </a>
                                    <p>
                                        {prod.shortDescription}
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
    {:else if !all && !prods[0].is_single_page}
        <!--  Mostra la pagina del prodotto solo se non è un prodotto singolo e non ci sono tutte le cards -->
        <br />
        <div class="icon" on:click={() => (all = true)}>
            <Fa icon={faArrowLeft} size="4x" />
        </div>
        <h1 class="tit">{name}</h1>
        <br />
        <div class="" align="center">
            <div class="uk-card uk-card-default prod" id="card">
                <br />
                <img class="imgcenter" src={image} alt="" />
                <div>
                    <div class="uk-card-body">
                        <p class="det">
                            {description}
                        </p>
                    </div>
                </div>
            </div>

            {#if is_buyable}
                <br />
                <button
                        class="uk-button uk-button-primary carbut"
                        id={name}
                        on:click={() => biscotti(name, image, price, alert_string)}>Aggiungi al carrello</button
                >
                <br />
            {/if}
            <div class="testo">
                <p class="citprod" style="color:rgb(195, 0, 255)">
                    {cit}
                </p>
            </div>
        </div>
    {:else}
        <br />
        <center>
            <h3>{prods[0].nome}</h3>
        </center>
        <br />
        <center>
            {@html prods[0].description}
        </center>
        <div
                class="uk-position-relative uk-visible-toggle uk-dark"
                tabindex="-1"
                uk-slideshow="autoplay: true"
                align="center"
        >
            <ul class="uk-slideshow-items">
                {#each prods[0].gallery as photo}
                    <li>
                        <img src={photo} alt="Photo" width="512" />
                    </li>
                {/each}
            </ul>
            <a
                    class="uk-position-center-left uk-position-small uk-hidden-hover"
                    href="#"
                    uk-slidenav-previous
                    uk-slideshow-item="previous"
            />
            <a
                    class="uk-position-center-right uk-position-small uk-hidden-hover"
                    href="#"
                    uk-slidenav-next
                    uk-slideshow-item="next"
            />
        </div>
    {/if}
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