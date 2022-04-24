import axios from "axios";
import config from "../../config.json";

import { loginReducer, logoutReducer } from "../reducers/authReducers";
import {
  LOGIN_REQUEST,
  LOGIN_SUCCESS,
  LOGIN_FAIL,
  LOGOUT_REQUEST,
  LOGOUT_SUCCESS,
  LOGOUT_FAIL,
  CLEAR_ERRORS,
} from "../constants/authConstants";

// login
export const login = (userName, password) => async (dispatch) => {
  let link = `${config.API_BASE_URL}/api/auth/login`;
  let user = { userName: userName, password: password };

  try {
    dispatch({ type: LOGIN_REQUEST });

    const config = {
      headers: {
        "Content-Type": "application/json",
      },
    };

    const { data } = await axios.post(link, user, config);
    console.log(data);

    dispatch({
      type: LOGIN_SUCCESS,
      payload: data.data,
    });
  } catch (error) {
    console.log(error);
    dispatch({
      type: LOGIN_FAIL,
      payload: error,
    });
  }
};

// logout
export const logout = () => async (dispatch) => {
  let link = `${config.API_BASE_URL}/api/auth/login`;
  try {
    dispatch({ type: LOGOUT_REQUEST });

    // const config = {
    //   headers: {
    //     "Content-Type": "application/json",
    //   },
    // };

    // const { data } = await axios.post(link, loginModel, config);
    console.log(LOGOUT_REQUEST);
    dispatch({
      type: LOGOUT_SUCCESS,
      payload: null,
    });
  } catch (error) {
    console.log(error);
    dispatch({
      type: LOGOUT_FAIL,
      payload: error.response,
    });
  }
};

// Clear Errors
export const clearErrors = () => async (dispatch) => {
  dispatch({ type: CLEAR_ERRORS });
};
