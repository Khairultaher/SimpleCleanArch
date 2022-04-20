import { createStore, applyMiddleware } from "redux";
import { HYDRATE, createWrapper } from "next-redux-wrapper";
import thunk from "redux-thunk";
import { composeWithDevTools } from "redux-devtools-extension";

import reducers from "./reducers/redcuers";

const middlware = [thunk];
const store = createStore(
  reducers,
  composeWithDevTools(applyMiddleware(...middlware))
);

export default store;

// const bindMiddlware = (middlware) => {
//   if (process.env.NODE_ENV !== "production") {
//     const { composeWithDevTools } = require("redux-devtools-extension");
//     return composeWithDevTools(applyMiddleware(...middlware));
//   }

//   return applyMiddleware(...middlware);
// };

// const reducer = (state, action) => {
//   if (action.type === HYDRATE) {
//     const nextState = {
//       ...state,
//       ...action.payload,
//     };
//     return nextState;
//   } else {
//     return reducers(state, action);
//   }
// };

// const initStore = () => {
//   return createStore(reducer, bindMiddlware([thunkMiddleware]));
// };

// export const wrapper = createWrapper(initStore);
