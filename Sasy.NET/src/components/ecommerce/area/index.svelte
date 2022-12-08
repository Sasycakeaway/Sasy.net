<script>
  import { dialogs } from "svelte-dialogs";
  import { onMount } from "svelte";
  function logout() {
    localStorage.clear();
    sessionStorage.clear();
    location.href = "/";
  }
  onMount(() => {
    if (
      /Android|webOS|iPhone|iPad|iPod|Opera Mini/i.test(navigator.userAgent)
    ) {
       document.getElementById("cards").style.paddingRight = "30px";

    }
    let user = sessionStorage.getItem("email");
    let pass = sessionStorage.getItem("password");
    if (user == null || pass == null) {
      location.href = "/ecommerce/login";
    } else {
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
          if (result != "1") {
            location.href = "/ecommerce/login";
          }
        })
        .catch((error) => {
          dialogs.alert(
            "Errore di connessione al server API, contattare l'assistenza"
          );
        });
    }
  });
</script>

<svelte:head />

<div class="uk-child-width-expand@s uk-text-center container" uk-grid id="cards">
  <div>
    <a href="/ecommerce/area/profilo">
      <div class="uk-card uk-card-default ">
        <div class="uk-card-header">
          <div class="uk-grid-small uk-flex-middle" uk-grid>
            <div class="uk-width-auto">
              <img src="/images/profile.png" width="64px" />
            </div>
            <div class="uk-width-expand">
              <h3 class="uk-card-title uk-margin-remove-bottom">
                Il tuo profilo
              </h3>
            </div>
          </div>
        </div>
        <div class="uk-card-body">
          <p>Visualizza e modifica le informazione del tuo profilo</p>
        </div>
      </div>
    </a>
  </div>

  <div>
    <a href="/ecommerce/area/ordini">
      <div class="uk-card uk-card-default ">
        <div class="uk-card-header">
          <div class="uk-grid-small uk-flex-middle" uk-grid>
            <div class="uk-width-auto">
              <img
                src="https://img.icons8.com/glyph-neue/64/000000/cardboard-box.png"
              />
            </div>
            <div class="uk-width-expand">
              <h3 class="uk-card-title uk-margin-remove-bottom">
                I tuoi ordini
              </h3>
            </div>
          </div>
        </div>
        <div class="uk-card-body">
          <p>Consulta lo storico degli ordini effettuati</p>
        </div>
      </div>
    </a>
  </div>
</div>
<center>
  <button class="uk-button uk-button-danger" on:click={logout}
    >Effettua il logout</button
  >
</center>
<br />

<style>
  .container {
    margin: 20px;
  }
</style>
