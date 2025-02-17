import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RouteNames } from "../../constants";
import KriptovaluteServices from "../../services/KriptovaluteServices.js";
import { useEffect, useState } from "react";



export default function ValutePromjena(){

    const navigate  = useNavigate();
    const[valuta,setValuta]= useState({});
    const routeParmas = useParams();

    async function dohvatiValuta(){
        const odgovor = await KriptovaluteServices.getBySifra(routeParmas.kripto_id)
        setValuta(odgovor)
        
    }

    useEffect(()=>{
        dohvatiValuta()
    },[])


    async function promjena(kriptovaluta){
        const odgovor = await KriptovaluteServices.promjena(routeParmas.kripto_id,kriptovaluta);
        if (odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        navigate(RouteNames.VALUTA_PREGLED)
    }


    function odradiSubmit(e){
        e.preventDefault();

        let podatci = new FormData(e.target);

        promjena(
            {
            
                ime: podatci.get('ime'),
                simbol: podatci.get('simbol'),
                cijena: parseFloat(podatci.get('cijena')),
                trzisna_vrjednost: parseFloat(podatci.get('trzisna_vrjednost')),
                volumen: parseFloat(podatci.get('volumen'))
              }
        );
    }
    return(
        <>
        Dodavanje Valute
        <Form onSubmit={odradiSubmit}>


            <Form.Group controlId="ime">
                <Form.Label>Ime</Form.Label>
                <Form.Control type="text" name="ime" required defaultValue={valuta.ime}/>

            </Form.Group>

            <Form.Group controlId="simbol">
                <Form.Label>Simbol</Form.Label>
                <Form.Control type="text" name="simbol" defaultValue={valuta.simbol}/>

            </Form.Group>


            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="number" name="cijena" step={0.01} defaultValue={valuta.cijena}/>

            </Form.Group>



            <Form.Group controlId="trzisna_vrjednost">
                <Form.Label>Trzisna Vrjednost</Form.Label>
                <Form.Control type="number" name="trzisna_vrjednost" required defaultValue={valuta.trzisna_vrjednost}/>

            </Form.Group>

            <Form.Group controlId="volumen">
                <Form.Label>Volumen</Form.Label>
                <Form.Control type="number" name="volumen" required defaultValue={valuta.volumen}/>

            </Form.Group>
           

            <hr/>

<Row>
            <Col xs={6} sm={12} md={6} lg={2} xl={6} xxl={6}>
            <Link
            to={RouteNames.VALUTA_PREGLED}
            className = "btn btn-danger siroko"
           > Odustani</Link>
            </Col>

            <Col xs={6} sm={12} md={9} lg={10} xl={6} xxl={6}>
           <Button variant="success" type="submit" className="siroko">
           Promjeni kriptovalutu
           </Button>
            </Col>
        </Row>
        
        
        </Form>







        


        </>
    )





}