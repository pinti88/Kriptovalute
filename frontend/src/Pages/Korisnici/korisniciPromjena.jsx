import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import KorisniciServices from "../../services/KorisniciServices.js";
import { useEffect, useState } from "react";

export default function KorisniciPromjena() {
    const navigate = useNavigate();
    const [korisnik, setKorisnik] = useState({});
    const routeParams = useParams();

    async function dohvatiKorisnika() {
        const odgovor = await KorisniciServices.getBySifra(routeParams.korisnik_id);
        setKorisnik(odgovor);
    }

    useEffect(() => {
        dohvatiKorisnika();
    }, []);

    async function promjena(korisnik) {
        const odgovor = await KorisniciServices.promjena(routeParams.korisnik_id, korisnik);
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.KORISNICI_PREGLED);
    }

    function odradiSubmit(e) {
        e.preventDefault();
        let podatci = new FormData(e.target);

        promjena({
            ime: podatci.get("ime"),
            prezime: podatci.get("prezime"),
            email: podatci.get("email"),
            telefonski_broj: podatci.get("telefonski_broj")
        });
    }

    return (
        <>
            Promjena Korisnika
            <Form onSubmit={odradiSubmit}>
                <Form.Group controlId="ime">
                    <Form.Label>Ime</Form.Label>
                    <Form.Control type="text" name="ime" required defaultValue={korisnik.ime} />
                </Form.Group>

                <Form.Group controlId="prezime">
                    <Form.Label>Prezime</Form.Label>
                    <Form.Control type="text" name="prezime" required defaultValue={korisnik.prezime} />
                </Form.Group>

                <Form.Group controlId="email">
                    <Form.Label>Email</Form.Label>
                    <Form.Control type="email" name="email" required defaultValue={korisnik.email} />
                </Form.Group>

                <Form.Group controlId="telefonski_broj">
                    <Form.Label>Telefonski broj</Form.Label>
                    <Form.Control type="text" name="telefonski_broj" required defaultValue={korisnik.telefonski_broj} />
                </Form.Group>

                <hr />

                <Row>
                    <Col xs={6} sm={12} md={6} lg={2} xl={6} xxl={6}>
                        <Link to={RouteNames.KORISNICI_PREGLED} className="btn btn-danger siroko">
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6} sm={12} md={9} lg={10} xl={6} xxl={6}>
                        <Button variant="success" type="submit" className="siroko">
                            Promjeni korisnika
                        </Button>
                    </Col>
                </Row>
            </Form>
        </>
    );
}
