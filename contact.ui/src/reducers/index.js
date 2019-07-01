import { combineReducers } from 'redux';
import contactReducer from './contactReducers';
import modalReducer from './modalReducer';
import alertReducer from './alertReducers';

import { reducer as formReducer } from 'redux-form';

export default combineReducers({
  contacts: contactReducer,
  modals: modalReducer,
  alerts: alertReducer,
  form: formReducer
});