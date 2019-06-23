import React from 'react';
import { Router, Route, Switch } from 'react-router-dom';
import history from '../history';
import Dashboard from './Dashboard';
import MyContacts from './contact/MyContacts';
import MyEvents from './event/MyEvents';
import Login from './insecure/login';
import ForgotPassword from './insecure/forgotpassword';
import Register from './insecure/register';
import Notfound from './Notfound';
import CreateContact from './contact/CreateContact';

class App extends  React.Component{





  renderPage(){

   if( this.props.isSignedIn != null) {

     return ( 
     <Router history={history}>
     
    
        <Switch>
         <Route path="/insecure/login" exact  component={Login} />
         <Route path="/insecure/forgotpwd" exact  component={ForgotPassword} />
         <Route path="/insecure/register" exact  component={Register} />
         <Route path="*" exact  component={Notfound} />
        </Switch>      
    
     </Router>);

   }
   else{
     return(

    <Router history={history}>

   

        <Switch>
            <Dashboard exact path="/" />
            <Route path="/mycontacts" exact  component={MyContacts} />       
            <Route path="/myevents" exact  component={MyEvents} />
            <Route path="*" exact  component={Notfound} />
       </Switch>
  

      


    </Router>);

   }

  }

    render(){
        
      return this.renderPage();


    }

}

export default App;