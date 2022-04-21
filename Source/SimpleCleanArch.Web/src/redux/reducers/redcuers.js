import { combineReducers } from "redux";

import {
  allForcastReducer,
  addForcastReducer,
  editForcastReducer,
  deleteForcastReducer,
} from "./weatherForcastreducers";

const reducer = combineReducers({
  allForcast: allForcastReducer,
  addForcast: addForcastReducer,
  editForcast: editForcastReducer,
  deleteForcast: deleteForcastReducer,
});

export default reducer;
