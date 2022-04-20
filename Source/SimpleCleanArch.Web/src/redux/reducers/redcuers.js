import { combineReducers } from "redux";

import { allForcastReducer, addForcastReducer } from "./weatherForcastreducers";

const reducer = combineReducers({
  allForcast: allForcastReducer,
  addForcast: addForcastReducer,
});

export default reducer;
