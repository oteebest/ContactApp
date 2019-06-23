import React from 'react';
import  '../css/special.css'
import { Button, Modal, ModalHeader } from 'reactstrap';
import {connect} from 'react-redux';
import {closeModal } from '../actions/index';

class PopUpModaal extends React.Component{
    
    

    componentDidMount(){
       
    }

    componentDidUpdate(){
       
        
    }

    

    
    render(){

      
        return(  <Modal isOpen={this.props.isOpen}  className={this.props.className}>
            <ModalHeader  toggle={this.props.closePopUp} >Modal title</ModalHeader>

            {this.props.children}

          </Modal>);

        /* let modalClass;
        let modalStyle;
        if(this.props.open) {
          
            modalClass = "modal show";
            modalStyle = {display: 'block'}
        }
        else{
            modalClass = "modal fade";
            modalStyle = {display: 'none'}
        }

        return (<div className={modalClass} style={modalStyle} id="exampleModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div className="modal-dialog" role="document">
       
            <div className="modal-content">
            <div className="modal-header">
          <h5 className="modal-title" id="exampleModalLabel">{this.props.headerText}</h5>
       
           <button className="close" data-dismiss="modal" aria-label="Close" ><span aria-hidden="true">&times;</span></button>
      </div>
               {this.props.children}

               
            </div>
        </div>
    </div>); */
    }
}

const mapStateToProps = state => {
    
    return {
    modal : state.modals

    };
  
}

export default connect(mapStateToProps,{closeModal})(PopUpModaal);
