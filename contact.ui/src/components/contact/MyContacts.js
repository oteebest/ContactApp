import React from 'react';
import PageHeader from '../PageHeader';
import SecureLayout from '../SecureLayout';
import { connect } from 'react-redux';
import { fetchContacts,createContact,deleteContact,openAddModal, openEditModal } from '../../actions/index';
import CreateContact from './CreateContact';
import EditContact from './EditContact';
import {Link} from 'react-router-dom';
import {SuccessAlert} from '../../util/alert';


class MyContacts extends React.Component{

 
    componentDidMount(){
        
        this.props.fetchContacts();
    }

 
    componentDidUpdate(){
    
        console.log(this.state);
    }




    onSubmit = formValues => {

        this.props.createContact(formValues);
    };

    openAddModal = () => {

        this.props.openAddModal();
    }

    openEditModal = (id) => {
       

        this.props.openEditModal(id);

    }

    deleteContact = (id) => {

        if( window.confirm("Are you sure you want to delete this entry?") ){

        this.props.deleteContact(id);

     }
      
    }
    
 

    renderContactlist()
    {
         
        if(this.props.contacts.items != null)
        {
           
            const items = Object.values(this.props.contacts.items).sort( function (a,b) { return new Date(b.dateCreated) - new Date(a.dateCreated) }  );
   
            return items.map( u => {
                return( <tr key={u.id}>
                   <td>{u.firstName}</td>
                   <td>{u.lastName}</td>
                   <td>{u.email}</td>
                   <td>{u.mobile}</td>
                   <td>{u.dateCreated}</td>
                   <td><button  className="btn btn-primary btn-xs" onClick={() => this.openEditModal(u.id)} >Edit</button></td>
                   <td><button onClick={() => this.deleteContact(u.id)} className="btn btn-danger btn-xs" >Delete</button></td>
               </tr>)
              }
              );
        }

    }


    renderContacts(){
        
     
        return (<div className="row">       
        <div className="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
            <div className="card">
                <div className="card-header">

                <input type="text"  className="float-left" ></input>

                <CreateContact showAddModal={this.props.modals.showAddModal}  onSubmit={this.onSubmit} />

                <EditContact showEditModal={this.props.modals.showEditModal}  />

                <SuccessAlert ></SuccessAlert>
                <button  className="btn btn-primary btn-sm float-right" onClick={this.openAddModal}    id="btnCreate">Create Contact</button>

                <button  className="btn btn-primary btn-sm float-right" style={{marginRight:10}} id="importContact">Import Contact</button>

                </div>
                <div className="card-body">
                    <div className="table-responsive">
                        <table className="table table-striped table-bordered first">
                            <thead>
                                <tr>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Email</th>
                                    <th>Mobile</th>
                                    <th>Date Created</th>
                                    <th></th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tbody>
                              {this.renderContactlist()}
                               
                            </tbody>
                        </table>
                                </div>
                                </div>
                                </div>
                                </div>
                                </div>);
                                
                                

    }
   
    

    render(){

        return(<SecureLayout> <div className="container-fluid dashboard-content">
       <PageHeader HeaderText="My Contacts" />     
        {this.renderContacts()}
    </div>
    </SecureLayout>);
        
    }

}



const mapStateToProps = state => {

    console.log(state);
   
  
    return {
      contacts: state.contacts,
      modals: state.modals
    };
  };
  
  export default connect(
    mapStateToProps,
    { fetchContacts,createContact,deleteContact,openAddModal,openEditModal }
  )(MyContacts);
