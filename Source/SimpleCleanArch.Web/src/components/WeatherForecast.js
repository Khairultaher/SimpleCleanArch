import React, { Component, Fragment, useState, useEffect } from "react";
import Pagination from "react-js-pagination";

import { useDispatch, useSelector } from "react-redux";
import { useAlert } from "react-alert";

import { getAllForcast } from "../redux/actions/weatherForcastActions";

import Loader from "./layout/Loader";

const WeatherForecast = ({}) => {
  const [currentPage, setCurrentPage] = useState(1);
  const [resPerPage, setResPerPage] = useState(10);

  const alert = useAlert();
  const dispatch = useDispatch();

  const { loading, forecasts, error, count } = useSelector(
    (state) => state.allForcast
  );

  useEffect(() => {
    if (error) {
      return alert.error(error);
    }

    dispatch(getAllForcast(currentPage, resPerPage));
  }, [dispatch, currentPage, alert, error]);

  function setCurrentPageNo(pageNumber) {
    setCurrentPage(pageNumber);
  }

  return (
    <>
      <section className="container-fluid">
        <div className="content-header">
          <div className="row mb-2">
            <div className="col-sm-6">
              <h1 className="m-0 text-dark">Dashboard</h1>
            </div>
            <div className="col-sm-6">
              <ol className="breadcrumb float-sm-right">
                <li className="breadcrumb-item">
                  <a href="#">Home</a>
                </li>
                <li className="breadcrumb-item active">Dashboard v1</li>
              </ol>
            </div>
          </div>
        </div>
      </section>
      <section className="container-fluid">
        <div className="content">
          <Fragment>
            {loading ? (
              <Loader />
            ) : (
              <Fragment>
                <section id="content">
                  <table
                    className="table table-striped"
                    aria-labelledby="tabelLabel"
                  >
                    <thead>
                      <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                        <th>Actios</th>
                      </tr>
                    </thead>
                    <tbody>
                      {forecasts.map((forecast) => (
                        <tr key={forecast.date}>
                          <td>{forecast.date}</td>
                          <td>{forecast.temperatureC}</td>
                          <td>{forecast.temperatureF}</td>
                          <td>{forecast.summary}</td>
                          <td>
                            <div className="d-flex justify-content-start">
                              <a className="btn mr-1">
                                <i className="fas fa-edit text-warning"></i>
                              </a>
                              <a className="btn">
                                <i className="fas fa-trash-alt text-danger"></i>
                              </a>
                            </div>
                          </td>
                        </tr>
                      ))}
                    </tbody>
                  </table>
                </section>

                <section id="paggination">
                  {resPerPage <= count && (
                    <div className="d-flex justify-content-center mt-5">
                      <Pagination
                        activePage={currentPage}
                        itemsCountPerPage={resPerPage}
                        totalItemsCount={count}
                        onChange={setCurrentPageNo}
                        nextPageText={"Next"}
                        prevPageText={"Prev"}
                        firstPageText={"First"}
                        lastPageText={"Last"}
                        itemClass="page-item"
                        linkClass="page-link"
                      />
                    </div>
                  )}
                </section>
              </Fragment>
            )}
          </Fragment>
        </div>
      </section>
    </>
  );
};

export default WeatherForecast;
