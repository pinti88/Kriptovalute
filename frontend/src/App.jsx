import 'bootstrap/dist/css/bootstrap.min.css'
import './App.css'
import { Container } from 'react-bootstrap'
import NavBarEdunova from './components/NavBarEdunova'
import { Route, Routes } from 'react-router-dom'
import { RouteNames } from './constants'
import Pocetna from './Pages/Pocetna'
import ValutePregled from './Pages/Kriptovalute/ValutePregled'
import ValuteDodaj from './Pages/Kriptovalute/valuteDodaj'
import ValutePromjena from './Pages/Kriptovalute/valutePromjena'
import KorisniciPregled from './Pages/Korisnici/korisniciPregled'
import KorisniciPromjena from './Pages/Korisnici/korisniciPromjena'
import KorisniciDodaj from './Pages/Korisnici/korisniciDodaj'


function App() {
  

  return (
    <>
      <Container>

        <NavBarEdunova></NavBarEdunova>
        <Routes>
          <Route path={RouteNames.HOME} element={<Pocetna />} />
          <Route path={RouteNames.VALUTA_PREGLED} element={<ValutePregled />} />
          <Route path={RouteNames.VALUTA_NOVI} element={<ValuteDodaj/>}/>
          <Route path={RouteNames.VALUTA_PROMJENA} element={<ValutePromjena/>}/> 
          <Route path={RouteNames.KORISNICI_PREGLED} element={KorisniciPregled/>}/>
          <Route path={RouteNames.KORISNICI_DODAJ} element={KorisniciDodaj/>}/>
          <Route path={RouteNames.KORISNICI_PROMJENA} element={KorisniciPromjena/>}/>
        </Routes>

        
        

        <hr />
        &copy; Kriptovalute 2025
      
      </Container>

      
    </>
  )
}

export default App

