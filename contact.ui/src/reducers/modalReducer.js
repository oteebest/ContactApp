import {ADD_MODAL_IS_VISIBLE, EDIT_MODAL_IS_VISIBLE} from '../actions/type'
 
export default (state = {showAddModal:false, showEditModal: {id: null, visible: false } }, action) => {

    switch(action.type){
    case ADD_MODAL_IS_VISIBLE:
     return {...state, showAddModal: action.payload};
    case EDIT_MODAL_IS_VISIBLE:
     return {...state, showEditModal: action.payload}
    default:
    return state;
    }
}