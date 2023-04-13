import axios from 'axios';
import React, { useState } from 'react'


interface IUser{name: string; job: string}
interface IUserSecond{email: string, password?: string}


export function Program() {

    const user1: IUser = {name: 'morpheus', job: 'zion resident'}
    const user2: IUser = {name: 'morpheus', job: 'leader'}
    const user3: IUserSecond = {email: 'eve.holt@reqres.in', password: 'pistol'}
    const user4: IUserSecond = {email: 'syndey@fife'}
    const user5: IUserSecond = {email: 'eve.holt@reqres.in', password: 'cityslicka'}
    const user6: IUserSecond = {email: 'peter@klaven'}


// eslint-disable-next-line
    const [resultResponse, setResultResponse] = useState<any>();
    const [resultRequest, setResultRequest] = useState<string>();
    const [requestUrl, setRequestUrl] = useState<string>();
    const [statusCode, setStatusCode] = useState<number>();

    const get = async (path: string) => {
    setRequestUrl(path);
    const url = 'https://reqres.in/api' + path;
    const response = await axios.get(url);
    setStatusCode(response.status);
    setResultResponse(JSON.stringify(response.data, null, 2));
    }

        const post = async (path: string, body: object) => {
        setRequestUrl(path);
        const url = 'https://reqres.in/api' + path;
        const response = await axios.post(url, body);
        setStatusCode(response.status);
        setResultRequest(JSON.stringify(response.data, null, 2)); 
        }

            const put = async (path: string, body: object) => {
            setRequestUrl(path);
            const url = 'https://reqres.in/api' + path;
            const response = await axios.put(url, body);
            setStatusCode(response.status);
            setResultResponse(JSON.stringify(response.data, null, 2)); 
            }

                const patch = async (path: string, body: object) => {
                setRequestUrl(path);
                const url = 'https://reqres.in/api' + path;
                const response = await axios.patch(url, body);
                setStatusCode(response.status);
                setResultResponse(JSON.stringify(response.data, null, 2)); 
                }

                    const del = async (path: string) => {
                    setRequestUrl(path);
                    const url = 'https://reqres.in/api' + path;
                    const response = await axios.delete(url);
                    setStatusCode(response.status);
                    setResultResponse(JSON.stringify(response.data, null, 2));
                    
                };

    return(
    <section className="api">
                    <div className="endpoints">
                    <ul>
                        <li><button onClick={() => get('/users?page=2')}>GET</button>LIST USERS</li>
                        <li><button onClick={() => get('/users/2')}>GET</button>SINGLE USER</li>
                        <li><button onClick={() => get('/users/23')}>GET</button>SINGLE USER NOT FOUND</li>
                        <li><button onClick={() => get('/unknown')}>GET</button>LIST RESOURCE</li>
                        <li><button onClick={() => get('/unknown/2')}>GET</button>SINGLE RESOURCE</li>
                        <li><button onClick={() => get('/unknown/23')}>GET</button>SINGLE RESOURCE NOT FOUND</li>
                        <li><button onClick={() => post('/users', user2)}>POST</button>CREATE</li>
                        <li><button onClick={() => put('/users/2', user1)}>PUT</button>UPDATE</li>
                        <li><button onClick={() => patch('/users/2', user1)}>PATCH</button>UPDATE</li>
                        <li><button onClick={() => del('/users/2')}>DELETE</button>DELETE</li>
                        <li><button onClick={() => post('/register', user3)}>POST</button>REGISTER - SUCCESSFUL</li>
                        <li><button onClick={() => post('/register', user4)}>POST</button>REGISTER - UNSUCCESSFUL</li>
                        <li><button onClick={() => post('/login', user5)}>POST</button>LOGIN - SUCCESSFUL</li>
                        <li><button onClick={() => post('/login', user6)}>POST</button>LOGIN - UNSUCCESSFUL</li>
                        <li><button onClick={() => get('/users?page=2')}>GET</button>DELAYED RESPONSE</li>
                    </ul>
                    </div>
                    <div className="output">
                        <div className="request">
                            <p className="request-title">
                                <strong>Request 
                                <span className ="link">{requestUrl}</span>
                                </strong>
                            </p>
                            <pre>{resultRequest}</pre>
                        </div>

                        <div className="response">
                            <p className="response-title">
                                <strong>Response
                                    <span className="response-code">{statusCode}</span>
                                </strong>
                            </p>
                            <pre>{resultResponse}</pre>
                        </div>
                    </div>             

            </section>
    )
}    