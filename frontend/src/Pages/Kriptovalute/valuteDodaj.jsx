import { Col, Row } from "react-bootstrap";
import { Link } from "react-router-dom";
import { RouteNames } from "../../constants";


export default function ValuteDodaj(){
    return(
        <>
        dodavanje Valute
        <Row>
            <Col>
            <Link
            to={RouteNames.VALUTE_PREGLED}
            className = "btn btn-danger siroko"
           > Odustani</Link>
            </Col>
        </Row>


        </>
    )





}