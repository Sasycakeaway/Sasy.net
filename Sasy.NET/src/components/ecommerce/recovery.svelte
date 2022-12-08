<script>
  import { dialogs } from "svelte-dialogs";
  import { v4 as uuidv4 } from "uuid";
  import { onMount } from "svelte";
  import emailjs from "@emailjs/browser";
  let email;
  function requestRestore() {
    let id = uuidv4();
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

    var urlencoded = new URLSearchParams();
    urlencoded.append("email", email);
    urlencoded.append("uuid", id);

    var requestOptions = {
      method: "POST",
      headers: myHeaders,
      body: urlencoded,
      redirect: "follow",
    };

    fetch("/api/newpass", requestOptions)
      .then((response) => response.text())
      .then((result) => {
        if (result == "1") {
          dialogs.alert(
            "Segui le istruzioni nella email per ripristinare la password"
          );
          emailjs.send("service_s11ial4", "template_f3ea7rh", {
            uuid: id,
            email: email,
          });
        } else {
          dialogs.alert("La richiesta esiste già oppure l'account non esiste");
        }
      })
      .catch((error) => {
        dialogs.alert("Errore durante la creazione della richiesta");
      });
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
        <button class="uk-button uk-button-primary" on:click={requestRestore}
          >Ripristina</button
        >
      </center>
    </div>
  </fieldset>
</div>
<br />
