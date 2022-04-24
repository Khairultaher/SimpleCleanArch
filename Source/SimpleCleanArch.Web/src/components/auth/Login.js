import React, { Component, Fragment, useState, useEffect, useRef } from "react";
import { useDispatch, useSelector } from "react-redux";
import { useAlert } from "react-alert";
import { createHashHistory } from "history";
import { Link } from "react-router-dom";
import Loader from "../layout/Loader";
import MetaData from "../layout/MetaData";

import { login, clearErrors } from "../../redux/actions/authActions";

const Login = ({}) => {
  const [userName, setUserName] = useState();
  const [password, setPassword] = useState();
  const history = createHashHistory();
  const alert = useAlert();
  const dispatch = useDispatch();
  const { loading, isAuthenticated, user, error } = useSelector(
    (state) => state.auth
  );

  //const redirect = location.search ? location.search.split("=")[1] : "/";
  useEffect(() => {
    console.log("login");
    if (error) {
      alert.error(error);
      dispatch(clearErrors());
    }
    if (isAuthenticated) {
      history.go("/");
    }
  }, []);

  const submitHandler = async (e) => {
    e.preventDefault();

    if (isAuthenticated) {
      history.go("/");
    } else {
      await dispatch(login(userName, password));
    }
  };

  return (
    <Fragment>
      {loading ? (
        <Loader />
      ) : (
        <Fragment>
          <MetaData title={"Login"} />

          <section id="container-fluid">
            <div className="content">
              <div className="d-flex justify-content-center align-items-center">
                <div className="col-10 col-lg-5 mt-5">
                  <form className="shadow-lg mt-5" onSubmit={submitHandler}>
                    <div className="px-3">
                      <h1 className="mb-3">Login</h1>
                      <div className="form-group">
                        <label htmlFor="email_field">User Name</label>
                        <input
                          type="text"
                          id="userName"
                          className="form-control"
                          value={userName}
                          onChange={(e) => setUserName(e.target.value)}
                        />
                      </div>

                      <div className="form-group">
                        <label htmlFor="password_field">Password</label>
                        <input
                          type="password"
                          id="password"
                          className="form-control"
                          value={password}
                          onChange={(e) => setPassword(e.target.value)}
                        />
                      </div>

                      <Link to="/password/forgot" className="float-right mb-4">
                        Forgot Password?
                      </Link>

                      <button
                        id="login_button"
                        type="submit"
                        className="btn btn-block py-3"
                      >
                        LOGIN
                      </button>

                      <Link to="/register" className="float-right mt-3">
                        New User?
                      </Link>
                    </div>
                  </form>
                </div>
              </div>
            </div>
          </section>
        </Fragment>
      )}
    </Fragment>
  );
};

export default Login;
