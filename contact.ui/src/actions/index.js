import contactApi from '../api';
import {  FETCH_CONTACTS, EDIT_CONTACT, CREATE_CONTACT, DELETE_CONTACT,
    SHOW_MESSAGE,ADD_MODAL_IS_VISIBLE, EDIT_MODAL_IS_VISIBLE } from './type';
    import {SUCCESS_MESSAGE, ERROR_MESSAGE, INFO_MESSAGE} from '../util/alert';




export const fetchContacts = () => async dispatch => {

    const response = await contactApi.get("api/contacts");

    dispatch({ type: FETCH_CONTACTS,  payload: response.data.data});

};


export const openEditModal = (id) => async dispatch =>{

    let response = {};

    try{
    
        response = await contactApi.get(`api/contacts/${id}`)
      
        dispatch({type: EDIT_CONTACT, payload: response.data });

        dispatch({type: EDIT_MODAL_IS_VISIBLE, payload:{id, visible: true } });

    }
    catch(err){

        console.log(err);
        dispatch({ type: SHOW_MESSAGE,  payload: response.data});
        
    }

}



export const openAddModal = () => async dispatch =>{

    dispatch({type: ADD_MODAL_IS_VISIBLE, payload: true});
}

export const closeModal = () => async dispatch => {

    console.log('here');

    dispatch({type: ADD_MODAL_IS_VISIBLE, payload: false});

    dispatch({type: EDIT_MODAL_IS_VISIBLE, payload:{id:null, visible: false } });


}


export const createContact = formValues => async dispatch => {

    let response = {};

    try
    {

       response = await contactApi.post("api/contacts",{...formValues});

      
       dispatch({ type: CREATE_CONTACT,  payload: response.data.data});

       dispatch({type: ADD_MODAL_IS_VISIBLE, payload: false});

       dispatch({type: SHOW_MESSAGE, payload: {showMessage: true, message: "Contact added successfully", type: SUCCESS_MESSAGE} });
       


    }
    catch(err)
    {

     
       dispatch({type: SHOW_MESSAGE, payload: {showMessage: true, message: err.response.data.message, type: ERROR_MESSAGE} });

    }

   
  
};

export const editContact = (id,formValues) => async dispatch => {

    let response;
    try{

         response = await contactApi.put(`api/contacts/${id}`,formValues);

        dispatch({ type: EDIT_CONTACT, payload: response.data});

        dispatch({type: EDIT_MODAL_IS_VISIBLE, payload: false});

        dispatch({type: SHOW_MESSAGE, payload: {showMessage: true, message: "Contact updated successfully", type: SUCCESS_MESSAGE} });

    }
    catch(err){

        dispatch({type: SHOW_MESSAGE, payload: {showMessage: true, message: err.response.data.message, type: ERROR_MESSAGE} });

    }
}

export const deleteContact = id => async dispatch => {

    let response = {};

    try
    {
         response = await contactApi.delete(`api/contacts/${id}`);

        dispatch({ type: DELETE_CONTACT, payload: id});

        dispatch({type: SHOW_MESSAGE, payload: {showMessage: true, message: "Contact deleted successfully", type: SUCCESS_MESSAGE} });
    }
    catch(err)
    {
        console.log(err);

        console.log(response);

        dispatch({type: SHOW_MESSAGE, payload: {showMessage: true, message: response.data.message, type: ERROR_MESSAGE} });
    }

};

