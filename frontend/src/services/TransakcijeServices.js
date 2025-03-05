import { httpService } from "./HttpService";

async function get() {
    return await httpService.get('/Transakcije')
        .then((odgovor) => {
            return odgovor.data;
        })
        .catch((e) => {
            return { greska: true, poruka: 'Problem kod dohvaćanja podataka o transakcijama' };
        });
}

async function getById(id) {
    return await httpService.get('/Transakcije/' + id)
        .then((odgovor) => {
            return odgovor.data;
        })
        .catch((e) => {
            return { greska: true, poruka: 'Problem kod dohvaćanja transakcije' };
        });
}

async function dodaj(transakcija) {
    return httpService.post('/Transakcije', transakcija)
        .then(() => { return { greska: false, poruka: 'Transakcija dodana' }; })
        .catch(() => { return { greska: true, poruka: 'Problem kod dodavanja transakcije' }; });
}

async function promjena(id, transakcija) {
    return httpService.put('/Transakcije/' + id, transakcija)
        .then(() => { return { greska: false, poruka: 'Transakcija ažurirana' }; })
        .catch(() => { return { greska: true, poruka: 'Problem kod ažuriranja transakcije' }; });
}

async function obrisi(id) {
    return httpService.delete('/Transakcije/' + id)
        .then(() => { return { greska: false, poruka: 'Transakcija obrisana' }; })
        .catch(() => { return { greska: true, poruka: 'Problem kod brisanja transakcije' }; });
}

export default {
    get,
    getById,
    dodaj,
    promjena,
    obrisi
};
