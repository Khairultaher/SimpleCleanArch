import React, { Component, Fragment, useState, useEffect, useRef } from "react";
import Pagination from "react-js-pagination";
import { Modal } from "bootstrap";

import { useDispatch, useSelector } from "react-redux";
import { useAlert } from "react-alert";

import {
  addForcast,
  clearErrors,
} from "../redux/actions/weatherForcastActions";

import {
  ADD_FORCAST_RESET,
  CLEAR_ERRORS,
} from "../redux/constants/weatherForcastConstants";

import Loader from "./layout/Loader";

const AddWeatherForecast = (props) => {
  const [temperatureC, setTemperatureC] = useState("");
  const [temperatureF, setTemperatureF] = useState("");
  const [summary, setSummary] = useState("");

  const alert = useAlert();
  const dispatch = useDispatch();

  useEffect(() => {
    if (props.show) {
      console.log(props.data);
      showModal();
    }
  });

  const modalRef = useRef();

  const showModal = () => {
    const modalEle = modalRef.current;
    const bsModal = new Modal(modalEle, {
      backdrop: "static",
      keyboard: false,
    });
    bsModal.show();
  };

  const hideModal = () => {
    const modalEle = modalRef.current;
    const bsModal = Modal.getInstance(modalEle);
    bsModal.hide();
    props.onCloseModalClick();
  };
  return (
    <div className="modal fade" ref={modalRef} tabIndex="-1">
      <div className="modal-dialog">
        <div className="modal-content">
          <div className="modal-header">
            <h5 className="modal-title" id="staticBackdropLabel">
              Modal title
            </h5>
            <button
              type="button"
              className="close"
              onClick={hideModal}
              data-dismiss="modal"
              aria-label="Close"
            >
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <div className="modal-body">...</div>
          <div className="modal-footer">
            <button
              type="button"
              className="btn btn-secondary"
              onClick={hideModal}
              data-dismiss="modal"
            >
              Close
            </button>
            <button type="button" className="btn btn-primary">
              Understood
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default AddWeatherForecast;
