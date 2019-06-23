import React from 'react';
import { Link } from 'react-router-dom';
import InSecureLayout from '../InSecureLayout';

class ForgotPassword extends React.Component{


    render(){

        return (
        <InSecureLayout>
        <React.Fragment>
        <div className="card-body">
        <form>
            <div className="form-group">
                <input className="form-control form-control-lg" id="username" type="text" placeholder="Enter your email" autoComplete="off" />
            </div>           
            <button type="submit" className="btn btn-primary btn-lg btn-block" href="../index-2.html">Submit</button>
        </form>
    </div>
    <div className="card-footer bg-white p-0  ">
        <div className="card-footer-item card-footer-item-bordered">
        <Link className="footer-link" to="/insecure/register" >Create An Account</Link></div>
        <div className="card-footer-item card-footer-item-bordered">          
            <Link className="footer-link" to="/insecure/login" >Login Password</Link>
        </div>
    </div>
    </React.Fragment>
    </InSecureLayout>);

    }
}

export default ForgotPassword;