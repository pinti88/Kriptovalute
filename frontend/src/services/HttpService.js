import axios from "axios";
import { BACKEND_URL } from "../constants";

export const httpService = axios.create({
    baseURL : BACKEND_URL,
headerseaders: {
    'Content-Type': 'application/json'
}
})