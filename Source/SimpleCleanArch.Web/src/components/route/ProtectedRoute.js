import React, { Fragment } from "react";
import {
  BrowserRouter,
  HashRouter,
  Navigate,
  Routes,
  Route,
} from "react-router-dom";
import { useDispatch, useSelector } from "react-redux";

const ProtectedRoute = ({ Component, ...rest }) => {
  const { loading, isAuthenticated, user, error } = useSelector(
    (state) => state.auth
  );
  return isAuthenticated ? <Component /> : <Navigate to="/login" />;

  //   return (
  //     <Fragment>
  //       {loading === false && (
  //         <Route
  //           {...rest}
  //           render={(props) => {
  //             if (isAuthenticated === false) {
  //               return <Navigate to="/login" />;
  //             }

  //             // if (isAdmin === true && user.role !== "admin") {
  //             //   return <Navigate to="/" />;
  //             // }

  //             return <Component {...props} />;
  //           }}
  //         />
  //       )}
  //     </Fragment>
  //   );
};

export default ProtectedRoute;
