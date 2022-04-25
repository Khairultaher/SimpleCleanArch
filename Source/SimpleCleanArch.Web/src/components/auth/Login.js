import React, { Component, Fragment, useState, useEffect, useRef } from "react";
import { Redirect } from "react-router";
import { useDispatch, useSelector } from "react-redux";
import { useAlert } from "react-alert";
import { createHashHistory } from "history";
import { Link } from "react-router-dom";
import Loader from "../layout/Loader";
import MetaData from "../layout/MetaData";
import { useNavigate } from "react-router-dom";
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

  const navigate = useNavigate();
  //const redirect = location.search ? location.search.split("=")[1] : "/";
  useEffect(() => {
    console.log("login");
    if (error) {
      alert.error(error);
      dispatch(clearErrors());
    }
    if (isAuthenticated) {
      navigate("/");
    }
  }, [dispatch, isAuthenticated]);

  const submitHandler = async (e) => {
    e.preventDefault();

    if (!isAuthenticated) {
      await dispatch(login(userName, password));
    }
  };

  return (
    <Fragment>
      {loading ? (
        <div className="vh-100 d-flex justify-content-center align-items-center">
          <div className="col-10 col-lg-5">
            <div className="mb-5">
              <Loader />
            </div>
          </div>
        </div>
      ) : (
        <Fragment>
          <MetaData title={"Login"} />
          <div className="vh-100 d-flex justify-content-center align-items-center">
            <div className="shadow-lg col-10 col-lg-5">
              <form className="px-3 py-3" onSubmit={submitHandler}>
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
                  className="btn btn-block btn-success"
                >
                  LOGIN
                </button>

                <div className="form-group">
                  <Link to="/register" className="float-right mt-3 mb-3">
                    New User?
                  </Link>
                </div>
              </form>
            </div>
          </div>
        </Fragment>
      )}
    </Fragment>
  );
};

export default Login;
