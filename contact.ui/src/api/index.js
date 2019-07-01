import axios from 'axios';

export default axios.create({

    baseURL: "https://localhost:5001", 
    
    headers: {'content-type': 'application/json', "Access-Control-Allow-Origin": "*"}

    

});