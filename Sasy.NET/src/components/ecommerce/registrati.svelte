<script>
  import { dialogs } from "svelte-dialogs";
  import md5 from "md5";
  import emailjs from "@emailjs/browser";
  import { onMount } from "svelte";
  import * as CodiceFiscaleUtils from "@marketto/codice-fiscale-utils";
  import { Circle2 } from "svelte-loading-spinners";
  import Fa from "svelte-fa/src/fa.svelte";
  import {
    faEye,
    faEyeSlash,
  } from "@fortawesome/free-solid-svg-icons";
  import { v4 as uuidv4 } from "uuid";

  let buttonpress = false;
  var user,
    pass,
    passcheck,
    nascita,
    cf,
    telefono = "",
    news = false,
    show = false,
    showcheck = false,
    privacy = false;

  function registrati() {
    if (privacy) {
      buttonpress = true;
      let regDate = new Date();
      let isodate = regDate.toISOString().split("T")[0];
      let token = uuidv4();
      if (
        pass == passcheck &&
        CodiceFiscaleUtils.Validator.codiceFiscale(cf).valid &&
        user != undefined &&
        user != "" &&
        nascita != undefined &&
        nascita != "" &&
        telefono != undefined &&
        telefono != "" &&
        telefono.length == 10
      ) {
        var myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

        var urlencoded = new URLSearchParams();
        urlencoded.append("cf", cf);
        urlencoded.append("nascita", nascita);
        urlencoded.append("telefono", telefono);
        urlencoded.append("email", user);
        urlencoded.append("password", md5(pass));
        urlencoded.append("timestamp", isodate);
        urlencoded.append("news", news);
        let newsremove =
          "Se ti fossi iscritto alla newsletter e vuoi rimuoverti clicca questo link: " +
          `https://sasycakeaway.com/newsletter/${user}/${token}`;

        if (news == true) {
          urlencoded.append("token", token);
        } else {
          urlencoded.append("token", null);
          newsremove = "";
        }

        var requestOptions = {
          method: "POST",
          headers: myHeaders,
          body: urlencoded,
          redirect: "follow",
        };

        fetch("/api/adduser", requestOptions)
          .then((response) => response.text())
          .then(async (result) => {
            if (result == "1") {
              await emailjs.send("service_s11ial4", "template_4x1knko", {
                email: user,
                newsremove: newsremove,
              });
              await sessionStorage.clear();
              dialogs
                .alert("Account creato correttamente")
                .then(() => (location.href = "/ecommerce/login"));
            } else {
              dialogs.alert("Account esistente");
            }
          })
          .catch((error) => {
            dialogs.alert(
              "Errore durante la connessione al server API, contattare l'assistenza"
            );
          });
      } else {
        buttonpress = false;
        dialogs.alert(
          "Le password non corrispondono o il codice fiscale non è corretto"
        );
      }
    } else {
      dialogs.alert(
        "Per registrarti devi accettare l'informativa sulla privacy di Sasy's Cake Away"
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
  function showfn() {
    show = !show;
    if (show) {
      document.getElementById("pass").type = "text";
    } else {
      document.getElementById("pass").type = "password";
    }
  }
  function showfncheck() {
    showcheck = !showcheck;
    if (showcheck) {
      document.getElementById("passcheck").type = "text";
    } else {
      document.getElementById("passcheck").type = "password";
    }
  }
</script>

<svelte:head>
  <link rel="stylesheet" href="/css/login.css" />
</svelte:head>
<br />
<div
  class="uk-card uk-card-default uk-card-body uk-width-1-2@m forma"
  id="form"
>
  <fieldset class="uk-fieldset">
    <div align="center">
      <legend class="uk-legend">Registra un account su Sasy's Cake Away</legend>
    </div>
    <div class="uk-margin">
      <input
        id="username"
        class="uk-input"
        type="text"
        placeholder="E-mail"
        bind:value={user}
      />
    </div>
    <div class="uk-margin">
      <input
        id="pass"
        class="uk-input"
        type="password"
        placeholder="Password"
        bind:value={pass}
      />
      <button class="icon" on:click={showfn}>
        {#if show == false}
          <Fa icon={faEye} />
        {:else}
          <Fa icon={faEyeSlash} />
        {/if}
      </button>
    </div>
    <div class="uk-margin">
      <input
        id="passcheck"
        class="uk-input"
        type="password"
        placeholder="Conferma la Password"
        bind:value={passcheck}
      />
      <button class="icon" on:click={showfncheck}>
        {#if showcheck == false}
          <Fa icon={faEye} />
        {:else}
          <Fa icon={faEyeSlash} />
        {/if}
      </button>
    </div>
    <div class="uk-margin">
      <input
        id="telefono"
        class="uk-input"
        type="text"
        placeholder="Numero di telefono"
        bind:value={telefono}
      />
    </div>
    <div class="uk-margin">
      <input
        id="nascita"
        class="uk-input"
        type="date"
        placeholder="Data di nascita"
        bind:value={nascita}
      />
    </div>
    <div class="uk-margin">
      <input
        id="cf"
        class="uk-input"
        type="text"
        placeholder="Codice fiscale"
        bind:value={cf}
      />
    </div>
    <div class="d-flex justify-content-center">
      <div class="form-check ">
        <input
          class="form-check-input"
          type="checkbox"
          value=""
          id="flexCheckDefault"
          bind:checked={news}
        />
        <label class="form-check-label" for="flexCheckDefault">
          Vuoi ricevere comunicazioni di carattere pubblicitario sulla email che
          hai indicato nel form?
        </label>
      </div>
    </div>
    <br />
    <div class="uk-margin uk-grid-small uk-child-width-auto uk-grid">
      <label
        ><input type="checkbox" bind:checked={privacy} /> Accetto l'<a
          href="/Sasy - Privacy - 2022.pdf">informativa sulla privacy</a
        > di Sasy's Cake Away</label
      >
    </div>
    <div align="center">
      <div>
        {#if buttonpress == false}
          <button
            class="uk-button uk-button-primary"
            type="button"
            on:click={registrati}>Registrati</button
          >
          <br />
          <br />
        {:else}
          <Circle2 size="120" duration="1s" />
        {/if}
      </div>
    </div>
  </fieldset>
</div>
<br />

<style>
  .icon {
    margin-right: 10px;
    margin-top: 10px;
    background-color: transparent;
    border: 0px;
  }
  .iconcheck {
    margin-top: 100px;
  }
</style>
