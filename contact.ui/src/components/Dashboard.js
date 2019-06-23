import React from 'react';
import PageHeader from './PageHeader';
import SecureLayout from './SecureLayout';
import { connect } from 'react-redux';

class Dashboard extends React.Component{


    render(){

       
        return(<SecureLayout> <div className="container-fluid dashboard-content">
       <PageHeader HeaderText="Dashboard" />
        <div className="row">
            <div className="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-12">
                <h3 className="text-center">Content goes here!</h3>
            </div>
        </div>
    </div>
    </SecureLayout>);
        
    }

}

const mapStateToProps = state => {
     console.log(state);
    return {
      showAddModal: state.contacts.showAddModal
    };
};

export default connect(
    mapStateToProps,
    null
  )(Dashboard);