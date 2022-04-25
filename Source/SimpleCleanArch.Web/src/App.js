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
import ProtectedRoute from "./components/route/ProtectedRoute";

function App() {
  const { loading, isAuthenticated, user, error } = useSelector(
    (state) => state.auth
  );
  return (
    <div className="wrapper">
      <BrowserRouter>
        {isAuthenticated && (
          <>
            <Header />
            <Menu />
          </>
        )}
        <section className={isAuthenticated ? "content-wrapper" : ""}>
          <Routes>
            <Route
              path="/"
              element={<ProtectedRoute Component={Dashboard} />}
            />
            <Route
              path="/dashboard"
              element={<ProtectedRoute Component={Dashboard} />}
            />
            <Route
              path="/weatherforecast"
              element={<ProtectedRoute Component={WeatherForecast} />}
            />
            <Route path="/login" element={<Login />} />
            <Route
              path="/logout"
              element={<ProtectedRoute Component={Logout} />}
            />
          </Routes>
        </section>
        {isAuthenticated && <Footer />}
      </BrowserRouter>
    </div>
  );
}

export default App;
