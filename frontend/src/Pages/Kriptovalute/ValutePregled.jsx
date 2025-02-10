import { useEffect, useState } from "react"
import KriptovaluteServices from "../../services/KriptovaluteServices"
import { Table } from "react-bootstrap";


export default function ValutePregled(){


    const[kriptovalute,setKriptovalute] = useState();
    async function dohvatiKriptovalute(){
        const odgovor = await KriptovaluteServices.get()
        setKriptovalute(odgovor)
    }

    // hooks (kuka) se izvodi priliko mdolaska na stranicu kritpovalute 
    useEffect(()=>{
       dohvatiKriptovalute();
    },[]) 



    return(
        <>
        <Table striped bordered hover responsive>
            <thead>
                <tr>
                    <th>Ime</th>
                    <th>Simbol</th>
                    <th>Volumen</th>
                    <th>Trzisna_vrjednost</th>
                    <th>Cijena</th>
                </tr>
            </thead>

            <tbody>
                {kriptovalute && kriptovalute.map((kriptovaluta,index)=>(
                    <tr key = {index}>
                        
                        <td>
                            {kriptovaluta.ime}
                        </td>
                        <td>
                            {kriptovaluta.simbol}
                        </td>
                        <td>
                            {kriptovaluta.volumen}
                        </td>
                        <td>
                            {kriptovaluta.trzisna_vrjednost}
                        </td>
                        <td>
                            {kriptovaluta.cijena}
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )
}