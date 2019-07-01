import {  FETCH_CONTACTS, EDIT_CONTACT,
     CREATE_CONTACT, DELETE_CONTACT } from '../actions/type';
import _ from 'lodash';


export default (state= { }, action ) => {

    switch(action.type){

        case FETCH_CONTACTS:        
        return FetchContacts(state,action.payload);
        case CREATE_CONTACT:      
        return AddContact(state,action.payload );
        case DELETE_CONTACT:      
        return DeleteContact(state,action.payload );
        case EDIT_CONTACT:      
        return EditContact(state,action.payload );
        default:
        return state;


    }
}

function FetchContacts(originalContactList,payload){

 
    const payloadInfo = { pageSize: payload.pageSize, pageNumber: payload.pageNumber, totalItems: payload.totalItems, items: _.mapKeys(payload.items, 'id')};

    return { ...originalContactList, ...payloadInfo   } ;


}

function AddContact(originalContactList, payload){
   const newContact = { [payload.id]: payload };

   originalContactList.items = { ...originalContactList.items, ...newContact };

   const newContactList = {...originalContactList};

   return newContactList;
}

function DeleteContact(originalContactList, payload){

    originalContactList.items = _.omit(originalContactList.items,[payload])


    return {...originalContactList};
}

function EditContact(originalContactList, payload){

    console.log(payload);

    originalContactList.items = {...originalContactList.items, [payload.data.id]: payload.data}


    return {...originalContactList};
}