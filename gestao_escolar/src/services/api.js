import axios from "axios";

const api = axios.create({
    baseURL : 'hht'
},);

export default api;