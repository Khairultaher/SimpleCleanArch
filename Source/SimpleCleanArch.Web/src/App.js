import { BrowserRouter, HashRouter, Routes, Route } from "react-router-dom";
import "./App.css";
import { useDispatch, useSelector } from "react-redux";
import { useAlert } from "react-alert";

import Header from "./components/layout/Header";
import Menu from "./components/layout/Menu";
import Footer from "./components/layout/Footer";
import Dashboard from "./components/Dashboard";
import WeatherForecast from "./components/WeatherForecast";
import Login from "./components/auth/Login";
import Logout from "./components/auth/Logout";

function App() {
  const { loading, isAuthenticated, user, error } = useSelector(
    (state) => state.auth
  );
  return (
    <div className="wrapper">
      {isAuthenticated && (
        <BrowserRouter>
          <Header />
          <Menu />
          <section className="content-wrapper">
            <Routes>
              <Route path="/" element={<Dashboard />} />
              <Route path="/weatherforecast" element={<WeatherForecast />} />
              <Route path="/logout" element={<Logout />} />
            </Routes>
          </section>
          <Footer />
        </BrowserRouter>
      )}
      {!isAuthenticated && (
        <BrowserRouter>
          <Routes>
            <Route path="/login" element={<Login />} />
          </Routes>
        </BrowserRouter>
      )}
    </div>
  );
}

export default App;
