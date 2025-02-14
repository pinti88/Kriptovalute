import { httpService } from "./HttpService";


async function get(){
return await httpService.get('/Kriptovalute')
.then((odgovor)=> {
    //console.table(odgovor.data)
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

export default{
    get,
    getBySifra,
    dodaj
}