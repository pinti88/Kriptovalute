import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { Container } from 'react-bootstrap';
import NavBarEdunova from './components/NavBarEdunova';
import { Route, Routes } from 'react-router-dom';
import { RouteNames } from './constants';
import Pocetna from './Pages/Pocetna';
import ValutePregled from './Pages/Kriptovalute/ValutePregled';
import ValuteDodaj from './Pages/Kriptovalute/ValuteDodaj';
import ValutePromjena from './Pages/Kriptovalute/ValutePromjena';
import KorisniciPregled from './Pages/Korisnici/KorisniciPregled';
import KorisniciPromjena from './Pages/Korisnici/KorisniciPromjena';
import KorisniciDodaj from './Pages/Korisnici/KorisniciDodaj';
import TransakcijePregled from './Pages/Transakcije/TransakcijePregled';
import TransakcijeDodaj from './Pages/Transakcije/TransakcijeDodaj';
import TransakcijePromjena from './Pages/Transakcije/TransakcijePromjena';

function App() {
  return (
    <>
      <Container>
        <NavBarEdunova />
        <Routes>
          <Route path={RouteNames.HOME} element={<Pocetna />} />
          <Route path={RouteNames.VALUTA_PREGLED} element={<ValutePregled />} />
          <Route path={RouteNames.VALUTA_NOVI} element={<ValuteDodaj />} />
          <Route path={RouteNames.VALUTA_PROMJENA} element={<ValutePromjena />} />
          <Route path={RouteNames.KORISNICI_PREGLED} element={<KorisniciPregled />} />
          <Route path={RouteNames.KORISNICI_DODAJ} element={<KorisniciDodaj />} />
          <Route path={RouteNames.KORISNICI_PROMJENA} element={<KorisniciPromjena />} />
          <Route path={RouteNames.TRANSAKCIJE_PREGLED} element={<TransakcijePregled />} />
          <Route path={RouteNames.TRANSAKCIJE_DODAJ} element={<TransakcijeDodaj />} />
          <Route path={RouteNames.TRANSAKCIJE_PROMJENA} element={<TransakcijePromjena />} />
        </Routes>
        <hr />
        &copy; Kriptovalute 2025
      </Container>
    </>
  );
}

export default App;
