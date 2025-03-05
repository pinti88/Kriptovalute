import { useEffect, useState } from "react";
import { Button, Table } from "react-bootstrap";
import { Link } from "react-router-dom";
import { RouteNames } from "../../constants";
import WalletServices from "../../services/WalletServices.js";

export default function WalletPregled() {

    const [walleti, setWalleti] = useState([]);

    useEffect(() => {
        async function dohvatiPodatke() {
            const podaci = await WalletServices.get();
            setWalleti(podaci);
        }
        dohvatiPodatke();
    }, []);

    async function obrisi(wallet_id) {
        const odgovor = await WalletServices.obrisi(wallet_id);
        if (odgovor.greska) {
            alert(odgovor.poruka);
            return;
        }
        setWalleti(walleti.filter(wallet => wallet.wallet_id !== wallet_id));
    }

    return (
        <>
            <h2>Pregled Walleta</h2>
            <Link to={RouteNames.WALLET_DODAJ} className="btn btn-primary mb-3">Dodaj novi Wallet</Link>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Mreža</th>
                        <th>Ključ</th>
                        <th>ID Korisnika</th>
                        <th>Akcije</th>
                    </tr>
                </thead>
                <tbody>
                    {walleti.map(wallet => (
                        <tr key={wallet.wallet_id}>
                            <td>{wallet.wallet_id}</td>
                            <td>{wallet.mreza}</td>
                            <td>{wallet.kljuc}</td>
                            <td>{wallet.korisnik_id}</td>
                            <td>
                                <Link to={`${RouteNames.WALLET_PROMJENA}/${wallet.wallet_id}`} className="btn btn-warning me-2">
                                    Uredi
                                </Link>
                                <Button variant="danger" onClick={() => obrisi(wallet.wallet_id)}>
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
