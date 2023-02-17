import React, { useState, useEffect } from "react";





export default function App() {

  const [korisnici, setKorisnici] = useState([]);

  useEffect(() => {
    fetch("https://localhost:7220/get-all-korisnici")
      .then(response => response.json())
      .then(data =>  setKorisnici(data))
      .catch(error => console.log(error));
  }, []);

  /*
  function getKorisnici() {
  
    const url = "https://localhost:7220/get-all-korisnici";
     fetch(url, { method: "GET" })
      .then(response => response.json())
      .then(korisnici => setKorisnici(korisnici) )
      .catch((error => { alert(error) }));
  }
  getKorisnici();
  */
 
  return (
    < div >
      <h1>
        Dostava hrane
      </h1>
      <div className="mt-2">
        {renderPostTable()}
      </div>
    </div >
  );

  function renderPostTable() {

    return (
      <table className="table">
        <thead>
          <tr>
            <th scope="col">Korisnici:</th>
            <th scope="col">Korisnicko ime</th>
            <th scope="col">Ime</th>
            <th scope="col">Prezime</th>
            <th scope="col">E-mail</th>
            <th scope="col">Datum rodjenja</th>
            <th scope="col">Tip korisnika</th>
            <th scope="col">Akcije</th>
          </tr>
        </thead>
        <tbody>
          {korisnici.map(korisnik => (
            <tr key={korisnik.korisnikId}>
              <td>{korisnik.korisnikId}</td>
              <td>{korisnik.korisnickoIme}</td>
              <td>{korisnik.ime}</td>
              <td>{korisnik.prezime}</td>
              <td>{korisnik.ime}</td>
              <td>{korisnik.prezime}</td>
              <td>{korisnik.email}</td>
              <td>{korisnik.datumRodjenja}</td>
              <td>{korisnik.tipKorisnika}</td>
              <td>
                <button className="btn btn-success">
                  Update
                </button>
                <div className="mt-2">
                  <button className="btn btn-danger ml-3">
                    Delete
                  </button>
                </div>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }

}
