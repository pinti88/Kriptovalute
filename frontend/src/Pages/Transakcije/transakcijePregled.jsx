import React, { useState, useEffect } from 'react';
import { Table } from 'react-bootstrap';

const TransakcijePregled = () => {
  const [transakcije, setTransakcije] = useState([]);

  useEffect(() => {
    fetch('API_URL/transakcije') // Zamijeniti sa stvarnim URL-om API-ja za transakcije
      .then(response => response.json())
      .then(data => setTransakcije(data))
      .catch(error => console.log(error));
  }, []);

  return (
    <div>
      <h2>Pregled transakcija</h2>
      <Table striped bordered hover>
        <thead>
          <tr>
            <th>Transakcija ID</th>
            <th>Količina</th>
            <th>Kriptovaluta</th>
            <th>Naknada</th>
          </tr>
        </thead>
        <tbody>
          {transakcije.map((transakcija) => (
            <tr key={transakcija.transakcija_id}>
              <td>{transakcija.transakcija_id}</td>
              <td>{transakcija.kolicina}</td>
              <td>{transakcija.kripto_ime}</td> {/* Pretpostavljamo da API vraća ime kriptovalute */}
              <td>{transakcija.naknada}</td>
            </tr>
          ))}
        </tbody>
      </Table>
    </div>
  );
};

export default TransakcijePregled;
