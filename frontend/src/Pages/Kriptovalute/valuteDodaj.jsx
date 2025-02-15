import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import KriptovaluteServices from "../../services/KriptovaluteServices.js";



export default function ValuteDodaj(){

    const navigate  = useNavigate();


    async function dodaj(kriptovaluta){
        const odgovor = await KriptovaluteServices.dodaj(kriptovaluta);
        if (odgovor.greska){
            alert(odgovor.poruka)
            return
        }
        navigate(RouteNames.VALUTA_PREGLED)
            

    }


    function odradiSubmit(e){
        e.preventDefault();

        let podatci = new FormData(e.target);

        dodaj(
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
                <Form.Control type="text" name="ime" required />

            </Form.Group>

            <Form.Group controlId="simbol">
                <Form.Label>Simbol</Form.Label>
                <Form.Control type="text" name="simbol" />

            </Form.Group>


            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="number" name="cijena" step={0.01}/>

            </Form.Group>



            <Form.Group controlId="trzisna_vrjednost">
                <Form.Label>Trzisna Vrjednost</Form.Label>
                <Form.Control type="number" name="trzisna_vrjednost" required />

            </Form.Group>

            <Form.Group controlId="volumen">
                <Form.Label>Volumen</Form.Label>
                <Form.Control type="number" name="volumen" required />

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
           Dodaj kriptovalutu
           </Button>
            </Col>
        </Row>
        
        
        </Form>







        


        </>
    )





}