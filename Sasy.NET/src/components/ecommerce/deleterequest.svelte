<script>
  import { onMount } from "svelte";
  import { dialogs } from "svelte-dialogs";
  let id;
  function requestRestore() {
    var requestOptions = {
      method: "GET",
      redirect: "follow",
    };

    fetch("/api/deleterequest/" + id, requestOptions)
      .then((response) => response.text())
      .then((result) => {
        if (result == "1") {
          dialogs.alert("Richiesta rimossa correttamente");
        } else {
          dialogs.alert("La richiesta non esiste");
        }
      })
      .catch((error) => {
        dialogs.alert("Errore durante la rimozione della richiesta");
        console.error(error);
      });
  }
  onMount(() => {
    if (
      /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(
        navigator.userAgent
      )
    ) {
      document.getElementById("form").classList =
        "uk-card uk-card-default uk-card-body uk-width-1-2@m formatel";
    }
  });
</script>

<svelte:head>
  <link rel="stylesheet" href="/css/login.css" />
</svelte:head>
<div
  class="uk-card uk-card-default uk-card-body uk-width-1-2@m forma"
  id="form"
>
  <fieldset class="uk-fieldset">
    <div align="center">
      <legend class="uk-legend">Sasy's Cake Away login</legend>
    </div>
    <div class="uk-margin">
      <center>
        <p>Inserire il codice identificativo della richiesta da eliminare</p>
      </center>
      <input
        class="uk-input"
        type="text"
        placeholder="Codice identificativo"
        bind:value={id}
      />
    </div>
    <div class="uk-margin">
      <center>
        <button class="uk-button uk-button-primary" on:click={requestRestore}
          >Cancella la richiesta</button
        >
      </center>
    </div>
  </fieldset>
</div>
<br />
