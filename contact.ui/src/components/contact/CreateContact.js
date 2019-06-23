import React from 'react';
import {connect} from  'react-redux';
import ContactForm from './ContactForm';
import {createContact,closeModal} from '../../actions'
import PopUpModal from '../PopUpModal';
import Modal from '../Modal';
import {Link} from 'react-router-dom'
import history from '../../history';
import PageHeader from '../PageHeader';
import SecureLayout from '../SecureLayout';

class CreateContact extends React.Component{

    componentDidMount(){

       
    }

    componentDidUpdate(){
       
    }

    onSubmit = formvalues => {

        this.props.createContact(formvalues);
    };

    onClose = (e) => {
        
        e.preventDefault();
        this.props.closeModal();
    }

   

    render(){

        return ( <React.Fragment>
            <PopUpModal isOpen={this.props.showAddModal}  closePopUp={this.onClose} headerText="Create Contact">
            <ContactForm  onSubmit={this.onSubmit} closePopUp={this.onClose} />
            </PopUpModal>
            </React.Fragment>);
    }
}

const mapStateToProps = state => {
 
    return {
      showAddModal: state.modals.showAddModal
    };
};

export default connect(
    mapStateToProps,
    { createContact,closeModal }
  )(CreateContact);