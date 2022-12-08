<script>
  let users = 0;
  let ordertimes = [];
  let ordertimestamps = [];
  let timestamps = [];
  let userstime = [];
  let ordini = 0;
  import { onMount } from "svelte";
  const USEREND = "http://149.102.141.16/alluserstime";
  const ORDEREND = "http://149.102.141.16/allordertime";
  import { Chart } from "frappe-charts/dist/frappe-charts.min.cjs.js";
  onMount(() => {
    fetch(USEREND)
      .then((response) => response.json())
      .then((parsed) => {
        users = parsed.length;
        parsed.forEach((user) => {
          if (timestamps.includes(user.Timestamp.split("T")[0])) {
          } else {
            timestamps.push(user.Timestamp.toString().split("T")[0]);
          }
        });
        timestamps.forEach((time) => {
          let count = 0;
          parsed.forEach((user) => {
            if (time == user.Timestamp.toString().split("T")[0]) {
              count++;
            }
          });
          userstime.push(count);
        });
        fetch(ORDEREND)
          .then((response) => response.json())
          .then((orderparsed) => {
            ordini = orderparsed.length;
            orderparsed.forEach((order) => {
              if (ordertimestamps.includes(order.Timestamp.split("T")[0])) {
              } else {
                ordertimestamps.push(order.Timestamp.toString().split("T")[0]);
              }
            });
            ordertimestamps.forEach((time) => {
              let count = 0;
              orderparsed.forEach((order) => {
                if (time == order.Timestamp.toString().split("T")[0]) {
                  count++;
                }
              });
              ordertimes.push(count);
            });
            const orderdata = {
              labels: ordertimestamps,
              datasets: [
                {
                  name: "Nuovi ordini",
                  type: "bar",
                  values: ordertimes,
                },
              ],
            };
            const chartorder = new Chart("#orderschart", {
              title: "Nuovi ordini per giorno",
              data: orderdata,
              type: "bar",
              height: 250,
              colors: ["#7cd6fd"],
            });
          });
        const data = {
          labels: timestamps,
          datasets: [
            {
              name: "Nuovi utenti",
              type: "bar",
              values: userstime,
            },
          ],
        };
        const chart = new Chart("#userschart", {
          title: "Nuovi utenti per giorno",
          data: data,
          type: "bar",
          height: 250,
          colors: ["#7cd6fd"],
        });
      });
  });
</script>

<center>
  <br />
  <p>Totale utenti registrati: {users}</p>
  <p>Totale ordini registrati: {ordini}</p>
  <br />
</center>
<div id="userschart" />
<div id="orderschart" />
