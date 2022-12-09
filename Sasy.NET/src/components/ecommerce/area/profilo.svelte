<script>
  import {is_logged} from "../../../shared/js/is_logged";
  import { onMount } from "svelte";
  import {dialogs} from "svelte-dialogs";
  let email, cf, nascita, telefono, newemail;
  onMount(async () => {
    const cookies = document.cookie.split(";");
    cookies.forEach(cookie => {
      if(cookie.includes("username"))
        newemail = cookie.split("=")[1].replace("%40", "@");
    });
          if (await is_logged(false)) {
            const data_raw = await fetch("/api/GetUserByPass").catch(error => dialogs.alert("Errore durante il recupero dei dati")) ;
            const data = await data_raw.json();
                cf = data.Cf;
                telefono = data.Telefono;
                nascita = data.Nascita;
          } else {
            location.href = "/ecommerce/login";
          }
  });
</script>

<div class="container">
  <fieldset class="uk-fieldset field">
    <center>
      <br />
      <legend class="uk-legend">Il mio profilo</legend>
    </center>
    <div class="uk-margin">
      <p>E-Mail</p>
      <input
        class="uk-input"
        type="text"
        placeholder="E-mail"
        readonly
        bind:value={newemail}
      />
    </div>

    <div class="uk-margin">
      <p>Numero di telefono</p>
      <input
        class="uk-input"
        type="text"
        placeholder="Numero di telefono"
        readonly
        bind:value={telefono}
      />
    </div>

    <div class="uk-margin">
      <p>Codice Fiscale</p>
      <input
        class="uk-input"
        type="text"
        placeholder="Codice Fiscale"
        readonly
        bind:value={cf}
      />
    </div>

    <div class="uk-margin">
      <p>Data di nascita</p>
      <input
        class="uk-input"
        type="date"
        placeholder="Data di nascita"
        readonly
        bind:value={nascita}
      />
    </div>
    <!-- <div class="uk-margin">
            <p>Scrivi la password per confermare le modifiche</p>
            <input class="uk-input" type="text" placeholder="Password" readonly bind:value={pass}>
        </div> -->
    <!-- <center>
            <button class="uk-button uk-button-primary" on:click={update}>Aggiorna i dati</button>
            <hr/>
        </center> -->
  </fieldset>
</div>

<style>
  .container {
    margin: 20px;
    background-color: white;
    border-radius: 8px;
  }
  hr {
    opacity: 0;
  }
  .field {
    margin: 20px;
  }
</style>
