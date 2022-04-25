import {createContext, useState} from "react";

interface IProps {
    children?: React.ReactNode;
}
interface IAuthContext{
    token?:string,
    setToken:(token?:string)=>void,
}

export const AuthContext = createContext<IAuthContext>({
    setToken(token?: string): void {
    }
});
export const AuthProvider: React.FC<IProps>  = ({children}) =>{
    const [token, setToken] = useState<string | undefined>("");
    return (
    <AuthContext.Provider value={{token,setToken}}>
        {children}
    </AuthContext.Provider>
    )
}