import { Button, Col, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RouteNames } from "../../constants";
import { ESModulesEvaluator } from "vite/module-runner";


export default function ValuteDodaj(){

    const navigate  = useNavigate();


    async function dodaj(kriptovaluta){
        const odgovor = KriptovalutaService.dodaj(kriptovaluta);
        if (odgovor.greska){
            return
        }
        navigate(RouteNames.VALUTE_PREGLED)
            

    }


    function odradiSubmit(e){
        e.preventDefault();

        let podatci = new FormData(e.target);

        dodaj(
            {
            
                ime: podatci.get('ime'),
                simbol: podatci.get('simbol'),
                cijena: parseFloat(podatci.get("cijenaValute")),
                trzisna_vrjednost: 0,
                volumen: 0
              }
        );
    }
    return(
        <>
        Dodavanje Valute
        <Form onSubmit={odradiSubmit}>


            <Form.Group controlId="Nova kripto valuta">
                <Form.Label>Naziv</Form.Label>
                <Form.Control type="text" name="naziv" requierd />

            </Form.Group>



            <Form.Group controlId="cijena">
                <Form.Label>Cijena</Form.Label>
                <Form.Control type="number" name="cijena" step={0.01}/>

            </Form.Group>



            <Form.Group controlId="IzvodiSeOd">
                <Form.Label>TrzisnaVrjednost</Form.Label>
                <Form.Control type="data" name="TrzisnaVrjednost" requierd />

            </Form.Group>


            <Form.Group controlId="Simbol">
                <Form.Label>Simbol</Form.Label>
                <Form.Control type="text" name="simbol" step={0.01}/>

            </Form.Group>

            <hr/>

<Row>
            <Col xs={6} sm={12} md={6} lg={2} xl={6} xxl={6}>
            <Link
            to={RouteNames.VALUTE_PREGLED}
            className = "btn btn-danger siroko"
           > Odustani</Link>
            </Col>

            <Col xs={6} sm={12} md={9} lg={10} xl={6} xxl={6}>
           <Button variant="success" type="submit" ClassName="siroko">
           Dodaj kriptovalutu
           </Button>
            </Col>
        </Row>
        
        
        </Form>







        


        </>
    )





}