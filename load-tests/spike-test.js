import http from 'k6/http';
import { sleep, check } from 'k6';

const API_BASE_URL = 'http://79.76.48.213:5000/api';

export const options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '10s', target: 50 },  // scale up 
        { duration: '30s', target: 50 },  // hold 
        { duration: '10s', target: 200 },  // spike up
        { duration: '1m', target: 200 },   // hold 
        { duration: '10s', target: 50 },   // scale down
        { duration: '30s', target: 50 },   // hold
        { duration: '10s', target: 0 },    // fade out
    ],
};

export default () => {
    
    let responses = http.batch([
        ['GET', `${API_BASE_URL}/simple/add?a=10&b=5`],
        ['GET', `${API_BASE_URL}/simple/subtract?a=10&b=5`],
        ['GET', `${API_BASE_URL}/simple/multiply?a=10&b=5`],
        ['GET', `${API_BASE_URL}/simple/divide?a=10&b=5`],
        ['GET', `${API_BASE_URL}/simple/factorial?a=10`],
        ['GET', `${API_BASE_URL}/simple/prime?a=10`],
        ['GET', `${API_BASE_URL}/cached/add?a=10&b=5`],
        ['GET', `${API_BASE_URL}/cached/subtract?a=10&b=5`],
        ['GET', `${API_BASE_URL}/cached/multiply?a=10&b=5`],
        ['GET', `${API_BASE_URL}/cached/divide?a=10&b=5`],
        ['GET', `${API_BASE_URL}/cached/factorial?a=10`],
        ['GET', `${API_BASE_URL}/cached/prime?a=10`]
    ]);
    
    sleep(1);
};