import { useEffect, useState } from "react"
import KriptovaluteServices from "../../services/KriptovaluteServices"
import { Table } from "react-bootstrap";
import { NumericFormat } from "react-number-format";
import { Link } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function ValutePregled(){


    const[kriptovalute,setKriptovalute] = useState();
    async function dohvatiKriptovalute(){
        const odgovor = await KriptovaluteServices.get()
        setKriptovalute(odgovor)
    }

    // hooks (kuka) se izvodi priliko mdolaska na stranicu kritpovalute 
    useEffect(()=>{
        //debugger;
       dohvatiKriptovalute();
    },[]) 



    return(
        <>

        <Link
        to={RouteNames.VALUTA_NOVI}
        className="btn btn-success siroko"

        >Dodaj novu kritovalutu</Link>
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
                        <td className={kriptovaluta.cijena==null ? 'sredina' : 'desno'}>
                            <NumericFormat
                                value={kriptovaluta.cijena}
                                displayType={'text'}
                                thousandSeparator='.'
                                decimalSeparator=","
                                prefix={'$'}
                                decimalScale={2}
                                fixedDecimalScale
                                />

                        
                        </td>
                    </tr>
                ))}
            </tbody>
        </Table>
        </>
    )
}