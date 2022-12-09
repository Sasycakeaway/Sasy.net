<script>
  import {is_logged} from "../../../shared/js/is_logged";
  import { Circle3 } from "svelte-loading-spinners";
  import { onMount } from "svelte";
  import {dialogs} from "svelte-dialogs";
  let ordini = [],
    loading = true;
  onMount(async () => {
        if (await is_logged(false)) {
          try {
            const data_raw = await fetch("/api/GetOrdersByPass");
            ordini = await data_raw.json();
            loading = false;
          }catch (e) {
            console.error(e);
            dialogs.alert("Errore durante il recupero degli ordini");
          }
        }
  });
</script>

<br />
{#if loading == false}
  <div class="container">
    <ul uk-accordion>
      {#each ordini as order}
        <li class="order">
          <a class="uk-accordion-title" href="#">Ordine numero: {order.id}</a>
          <div class="uk-accordion-content">
            <p>Nome: {order.nome}</p>
            <p>Cognome: {order.cognome}</p>
            <p>Indirizzo: {order.indirizzo}</p>
            <p>CAP: {order.cap}</p>
            <p>Consegna a domicilio: {order.domicilio}</p>
            <p>Totale: {order.totale}</p>
            <p>Data dell'ordine: {order.timestamp.split("T")[0]}</p>
            <p>Prodotti acquistati</p>
            <ul>
              {#each JSON.parse(order.cart) as cart}
                <li>{cart.id} - Quantità {cart.qty}</li>
              {/each}
            </ul>
          </div>
        </li>
      {/each}
    </ul>
  </div>
{:else}
  <center>
    <Circle3 size="128" unit="px" duration="2s" />
  </center>
{/if}

<style>
  .order {
    /* background-color: white; */
  }
  .container {
    margin: 20px;
  }
</style>
