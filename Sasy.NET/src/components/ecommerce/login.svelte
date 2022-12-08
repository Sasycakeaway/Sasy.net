<script>
  import { onMount } from "svelte";
  import md5 from "md5";
  const ENDPOINT = "/api/login";
  import { dialogs } from "svelte-dialogs";
  import Fa from "svelte-fa/src/fa.svelte";
  import {
    faEye,
    faEyeSlash,
  } from "@fortawesome/free-solid-svg-icons";
  var user;
  var pass;
  let show = false;
  onMount(() => {
    if (
      /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(
        navigator.userAgent
      )
    ) {
      document.getElementById("form").classList =
        "uk-card uk-card-default uk-card-body uk-width-1-2@m formatel";
    }
    user = sessionStorage.getItem("email");
    pass = sessionStorage.getItem("password");
    if (user != null && pass != null) {
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
            location.href = "/ecommerce/area/";
          }
        })
        .catch((error) => {
          dialogs.alert(
            "Errore di connessione al server API, contattare l'assistenza"
          );
        });
    }
  });
  function login() {
    var myHeaders = new Headers();
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

    var urlencoded = new URLSearchParams();
    urlencoded.append("email", user);
    urlencoded.append("password", md5(pass));

    var requestOptions = {
      method: "POST",
      headers: myHeaders,
      body: urlencoded,
      redirect: "follow",
    };

    fetch("/api/login", requestOptions)
      .then((response) => response.text())
      .then(async (result) => {
        if (result == "1") {
          await sessionStorage.setItem("email", user);
          await sessionStorage.setItem("password", md5(pass));
          location.href = "/ecommerce/area";
        } else {
          dialogs.alert("Login fallito, riprovare o creare un account");
        }
      })
      .catch((error) => {
        dialogs.alert(
          "Errore di connessione al server API, contattare l'assistenza"
        );
      });
  }
  function showfn() {
    show = !show;
    if (show) {
      document.getElementById("pass").type = "text";
    } else {
      document.getElementById("pass").type = "password";
    }
  }
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
      <input
        class="uk-input"
        type="text"
        placeholder="Username"
        bind:value={user}
      />
    </div>
    <div class="uk-margin">
      <input
        class="uk-input"
        type="password"
        placeholder="Password"
        bind:value={pass}
        id="pass"
      />
      <button class="uk-form-icon uk-form-icon-flip icon" on:click={showfn}>
        {#if show == false}
          <Fa icon={faEye} />
        {:else}
          <Fa icon={faEyeSlash} />
        {/if}
      </button>
    </div>
    <div class="uk-margin">
      <center>
        <a href="/ecommerce/recovery">Ho dimenticato la password</a>
      </center>
    </div>
    <div class="uk-child-width-expand@s uk-text-center" uk-grid>
      <div>
        <button class="uk-button uk-button-primary" on:click={login}
          >Accedi</button
        >
      </div>
      <div>
        <a href="/ecommerce/registrati"
          ><button
            class="uk-button uk-button-primary"
            href="/ecommerce/registrati">Registrati</button
          ></a
        >
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
</style>
