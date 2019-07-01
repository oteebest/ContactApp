import _ from 'lodash';
import { SHOW_MESSAGE } from '../actions/type'


export default (state = {showMessage: false, message: ""} ,action) => {

    switch (action.type){

    case SHOW_MESSAGE: 
    state = {...state, ...{ showMessage: true, message: action.payload.data.message } };
    return state;
    default:
    return state;

    }

    

}
