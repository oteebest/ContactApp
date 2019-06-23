import React from 'react';
import { Field, reduxForm } from 'redux-form';
import '../../css/special.css'
import {closeModal} from '../../actions';
import PopUpModalFooter from '../PopUpModalFooter';

class ContactForm extends React.Component{


   
    onSubmit = formValues => {
      
        this.props.onSubmit(formValues);
     
     };

      
     
    

      renderError({ error, touched }) {
        if (touched && error) {
          return (
            <div className="ui error message">
              <div className="header">{error}</div>
            </div>
          );
        }
      }
    
      renderId(id){

        if(id != null){
          return (<input type='hidden' value={id}></input>);
        }
        else{

          return (<React.Fragment></React.Fragment>)
        }
        

      }

        renderField = (field) => { 
          
      
          return(<div className="form-group">
        <label  className="col-form-label">{field.label}</label>
        <input {...field.input }  type="text" className="form-control" />
        {this.renderError(field.meta)}
        </div> )
        
    };
 

    render(){

      console.log( this.props.editContactInfo );

        return (
         
          <form
            onSubmit={this.props.handleSubmit(this.onSubmit)}
            className="ui form error"
          >
          <React.Fragment>
      <div className="modal-body">
      
      {this.renderId(this.props.id)}
      
       <Field name="firstName"    label="Enter first name" component={this.renderField}  />

       <Field name="lastName"   label="Enter last name" component={this.renderField}  />

             <Field name="email"  component={this.renderField} label="Enter email" />
            <Field
              name="mobile"
              component={this.renderField}
              label="Enter mobile number"
            />
            
         
      </div>
    
    <div className="modal-footer">
        <button className="btn btn-secondary" onClick={this.props.closePopUp} >Close</button>
       
         <button className="btn btn-primary">Save changes</button>
     </div>
     </React.Fragment>
      </form>);
    }
}


const validate = formValues => {
    const errors = {};
  
    if (!formValues.title) {
      errors.title = 'You must enter a title';
    }
  
    if (!formValues.description) {
      errors.description = 'You must enter a description';
    }
  
    return errors;
  };

  
  export default reduxForm({
    form: 'contactForm',
    validate
  })(ContactForm);