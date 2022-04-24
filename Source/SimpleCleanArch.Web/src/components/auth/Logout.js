import React, { Component, Fragment, useState, useEffect, useRef } from "react";
import { createHashHistory } from "history";
import { useDispatch, useSelector } from "react-redux";
import { useAlert } from "react-alert";

import Loader from "../layout/Loader";

import { logout, clearErrors } from "../../redux/actions/authActions";

const Logout = ({ props }) => {
  const [userName, setUserName] = useState();
  const [password, setPassword] = useState();

  const history = createHashHistory();

  const alert = useAlert();
  const dispatch = useDispatch();
  const { loading, isAuthenticated, user, error } = useSelector(
    (state) => state.auth
  );

  useEffect(() => {
    console.log("logout");
    if (error) {
      alert.error(error);
      dispatch(clearErrors());
    }
    console.log(isAuthenticated);
    if (isAuthenticated) {
      dispatch(logout());
    }
    history.go("/login");
  }, []);

  return <Fragment>{loading ? <Loader /> : <Fragment></Fragment>}</Fragment>;
};

export default Logout;
