import { combineReducers } from 'redux';
import contactReducer from './contactReducers';
import modalReducer from './modalReducer';

import { reducer as formReducer } from 'redux-form';

export default combineReducers({
  contacts: contactReducer,
  modals: modalReducer,
  form: formReducer
});