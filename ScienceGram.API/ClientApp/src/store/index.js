import { createStore, combineReducers } from "@reduxjs/toolkit";
import { user } from "./userReducer";

const rootReducer = combineReducers({
	user,
});

const store = createStore(rootReducer);

export default store;
