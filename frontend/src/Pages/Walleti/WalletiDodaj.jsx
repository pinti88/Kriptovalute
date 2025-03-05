import React, { useState, useEffect } from 'react';
import { Form, Button } from 'react-bootstrap';

const WalletiDodaj = () => {
  const [naziv, setNaziv] = useState('');
  const [saldo, setSaldo] = useState('');
  const [kriptoId, setKriptoId] = useState('');
  const [kriptovalute, setKriptovalute] = useState([]);

  useEffect(() => {
   
    fetch('API_URL/kriptovalute')
      .then(response => response.json())
      .then(data => setKriptovalute(data))
      .catch(error => console.log(error));
  }, []);

  const handleSubmit = (e) => {
    e.preventDefault();

    const wallet = {
      naziv,
      saldo,
      kripto_id: kriptoId,
    };

    
    fetch('API_URL/walleti', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(wallet),
    })
      .then(response => response.json())
      .then(data => {
        console.log('Wallet uspješno dodan', data);
      })
      .catch(error => console.log(error));
  };

  return (
    <div>
      <h2>Dodaj novi Wallet</h2>
      <Form onSubmit={handleSubmit}>
        <Form.Group controlId="formNaziv">
          <Form.Label>Naziv novčanika</Form.Label>
          <Form.Control
            type="text"
            value={naziv}
            onChange={(e) => setNaziv(e.target.value)}
            required
          />
        </Form.Group>

        <Form.Group controlId="formSaldo">
          <Form.Label>Saldo</Form.Label>
          <Form.Control
            type="number"
            value={saldo}
            onChange={(e) => setSaldo(e.target.value)}
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

        <Button variant="primary" type="submit">
          Spremi novčanik
        </Button>
      </Form>
    </div>
  );
};

export default WalletiDodaj;
