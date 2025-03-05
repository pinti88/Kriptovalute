import { httpService } from "./HttpService";


async function get(){
return await httpService.get('/Kriptovalute')
.then((odgovor)=> {
    
    return odgovor.data;
})
.catch((e)=>{})

}

async function getBySifra(sifra){
    return await httpService.get('/Kriptovalute/' + sifra)
    .then((odgovor)=> {
        return odgovor.data;
    })
    .catch((e)=>{})
}    


async function dodaj(kriptovaluta){
    return httpService.post('/Kriptovalute', kriptovaluta)
    .then(()=>{return {greska: false, poruka: 'Dodano'}})
    .catch(()=> {return {greska: true, poruka:'Problem kod dodavanja'}})
}

async function promjena(kripto_id,kriptovaluta){
    return httpService.put('/Kriptovalute/'+kripto_id, kriptovaluta)
    .then(()=>{return {greska: false, poruka: 'Dodano'}})
    .catch(()=> {return {greska: true, poruka:'Problem kod dodavanja'}})
}

async function obrisi(kripto_id){
    return httpService.delete('/Kriptovalute/'+kripto_id)
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

