import React from 'react';

class PopUpModalFooter extends React.Component{


    render(){
        return (  <div className="modal-footer">
        <button className="btn btn-secondary" onClick={(e) => this.close(e)} >Close</button>
       
         <button className="btn btn-primary">Save changes</button>
     </div>)
    }
}

export default PopUpModalFooter;