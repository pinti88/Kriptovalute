import { useEffect, useState } from "react";
import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants.js";
import WalletServices from "../../services/WalletServices.js";

export default function WalletiPromjena() {
    const { wallet_id } = useParams();
    const navigate = useNavigate();
    const [wallet, setWallet] = useState({
        wallet_id: "",
        mreza: "",
        kljuc: "",
        korisnik_id: "",
    });

    useEffect(() => {
        async function dohvatiWallet() {
            const podaci = await WalletServices.getBySifra(wallet_id);
            if (podaci) setWallet(podaci);
        }
        dohvatiWallet();
    }, [wallet_id]);

    async function promjeni(wallet) {
        const odgovor = await WalletServices.promjena(wallet_id, wallet);
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        navigate(RouteNames.WALLET_PREGLED);
    }

    function odradiSubmit(e) {
        e.preventDefault();
        let podatci = new FormData(e.target);

        promjeni({
            wallet_id: parseInt(podatci.get("wallet_id")),
            mreza: podatci.get("mreza"),
            kljuc: podatci.get("kljuc"),
            korisnik_id: parseInt(podatci.get("korisnik_id")),
        });
    }

    return (
        <>
            <h2>Promjena Walleta</h2>
            <Form onSubmit={odradiSubmit}>
                <Form.Group controlId="wallet_id">
                    <Form.Label>ID</Form.Label>
                    <Form.Control type="number" name="wallet_id" value={wallet.wallet_id} disabled />
                </Form.Group>

                <Form.Group controlId="mreza">
                    <Form.Label>Mreža</Form.Label>
                    <Form.Control type="text" name="mreza" defaultValue={wallet.mreza} required />
                </Form.Group>

                <Form.Group controlId="kljuc">
                    <Form.Label>Ključ</Form.Label>
                    <Form.Control type="text" name="kljuc" defaultValue={wallet.kljuc} required />
                </Form.Group>

                <Form.Group controlId="korisnik_id">
                    <Form.Label>ID Korisnika</Form.Label>
                    <Form.Control type="number" name="korisnik_id" defaultValue={wallet.korisnik_id} required />
                </Form.Group>

                <hr />

                <Row>
                    <Col xs={6}>
                        <Link to={RouteNames.WALLET_PREGLED} className="btn btn-danger siroko">
                            Odustani
                        </Link>
                    </Col>

                    <Col xs={6}>
                        <Button variant="success" type="submit" className="siroko">
                            Spremi promjene
                        </Button>
                    </Col>
                </Row>
            </Form>
        </>
    );
}
