import {client} from "../criminalCodeClient";

export const CheckLogin = (username:string,password:string):Promise<string> =>{
    return new Promise(async(res,rej)=>{
        client.post<string>("/Login",{
            UserName:username,
            Password:password
        }).then(data=>{
            if(data.status !== 200){
                rej(data.data)
            }
            res(data.data)
        })
    })
}