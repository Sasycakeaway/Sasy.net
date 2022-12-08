<script>
  import { dialogs } from "svelte-dialogs";
  import { v4 as uuidv4 } from "uuid";
  import { onMount } from "svelte";
  import emailjs from "@emailjs/browser";
  import md5 from "md5";
  let email, pass, passcheck, uuid;
  function requestRestore() {
    if (pass == passcheck && pass != null && uuid != null) {
      var myHeaders = new Headers();
      myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

      var urlencoded = new URLSearchParams();
      urlencoded.append("email", email);
      urlencoded.append("password", md5(pass));
      urlencoded.append("uuid", uuid);

      var requestOptions = {
        method: "POST",
        headers: myHeaders,
        body: urlencoded,
        redirect: "follow",
      };

      fetch("/api/changepass", requestOptions)
        .then((response) => response.text())
        .then((result) => {
          if (result == "1") {
            dialogs.alert("Password cambiata con successo");
          } else {
            dialogs.alert("Richiesta scaduta");
          }
        })
        .catch((error) => {
          dialogs.alert("Errore durante la creazione della richiesta");
        });
    } else {
      dialogs.alert(
        "Le password non corrispondono oppure alcuni campi sono mancanti"
      );
    }
  }
  onMount(() => {
    emailjs.init("tfSXJVz0VLhWR2I_5");
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
        <p>Inserire la Email per la quale si vuole ripristinare la password</p>
      </center>
      <input
        class="uk-input"
        type="text"
        placeholder="Username"
        bind:value={email}
      />
    </div>
    <div class="uk-margin">
      <center>
        <p>Inserire la nuova password</p>
      </center>
      <input
        class="uk-input"
        type="password"
        placeholder="Password"
        bind:value={pass}
      />
    </div>
    <div class="uk-margin">
      <center>
        <p>Inserire nuovamente la password</p>
      </center>
      <input
        class="uk-input"
        type="password"
        placeholder="Password"
        bind:value={passcheck}
      />
    </div>
    <div class="uk-margin">
      <center>
        <p>Inserire il codice identificativo arrivato via email</p>
      </center>
      <input
        class="uk-input"
        type="text"
        placeholder="Codice identificativo"
        bind:value={uuid}
      />
    </div>
    <div class="uk-margin">
      <center>
        <button class="uk-button uk-button-primary" on:click={requestRestore}
          >Ripristina</button
        >
      </center>
    </div>
  </fieldset>
</div>
<br />
