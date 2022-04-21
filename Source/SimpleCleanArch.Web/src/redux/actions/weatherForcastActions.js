import axios from "axios";
import config from "../../config.json";

import {
  GET_ALL_FORCAST_REQUEST,
  GET_ALL_FORCAST_SUCCESS,
  GET_ALL_FORCAST_FAIL,
  ADD_FORCAST_REQUEST,
  ADD_FORCAST_SUCCESS,
  CLEAR_ERRORS,
} from "../constants/weatherForcastConstants";

// Get all forecast
export const getAllForcast =
  (pageNumber = 1, pageSize = 10) =>
  async (dispatch) => {
    try {
      dispatch({ type: GET_ALL_FORCAST_REQUEST });

      let link = `${config.API_BASE_URL}/api/weatherforecast/GetWeatherForecast?pageNumber=${pageNumber}&pageSize=${pageSize}`;

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

// Get all forecast
export const addForcast = (forecast) => async (dispatch) => {
  try {
    dispatch({ type: ADD_FORCAST_REQUEST });

    const config = {
      headers: {
        "Content-Type": "application/json",
      },
    };
    let link = `${config.API_BASE_URL}/api/weatherforecast/add`;
    const { data } = await axios.post(link, forecast, config);
    console.log(data);

    dispatch({
      type: ADD_FORCAST_SUCCESS,
      payload: data.success,
    });
  } catch (error) {
    console.log(error);
    dispatch({
      type: GET_ALL_FORCAST_FAIL,
      payload: error.response.data.message,
    });
  }
};

// Clear Errors
export const clearErrors = () => async (dispatch) => {
  dispatch({ type: CLEAR_ERRORS });
};
