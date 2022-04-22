import React, { StrictMode } from "react";
//import { BrowserRouter } from 'react-router-dom';
//import ReactDOM from "react-dom";
import { createRoot } from "react-dom/client";

import { Provider } from "react-redux";
import store from "./redux/store";

import { positions, transitions, Provider as AlertProvider } from "react-alert";
import AlertTemplate from "react-alert-template-basic";

import "./index.css";
import App from "./App";

import reportWebVitals from "./reportWebVitals";

const options = {
  timeout: 5000,
  position: positions.BOTTOM_CENTER,
  transition: transitions.SCALE,
};

const rootElement = document.getElementById("root");
const root = createRoot(rootElement);

root.render(
  <Provider store={store}>
    <AlertProvider template={AlertTemplate} {...options}>
      <StrictMode>
        <App />
      </StrictMode>
    </AlertProvider>
  </Provider>
);

reportWebVitals();
