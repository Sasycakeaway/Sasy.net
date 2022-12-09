<script>
  import { onMount } from 'svelte';
  import {is_logged} from "../../shared/js/is_logged";
  onMount(async() => {
    await is_logged(false);
  });
</script> 
<br />
<div style="text-align: center;">
  <img src="/favicon.png" alt="logo" />
</div>
<br />
<h1>Il tuo ordine è stato inviato correttamente</h1>
<br />
<center>
  <h3>Grazie per aver acquistato da Sasy's Cake Away</h3>
  <br />
  <p>
    Sulla tua casella di posta è arrivata un'email con alcune informazioni utili
    sull'ordine, se hai dei dubbi contatta Sasy via Email o con il numero di
    cellulare.
  </p>
  <p>
    In caso di spedizione potrebbero volerci alcuni giorni per la preparazione e
    la consegna, ti terremo aggiornato sullo stato della spedizione
  </p>
</center>
<br />

<style>
  /* devanagari */
  @font-face {
    font-family: "Poppins";
    font-style: italic;
    font-weight: 200;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiDyp8kv8JHgFVrJJLmv1pVFteOcEg.woff2)
      format("woff2");
    unicode-range: U+0900-097F, U+1CD0-1CF6, U+1CF8-1CF9, U+200C-200D, U+20A8,
      U+20B9, U+25CC, U+A830-A839, U+A8E0-A8FB;
  }
  /* latin-ext */
  @font-face {
    font-family: "Poppins";
    font-style: italic;
    font-weight: 200;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiDyp8kv8JHgFVrJJLmv1pVGdeOcEg.woff2)
      format("woff2");
    unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB,
      U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
  }
  /* latin */
  @font-face {
    font-family: "Poppins";
    font-style: italic;
    font-weight: 200;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiDyp8kv8JHgFVrJJLmv1pVF9eO.woff2)
      format("woff2");
    unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA,
      U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212,
      U+2215, U+FEFF, U+FFFD;
  }
  /* devanagari */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 300;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiByp8kv8JHgFVrLDz8Z11lFc-K.woff2)
      format("woff2");
    unicode-range: U+0900-097F, U+1CD0-1CF6, U+1CF8-1CF9, U+200C-200D, U+20A8,
      U+20B9, U+25CC, U+A830-A839, U+A8E0-A8FB;
  }
  /* latin-ext */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 300;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiByp8kv8JHgFVrLDz8Z1JlFc-K.woff2)
      format("woff2");
    unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB,
      U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
  }
  /* latin */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 300;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiByp8kv8JHgFVrLDz8Z1xlFQ.woff2)
      format("woff2");
    unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA,
      U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212,
      U+2215, U+FEFF, U+FFFD;
  }
  /* devanagari */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 400;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiEyp8kv8JHgFVrJJbecmNE.woff2)
      format("woff2");
    unicode-range: U+0900-097F, U+1CD0-1CF6, U+1CF8-1CF9, U+200C-200D, U+20A8,
      U+20B9, U+25CC, U+A830-A839, U+A8E0-A8FB;
  }
  /* latin-ext */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 400;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiEyp8kv8JHgFVrJJnecmNE.woff2)
      format("woff2");
    unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB,
      U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
  }
  /* latin */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 400;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiEyp8kv8JHgFVrJJfecg.woff2)
      format("woff2");
    unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA,
      U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212,
      U+2215, U+FEFF, U+FFFD;
  }
  /* devanagari */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 600;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiByp8kv8JHgFVrLEj6Z11lFc-K.woff2)
      format("woff2");
    unicode-range: U+0900-097F, U+1CD0-1CF6, U+1CF8-1CF9, U+200C-200D, U+20A8,
      U+20B9, U+25CC, U+A830-A839, U+A8E0-A8FB;
  }
  /* latin-ext */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 600;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiByp8kv8JHgFVrLEj6Z1JlFc-K.woff2)
      format("woff2");
    unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB,
      U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
  }
  /* latin */
  @font-face {
    font-family: "Poppins";
    font-style: normal;
    font-weight: 600;
    font-display: swap;
    src: url(https://fonts.gstatic.com/s/poppins/v19/pxiByp8kv8JHgFVrLEj6Z1xlFQ.woff2)
      format("woff2");
    unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA,
      U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212,
      U+2215, U+FEFF, U+FFFD;
  }
  p {
    font-size: 17px;
    font-family: "Poppins", sans-serif;
    font-style: regular;
    color: black;
  }

  h1 {
    font-size: 30px;
    font-family: "Poppins", sans-serif;
    font-weight: 600;
  }

  h3 {
    font-size: 20px;
    font-family: "Poppins", sans-serif;
    font-weight: 500;
  }
</style>
