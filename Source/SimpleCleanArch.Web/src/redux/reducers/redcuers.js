import { combineReducers } from "redux";

import { allForcastReducer } from "./weatherForcastreducers";

const reducer = combineReducers({
  allForcast: allForcastReducer,
});

export default reducer;
