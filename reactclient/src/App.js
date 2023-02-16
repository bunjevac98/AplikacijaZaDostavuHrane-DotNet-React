import React, { useState } from "react";


export default function App() {
  const [korisnici, setKorisnici] = useState([])

  function getKorisnici() {
    const url = "https://localhost:7220//get-all-korisnici";
    //OVO NAM KAZE KOJU CEMO 
    fetch(url, {
      method: 'GET'
    })
      .then(response => response.json)
      .then(korisniciFromServer => {
        console.log(korisniciFromServer);
        setKorisnici(korisniciFromServer);
      })
      .catch((error => {
        console.log(error);
        alert(error);
      }));
  }

  return (
    <div class="nav-bar">
      <h1>
        HELOO WORLD
      </h1>
      




    </div>
  );

  function renderKorisniciTable() {
    return (
      <div>

      </div>
    )


  }


}
