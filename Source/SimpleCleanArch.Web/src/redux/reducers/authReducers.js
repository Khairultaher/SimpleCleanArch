import {
  LOGIN_REQUEST,
  LOGIN_REFRESH,
  LOGIN_SUCCESS,
  LOGIN_FAIL,
  LOGOUT_REQUEST,
  LOGOUT_SUCCESS,
  LOGOUT_FAIL,
  CLEAR_ERRORS,
} from "../constants/authConstants";

export const authReducer = (state = { user: {} }, action) => {
  switch (action.type) {
    case LOGIN_REQUEST:
      return {
        ...state,
        isAuthenticated: false,
        user: null,
        token: null,
        roles: null,
        loading: true,
      };
    case LOGIN_REFRESH:
      return {
        ...state,
        isAuthenticated: true,
        loading: true,
      };
    case LOGIN_SUCCESS:
      return {
        ...state,
        isAuthenticated: true,
        user: action.payload.userName,
        token: action.payload.token,
        roles: action.payload.roles,
        loading: false,
      };
    case LOGIN_FAIL:
      return {
        ...state,
        isAuthenticated: false,
        user: null,
        token: null,
        roles: null,
        loading: false,
      };
    case LOGOUT_REQUEST:
      return {
        ...state,
        loading: true,
      };
    case LOGOUT_SUCCESS:
      return {
        ...state,
        loading: false,
        isAuthenticated: false,
        user: null,
        token: null,
        roles: null,
      };
    case LOGOUT_FAIL:
      return {
        ...state,
        loading: false,
      };
    case CLEAR_ERRORS:
      return {
        ...state,
        loading: false,
        error: null,
      };
    default:
      return {
        ...state,
        loading: false,
        isAuthenticated: false,
        user: null,
        token: null,
        roles: null,
        error: null,
      };
  }
};
