<script>
  const ENDPOINT = "http://149.102.141.16/login";
  const ENDPOINT2 = "http://149.102.141.16/getuserbypass";
  import { onMount } from "svelte";
  import { dialogs } from "svelte-dialogs";
  let email, cf, nascita, telefono, pass, newemail;
  onMount(async () => {
    let user = sessionStorage.getItem("email");
    newemail = user;
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
          if (result == "1") {
            var myHeaders = new Headers();
            myHeaders.append(
              "Content-Type",
              "application/x-www-form-urlencoded"
            );

            var urlencoded = new URLSearchParams();
            urlencoded.append("email", user);
            urlencoded.append("password", pass);

            var requestOptions = {
              method: "POST",
              headers: myHeaders,
              body: urlencoded,
              redirect: "follow",
            };

            fetch("/api/getuserbypass", requestOptions)
              .then((response) => response.json())
              .then((data) => {
                cf = data.Cf;
                telefono = data.Telefono;
                nascita = data.Nascita;
              })
              .catch((error) => console.log("error", error));
          } else {
            location.href = "/ecommerce/login";
          }
        })
        .catch((error) => console.log("error", error));
      // fetch(ENDPOINT, {
      //   method: "POST",
      //   headers: {
      //     "Content-Type": "application/json",
      //   },
      //   body: JSON.stringify(dati),
      // })
      //   .then((response) => response.json())
      //   .then(async (data) => {
      //     if (data.status != "1") {
      //       location.href = "/ecommerce/login";
      //     } else {
      //       fetch(ENDPOINT2, {
      //         method: "POST", // or 'PUT'
      //         headers: {
      //           "Content-Type": "application/json",
      //         },
      //         body: JSON.stringify(dati),
      //       })
      //         .then((response) => response.json())
      //         .then((data) => {
      //           cf = data.cf;
      //           (telefono = data.telefono), (nascita = data.nascita);
      //         })
      //         .catch((error) => {
      //           console.error("Error:", error);
      //         });
      //     }
      //   })
      //   .catch((error) => {
      //     dialogs.alert(
      //       "Errore di connessione al server API, contattare l'assistenza"
      //     );
      //   });
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
