import axios from "axios";
import config from "../../config.json";

import {
  GET_ALL_FORCAST_REQUEST,
  GET_ALL_FORCAST_SUCCESS,
  GET_ALL_FORCAST_FAIL,
  ADD_FORCAST_REQUEST,
  ADD_FORCAST_SUCCESS,
  ADD_FORCAST_FAIL,
  EDIT_FORCAST_REQUEST,
  EDIT_FORCAST_SUCCESS,
  EDIT_FORCAST_FAIL,
  DELETE_FORCAST_REQUEST,
  DELETE_FORCAST_SUCCESS,
  DELETE_FORCAST_FAIL,
  CLEAR_ERRORS,
} from "../constants/weatherForcastConstants";

// Get all forecast
export const getAllForcast =
  (pageNumber = 1, pageSize = 10) =>
  async (dispatch) => {
    let link = `${config.API_BASE_URL}/api/weatherforecast?pageNumber=${pageNumber}&pageSize=${pageSize}`;
    console.log(`getAllForcast: ${link}`);
    try {
      dispatch({ type: GET_ALL_FORCAST_REQUEST });

      const { data } = await axios.get(link);

      dispatch({
        type: GET_ALL_FORCAST_SUCCESS,
        payload: data,
      });
    } catch (error) {
      console.log(error);
      dispatch({
        type: GET_ALL_FORCAST_FAIL,
        payload: error.response.data.message,
      });
    }
  };

// add forecast
export const addForcast = (forecast) => async (dispatch) => {
  let link = `${config.API_BASE_URL}/api/weatherforecast`;
  try {
    dispatch({ type: ADD_FORCAST_REQUEST });

    const config = {
      headers: {
        "Content-Type": "application/json",
      },
    };

    const { data } = await axios.post(link, forecast, config);
    console.log(data);
    dispatch({
      type: ADD_FORCAST_SUCCESS,
      payload: data,
    });
  } catch (error) {
    console.log(error);
    dispatch({
      type: ADD_FORCAST_FAIL,
      payload: error.response.data.message,
    });
  }
};

// add forecast
export const editForcast = (forecast) => async (dispatch) => {
  let link = `${config.API_BASE_URL}/api/weatherforecast`;
  try {
    dispatch({ type: EDIT_FORCAST_REQUEST });

    const config = {
      headers: {
        "Content-Type": "application/json",
      },
    };

    const { data } = await axios.put(link, forecast, config);
    console.log(data);
    dispatch({
      type: EDIT_FORCAST_SUCCESS,
      payload: data,
    });
  } catch (error) {
    console.log(error);
    dispatch({
      type: EDIT_FORCAST_FAIL,
      payload: error.response,
    });
  }
};
export const deleteForcast = (id) => async (dispatch) => {
  let link = `${config.API_BASE_URL}/api/weatherforecast?id=${id}`;
  try {
    dispatch({ type: DELETE_FORCAST_REQUEST });

    const config = {
      headers: {
        "Content-Type": "application/json",
      },
    };

    const { data } = await axios.delete(link, config);

    dispatch({
      type: DELETE_FORCAST_SUCCESS,
      payload: data,
    });
  } catch (error) {
    console.log(error);
    dispatch({
      type: DELETE_FORCAST_FAIL,
      payload: error.response,
    });
  }
};
// Clear Errors
export const clearErrors = () => async (dispatch) => {
  dispatch({ type: CLEAR_ERRORS });
};
