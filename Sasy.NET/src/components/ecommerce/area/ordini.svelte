<script>
  const ENDPOINT = "http://149.102.141.16/getordersbypass";
  const LOGINENDPOINT = "http://149.102.141.16/login";
  import { Circle3 } from "svelte-loading-spinners";
  import { onMount } from "svelte";
  import { dialogs } from "svelte-dialogs";
  let ordini = [],
    loading = true;
  onMount(async () => {
    let user = sessionStorage.getItem("email");
    let pass = sessionStorage.getItem("password");
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

    var urlencoded = new URLSearchParams();
    urlencoded.append("email", user);
    urlencoded.append("password", pass);

    var requestOptions = {
      method: "POST",
      headers: myHeaders,
      body: urlencoded,
      redirect: "follow",
    };

    fetch("/api/login", requestOptions)
      .then((response) => response.text())
      .then((result) => {
        if (result == "1") {
          var myHeaders = new Headers();
          myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

          var urlencoded = new URLSearchParams();
          urlencoded.append("email", user);
          urlencoded.append("password", pass);

          var requestOptions = {
            method: "POST",
            headers: myHeaders,
            body: urlencoded,
            redirect: "follow",
          };

          fetch("/api/getordersbypass", requestOptions)
            .then((response) => response.json())
            .then((data) => {
              ordini = data;
              console.log(ordini);
              loading = false;
            })
            .catch((error) => console.log("error", error));
        }
      })
      .catch((error) => console.log("error", error));
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
