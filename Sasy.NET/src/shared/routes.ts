import { writable } from 'svelte/store';
import Index from '../components/Index.svelte';
import About from '../components/About.svelte';
import Error404 from '../components/Error404.svelte';
import Forbidden from '../components/Forbidden.svelte';
import { onMount} from "svelte";
import why from "../components/why.svelte";
import Gallery from "../components/Gallery.svelte";
import Contatti from "../components/Contatti.svelte";
import Apebox from "../components/Apebox.svelte";
import Decorati from "../components/Decorati.svelte";
import Prodotti from "../components/Prodotti.svelte";
import Single_Prod from "../components/Single_Prod.svelte";
import login from "../components/ecommerce/login.svelte";
import registrati from "../components/ecommerce/registrati.svelte";
import carrello from "../components/ecommerce/carrello.svelte";
import changepass from "../components/ecommerce/changepass.svelte";
import deleterequest from "../components/ecommerce/deleterequest.svelte";
import ordercomplete from "../components/ecommerce/ordercomplete.svelte";
import recovery from "../components/ecommerce/recovery.svelte";
import area from "../components/ecommerce/area/index.svelte";
import pagamenti from "../components/ecommerce/pagamenti.svelte";
import profilo from "../components/ecommerce/area/profilo.svelte";
import ordini from "../components/ecommerce/area/ordini.svelte";

export let component = null;
export const routes = [
	{ path: '/',           label:'Index',       component:Index,      exact:true },
	{ path: '/about',      label:'About',      component:About },
    { path: '/why', label: 'why', component: why },
    { path: '/gallery', label: 'Gallery', component: Gallery },
    { path: '/contatti', label: 'Contatti', component: Contatti },
    { path: '/apebox', label: 'Apebox', component: Apebox },
    { path: '/decorati', label: 'Decorati', component: Decorati },
	{ path: '/forbidden',  label:'Forbidden',  component:Forbidden, hide:true },
    { path: '/all_prod', label: 'Prodotti', component: Prodotti },
    { path: 'prodotti', label: 'Prodotto', component: Single_Prod },
    { path: '/ecommerce/login', label: "Login", component: login },
    { path: '/ecommerce/registrati', label: "Registrati", component: registrati },
    { path: '/ecommerce/carrello', label: "Carrello", component: carrello },
    { path: '/ecommerce/changepass', label: "Cambia password", component: changepass },
    { path: '/ecommerce/deleterequest', label: "Cancella richiesta", component: deleterequest },
    { path: '/ecommerce/ordercomplete', label: "Ordine completato", component: ordercomplete },
    { path: '/ecommerce/recovery', label: "Recupera password", component: recovery },
    { path: '/ecommerce/area', label: "Area Clienti", component: area },
    { path: '/ecommerce/pagamenti', label: "Pagamenti", component: pagamenti },
    { path: '/ecommerce/area/profilo', label: "Profilo", component: profilo },
    { path: '/ecommerce/area/ordini', label: "Ordini", component: ordini },
	{ component:Error404,  label:'Not Found',  hide:true },
];

export let routeLinks = writable({});

// required to patch in missing pushstate event
(function(history:any) {
    var pushState = history.pushState;
    history.pushState = function(state) {
        const ret = pushState.apply(history, arguments);
        window.dispatchEvent(new CustomEvent('pushstate', {
            detail: { state, location }
		}));
		return ret;
    };
})(window.history);