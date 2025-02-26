import { httpService } from "./HttpService";


async function get(){
    return await httpService.get('/Korisnici')
    .then((odgovor)=> {
        //console.table(odgovor.data)
        return odgovor.data;
    })
    .catch((e)=>{})

}

async function getBySifra(sifra){
    return await httpService.get('/Korisnici/' + sifra)
    .then((odgovor)=> {
        return odgovor.data;
    })
    .catch((e)=>{})
}    


async function dodaj(Korisnici){
    return httpService.post('/Korisnici', Korisnici)
    .then(()=>{return {greska: false, poruka: 'Dodano'}})
    .catch(()=> {return {greska: true, poruka:'Problem kod dodavanja'}})
}

async function promjena(Korisnik,Korisnici){
    return httpService.put('/Korisnici/'+Korisnik, Korisnici)
    .then(()=>{return {greska: false, poruka: 'Dodano'}})
    .catch(()=> {return {greska: true, poruka:'Problem kod dodavanja'}})
}

async function obrisi(Korisnik){
    return httpService.delete('/Korisnici/'+Korisnik)
    .then(()=>{return {greska: false, poruka: 'Dodano'}})
    .catch(()=> {return {greska: true, poruka:'Problem kod dodavanja'}})
}


export default{
    get,
    getBySifra,
    dodaj,
    promjena,
    obrisi
}

