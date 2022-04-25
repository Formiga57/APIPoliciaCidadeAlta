import {useContext} from "react";
import { Navigate, Outlet } from "react-router-dom";
import { AuthContext } from "../contexts/AuthProvider";

const PrivateRoute: React.FC= () =>{
    const {token} = useContext(AuthContext);
    return token ? <Outlet />  : <Navigate to="/" replace />
}
export default PrivateRoute;