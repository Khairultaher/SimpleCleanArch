import {
  GET_ALL_FORCAST_REQUEST,
  GET_ALL_FORCAST_SUCCESS,
  GET_ALL_FORCAST_FAIL,
  ADD_FORCAST_REQUEST,
  ADD_FORCAST_SUCCESS,
  ADD_FORCAST_RESET,
  ADD_FORCAST_FAIL,
  EDIT_FORCAST_REQUEST,
  EDIT_FORCAST_SUCCESS,
  EDIT_FORCAST_FAIL,
  DELETE_FORCAST_REQUEST,
  DELETE_FORCAST_SUCCESS,
  DELETE_FORCAST_FAIL,
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

    case GET_ALL_FORCAST_SUCCESS:
      return {
        totalCount: action.payload.totalCount,
        totalPages: action.payload.totalPages,
        forecasts: action.payload.items,
        loading: false,
      };

    case GET_ALL_FORCAST_FAIL:
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

export const addForcastReducer = (state = { forecast: {} }, action) => {
  switch (action.type) {
    case ADD_FORCAST_REQUEST:
      return {
        ...state,
        loading: true,
      };

    case ADD_FORCAST_SUCCESS:
      return {
        loading: false,
        success: true,
        id: action.payload,
      };
    case ADD_FORCAST_RESET:
      return {
        ...state,
        success: false,
      };
    case ADD_FORCAST_FAIL:
      return {
        ...state,
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

export const editForcastReducer = (state = { forecast: {} }, action) => {
  switch (action.type) {
    case EDIT_FORCAST_REQUEST:
      return {
        ...state,
        loading: true,
      };

    case EDIT_FORCAST_SUCCESS:
      return {
        loading: false,
        success: action.payload.message,
      };

    case EDIT_FORCAST_FAIL:
      return {
        ...state,
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

export const deleteForcastReducer = (state = { forecast: {} }, action) => {
  switch (action.type) {
    case DELETE_FORCAST_REQUEST:
      return {
        ...state,
        loading: true,
      };

    case DELETE_FORCAST_SUCCESS:
      return {
        loading: false,
        success: action.payload.message,
      };

    case DELETE_FORCAST_FAIL:
      return {
        ...state,
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
