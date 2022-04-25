import axios from 'axios';

export const client = axios.create({baseURL:"https://localhost:7225/v1"})
