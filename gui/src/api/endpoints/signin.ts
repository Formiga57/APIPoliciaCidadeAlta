import {client} from "../criminalCodeClient";

export const CheckSignin = (username:string,password:string):Promise<string> =>{
    return new Promise(async(res,rej)=>{
        client.post<string>("/Signin",{
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