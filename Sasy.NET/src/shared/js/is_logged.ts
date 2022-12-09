import {dialogs} from "svelte-dialogs";

export async function is_logged(is_login: boolean){
    let user = "";
    let pass = "";
    const cookies = document.cookie.split(";");
    cookies.forEach(cookie => {
        if(cookie.includes("username"))
            user = cookie.split("=")[1].replace("%40", "@");
        else if(cookie.includes("password"))
            pass = cookie.split("=")[1];
    });
    if (user != null && pass != null) {
        const myHeaders = new Headers();
        myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

        const urlencoded = new URLSearchParams();
        urlencoded.append("email", user);
        urlencoded.append("password", pass);

        const requestOptions = {
            method: "POST",
            headers: myHeaders,
            body: urlencoded,
            redirect: "follow",
        };

        fetch("/api/login", requestOptions)
            .then((response) => response.text())
            .then((result) => {
                
                if (result == "1" && is_login) {
                    location.href = "/ecommerce/area/";
                 }
                else if(!is_login && result != "1"){
                    location.href = "/ecommerce/login/"
                }
                return true;
            })
            .catch((error) => {
                dialogs.alert(
                    "Errore di connessione al server API, contattare l'assistenza"
                );
            });
    }
}