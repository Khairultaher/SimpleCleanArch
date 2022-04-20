import { BrowserRouter, HashRouter, Routes, Route } from "react-router-dom";
import "./App.css";

import Header from "./components/layout/Header";
import Menu from "./components/layout/Menu";
import Footer from "./components/layout/Footer";
import Dashboard from "./components/Dashboard";
import WeatherForecast from "./components/WeatherForecast";

function App() {
  return (
    <div className="wrapper">
      <BrowserRouter>
        <Header />
        <Menu />
        <section className="content-wrapper">
          <Routes>
            <Route path="/" element={<Dashboard />} />
            <Route path="/weatherforecast" element={<WeatherForecast />} />
          </Routes>
        </section>

        <Footer />
      </BrowserRouter>
    </div>
  );
}

export default App;
