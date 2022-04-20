import axios from "axios";
import config from "../../config.json";

import {
  GET_ALL_FORCAST_REQUEST,
  GET_ALL_FORCAST_SUCCEED,
  GET_ALL_FORCAST_FAILED,
  CLEAR_ERRORS,
} from "../constants/weatherForcastConstants";

// Get all rooms
export const getAllForcast =
  (skip = 1, take = 10) =>
  async (dispatch) => {
    try {
      const baseUrl = config.API_BASE_URL;
      console.log(baseUrl);
      let link = `${baseUrl}/api/weatherforecast?skip=${skip}&take=${take}`;
      console.log(link);

      const { data } = await axios.get(link);
      console.log(link);

      dispatch({
        type: GET_ALL_FORCAST_SUCCEED,
        payload: data,
      });
    } catch (error) {
      console.log(error);
      dispatch({
        type: GET_ALL_FORCAST_FAILED,
        payload: error.response.data.message,
      });
    }
  };

// Clear Errors
export const clearErrors = () => async (dispatch) => {
  dispatch({
    type: CLEAR_ERRORS,
  });
};
