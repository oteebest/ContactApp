import React from 'react';
import  '../css/special.css'


class InSecureLayout extends React.Component{


    componentDidMount(){

        const body = styles.bodyCSS;

        for (const key in body) {
            if (body.hasOwnProperty(key)) {

                document.body.style[key] = body[key];

            }
        }

        const bodyAndHtml = styles.bodyAndHtmlCSS;

        for(const key in bodyAndHtml){

            if(bodyAndHtml.hasOwnProperty(key)){

                document.body.style[key] = bodyAndHtml[key];

                document.documentElement.style[key] = bodyAndHtml[key];


            }
        }

        const rootCSS = styles.rootCSS;

        for(const key in rootCSS){

            if(rootCSS.hasOwnProperty(key)){

                document.querySelector("#root").className = rootCSS[key];


            }
        }
        
    };

    componentWillUnmount(){

     
        const body = styles.bodyCSS;

        for (var key in body) {
            if (body.hasOwnProperty(key)) {

                document.body.style[key] = null;

            }
        }

        const bodyAndHtml = styles.bodyAndHtmlCSS;

        for(const key in bodyAndHtml){

            if(bodyAndHtml.hasOwnProperty(key)){

                document.body.style[key] = null;

                document.documentElement.style[key] = null;


            }
        }

        const rootCSS = styles.rootCSS;

        for(const key in rootCSS){

            if(rootCSS.hasOwnProperty(key)){

                document.querySelector("#root").className = null;


            }
        }



    }
  

render(){

    return (
    <div className="card ">
        <div className="card-header text-center"><button className="link-button"><img className="logo-img" src="../assets/images/logo.png" alt="logo" /></button><span className="splash-description">Please enter your user information.</span></div>
        {this.props.children}

    </div>
)

}

}

const  styles = {
    bodyCSS: {
       
        display: '-ms-flexbox',
      
        "MsFlexAlign": 'center',
        alignItems: 'center',
        paddingTop: '40px',
        paddingBottom: '40px',
    },

    bodyAndHtmlCSS: {
        height: '100%'
    },

    rootCSS: {

        className: "splash-container"

    }
} 



export default InSecureLayout;