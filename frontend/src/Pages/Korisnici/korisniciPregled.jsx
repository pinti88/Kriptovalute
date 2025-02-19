import { useEffect, useState } from "react";
import KorisniciServices from "../../services/KorisniciServices.js"; 
import { Button, Table } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";

export default function KorisniciPregled() {
  const [korisnici, setKorisnici] = useState();
  const navigate = useNavigate();

  async function dohvatiKorisnike() {
    const odgovor = await KorisniciServices.get();
    setKorisnici(odgovor);
  }

  // hooks (kuka) se izvodi prilikom dolaska na stranicu korisnika
  useEffect(() => {
    dohvatiKorisnike();
  }, []);

  function obrisi(sifra) {
    if (!confirm('Jeste li sigurni da želite obrisati korisnika?')) {
      return;
    }
    BrisanjeKorisnika(sifra);
  }

  async function BrisanjeKorisnika(korisnik_id) {
    const odgovor = await KorisniciServices.obrisi(korisnik_id);
    if (odgovor.greska) {
      alert(odgovor.poruka);
      return;
    }
    dohvatiKorisnike();
  }

  return (
    <>
      <Link
        to={RouteNames.KORISNIK_NOVI}
        className="btn btn-success siroko"
      >
        Dodaj novog korisnika
      </Link>
      <Table striped bordered hover responsive>
        <thead>
          <tr>
            <th>Ime</th>
            <th>Email</th>
            <th>Uloga</th>
            <th>Datum registracije</th>
            <th>Akcija</th>
          </tr>
        </thead>

        <tbody>
          {korisnici && korisnici.map((korisnik, index) => (
            <tr key={index}>
              <td>{korisnik.ime}</td>
              <td>{korisnik.email}</td>
              <td>{korisnik.uloga}</td>
              <td>{korisnik.datum_registracije}</td>
              <td>
                <Button
                  onClick={() => navigate(`/Korisnici/${korisnik.korisnik_id}`)}
                >
                  Promjena
                </Button>
                &nbsp;&nbsp;&nbsp;

                <Button
                  variant="danger"
                  onClick={() => obrisi(korisnik.korisnik_id)}
                >
                  Obriši
                </Button>
              </td>
            </tr>
          ))}
        </tbody>
      </Table>
    </>
  );
}
