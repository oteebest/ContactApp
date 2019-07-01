import _ from 'lodash';
import { SHOW_MESSAGE } from '../actions/type'


export default (state = {showMessage: false, message: "", type: null} ,action) => {

    switch (action.type){

    case SHOW_MESSAGE: 
    state = {...state, ...action.payload  };
    return state;
    default:
    state = {showMessage: false, message: "", type: null} 
    return state;

    }

    

}
