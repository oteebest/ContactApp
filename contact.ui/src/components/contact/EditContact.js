import React from 'react';
import {connect} from 'react-redux';
import ContactForm from './ContactForm';
import PopUpModal from '../PopUpModal';
import {editContact,closeModal,fetchContacts} from '../../actions';

class EditContact extends React.Component{

    componentDidMount()
    {

    }

    onSubmit = (formvalues) => {

        const id = formvalues.id;
        
        this.props.editContact(id,formvalues);

    };

    onClose = (e) => {

        e.preventDefault();
        this.props.closeModal();
    }

    render(){
        return ( <React.Fragment>
            <PopUpModal isOpen={this.props.showEditModal.visible} closePopUp={this.onClose}  headerText="Edit Contact">
            <ContactForm id={this.props.showEditModal.id} initialValues={this.props.contact} closePopUp={this.onClose}  onSubmit={this.onSubmit} />
            </PopUpModal>
            </React.Fragment>);
    }

}


const mapStateToProp = (state) => {

    console.log(state);
   
    let contact;

    if(state.contacts.items){
        contact =  state.contacts.items[state.modals.showEditModal.id]
    }
  

   return {
        showEditModal: state.modals.showEditModal,
        contact: contact
   }
}

export default connect(mapStateToProp,{editContact,closeModal})(EditContact);
