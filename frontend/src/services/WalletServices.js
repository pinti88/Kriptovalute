import { httpService } from "./HttpService";

async function get() {
    return await httpService.get('/Walleti')
        .then((odgovor) => {
            return odgovor.data;
        })
        .catch((e) => {
            return { greska: true, poruka: 'Problem kod dohvaćanja podataka o walletima' };
        });
}

async function getById(id) {
    return await httpService.get('/Walleti/' + id)
        .then((odgovor) => {
            return odgovor.data;
        })
        .catch((e) => {
            return { greska: true, poruka: 'Problem kod dohvaćanja Walleti' };
        });
}

async function dodaj(transakcija) {
    return httpService.post('/Walleti', transakcija)
        .then(() => { return { greska: false, poruka: 'Wallet dodan' }; })
        .catch(() => { return { greska: true, poruka: 'Problem kod dodavanja Walleta' }; });
}

async function promjena(id, transakcija) {
    return httpService.put('/Walleti/' + id, transakcija)
        .then(() => { return { greska: false, poruka: 'Wallet ažuriran' }; })
        .catch(() => { return { greska: true, poruka: 'Problem kod ažuriranja Walleta' }; });
}

async function obrisi(id) {
    return httpService.delete('/Walleti/' + id)
        .then(() => { return { greska: false, poruka: 'Wallet obrisan' }; })
        .catch(() => { return { greska: true, poruka: 'Problem kod brisanja Walleta' }; });
}

export default {
    get,
    getById,
    dodaj,
    promjena,
    obrisi
};
