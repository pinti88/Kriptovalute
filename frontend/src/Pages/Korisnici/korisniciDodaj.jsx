import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import KorisniciServices from "../../services/KorisniciServices.js";

export default function KorisniciDodaj(){

    const navigate  = useNavigate();

    async function dodaj(korisnik){
        const odgovor = await KorisniciServices.dodaj(korisnik);
        if (odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        navigate(RouteNames.KORISNIK_PREGLED)
    }

    function odradiSubmit(e){
        e.preventDefault();

        let podatci = new FormData(e.target);

        dodaj(
            {
                korisnik_id: parseInt(podatci.get('korisnik_id')),
                ime: podatci.get('ime'),
                prezime: podatci.get('prezime'),
                email: podatci.get('email'),
                telefonski_broj: podatci.get('telefonski_broj')
            }
        );
    }
    return(
        <>
        Dodavanje Korisnika
        <Form onSubmit={odradiSubmit}>

            <Form.Group controlId="korisnik_id">
                <Form.Label>ID</Form.Label>
                <Form.Control type="number" name="korisnik_id" required />
            </Form.Group>

            <Form.Group controlId="ime">
                <Form.Label>Ime</Form.Label>
                <Form.Control type="text" name="ime" required />
            </Form.Group>

            <Form.Group controlId="prezime">
                <Form.Label>Prezime</Form.Label>
                <Form.Control type="text" name="prezime" required />
            </Form.Group>

            <Form.Group controlId="email">
                <Form.Label>Email</Form.Label>
                <Form.Control type="email" name="email" required />
            </Form.Group>

            <Form.Group controlId="telefonski_broj">
                <Form.Label>Telefonski Broj</Form.Label>
                <Form.Control type="text" name="telefonski_broj" required />
            </Form.Group>
           
            <hr/>

            <Row>
                <Col xs={6} sm={12} md={6} lg={2} xl={6} xxl={6}>
                    <Link
                        to={RouteNames.KORISNIK_PREGLED}
                        className = "btn btn-danger siroko"
                    > Odustani</Link>
                </Col>

                <Col xs={6} sm={12} md={9} lg={10} xl={6} xxl={6}>
                    <Button variant="success" type="submit" className="siroko">
                        Dodaj korisnika
                    </Button>
                </Col>
            </Row>
        </Form>
        </>
    )
}
