import {
  GET_ALL_FORCAST_REQUEST,
  GET_ALL_FORCAST_SUCCEED,
  GET_ALL_FORCAST_FAILED,
  CLEAR_ERRORS,
} from "../constants/weatherForcastConstants";

// All forcasat reducer
export const allForcastReducer = (state = { forecasts: [] }, action) => {
  switch (action.type) {
    case GET_ALL_FORCAST_REQUEST:
      return {
        forecasts: [],
        loading: true,
      };

    case GET_ALL_FORCAST_SUCCEED:
      return {
        count: action.payload.count,
        forecasts: action.payload.data,
        loading: false,
      };

    case GET_ALL_FORCAST_FAILED:
      return {
        error: action.payload.message,
      };

    case CLEAR_ERRORS:
      return {
        ...state,
        error: null,
      };

    default:
      return state;
  }
};
