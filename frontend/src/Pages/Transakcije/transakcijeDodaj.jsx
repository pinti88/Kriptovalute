import React, { useState, useEffect } from 'react';
import { Form, Button } from 'react-bootstrap';

const TransakcijeDodaj = () => {
  const [kolicina, setKolicina] = useState('');
  const [kriptoId, setKriptoId] = useState('');
  const [naknada, setNaknada] = useState('');
  const [kriptovalute, setKriptovalute] = useState([]);

  useEffect(() => {
    fetch('API_URL/kriptovalute') // Dohvati kriptovalute za select
      .then(response => response.json())
      .then(data => setKriptovalute(data))
      .catch(error => console.log(error));
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    const transakcija = {
      kolicina,
      kripto_id: kriptoId,
      naknada
    };

    fetch('API_URL/transakcije', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(transakcija)
    })
      .then(response => response.json())
      .then(data => {
        console.log('Transakcija uspješno dodana', data);
      })
      .catch(error => console.log(error));
  };

  return (
    <div>
      <h2>Dodaj novu transakciju</h2>
      <Form onSubmit={handleSubmit}>
        <Form.Group controlId="formKolicina">
          <Form.Label>Količina</Form.Label>
          <Form.Control
            type="number"
            value={kolicina}
            onChange={(e) => setKolicina(e.target.value)}
            required
          />
        </Form.Group>

        <Form.Group controlId="formKriptoId">
          <Form.Label>Kriptovaluta</Form.Label>
          <Form.Control
            as="select"
            value={kriptoId}
            onChange={(e) => setKriptoId(e.target.value)}
            required
          >
            <option value="">Odaberite kriptovalutu</option>
            {kriptovalute.map((kripto) => (
              <option key={kripto.kripto_id} value={kripto.kripto_id}>
                {kripto.ime} ({kripto.simbol})
              </option>
            ))}
          </Form.Control>
        </Form.Group>

        <Form.Group controlId="formNaknada">
          <Form.Label>Naknada</Form.Label>
          <Form.Control
            type="number"
            value={naknada}
            onChange={(e) => setNaknada(e.target.value)}
            required
          />
        </Form.Group>

        <Button variant="primary" type="submit">
          Spremi transakciju
        </Button>
      </Form>
    </div>
  );
};

export default TransakcijeDodaj;
