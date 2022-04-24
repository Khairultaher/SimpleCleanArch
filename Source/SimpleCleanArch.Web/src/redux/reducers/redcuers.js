import { combineReducers } from "redux";

import {
  allForcastReducer,
  addForcastReducer,
  editForcastReducer,
  deleteForcastReducer,
} from "./weatherForcastreducers";

import { authReducer } from "./authReducers";

const reducer = combineReducers({
  allForcast: allForcastReducer,
  addForcast: addForcastReducer,
  editForcast: editForcastReducer,
  deleteForcast: deleteForcastReducer,
  auth: authReducer,
});

export default reducer;
