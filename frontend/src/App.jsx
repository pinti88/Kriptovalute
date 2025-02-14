import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import { Container } from 'react-bootstrap'
import NavBarEdunova from './components/NavBarEdunova'
import { Route, Routes } from 'react-router-dom'
import { RouteNames } from './constants'
import Pocetna from './Pages/Pocetna'
import ValutePregled from './Pages/Kriptovalute/ValutePregled'
import ValuteDodaj from './Pages/Kriptovalute/valuteDodaj'

function App() {
  

  return (
    <>
      <Container>

        <NavBarEdunova></NavBarEdunova>
        <Routes>
          <Route path={RouteNames.HOME} element={<Pocetna />} />
          <Route path={RouteNames.VALUTE_PREGLED} element={<ValutePregled />} />
          <Route path={RouteNames.VALUTA_NOVI} element={<ValuteDodaj/>}/>
          <Route path={RouteNames.VALUTA_PROMJENA} element={<ValutePromjena/>}/>
        </Routes>

        <hr />
        &copy; Kriptovalute 2025
      
      </Container>

      
    </>
  )
}

export default App

