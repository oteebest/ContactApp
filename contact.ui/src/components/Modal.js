import React from 'react';
import ReactDOM from 'react-dom';

const Modal = props => {
  return ReactDOM.createPortal(
  
    <div className="modal"  style={{display: 'block'}} id="exampleModal" tabIndex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div className="modal-dialog" role="document">
       
            <div className="modal-content">
            <div className="modal-header">
          <h5 className="modal-title" id="exampleModalLabel">{props.headerText}</h5>
       
           <button className="close" onClick={props.onDismiss} aria-label="Close" ><span aria-hidden="true">&times;</span></button>
      </div>
               {props.children}

               
            </div>
        </div>
    </div>

  /*   <div onClick={props.onDismiss} className="ui dimmer modals visible active" >
      <div
        onClick={e => e.stopPropagation()}
        className="ui standard modal visible active"
      >
        <div className="header">{props.title}</div>
        <div className="content">{props.content}</div>
        <div className="actions">{props.actions}</div>
      </div>
    </div> */ ,
    document.querySelector('#modal')
  );
};

export default Modal;