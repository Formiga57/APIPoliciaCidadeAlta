import React,{useState,useContext} from 'react'
import { useNavigate  } from 'react-router-dom';
import styled from 'styled-components';
import { CheckLogin } from '../api/endpoints/login';
import { AuthContext } from '../contexts/AuthProvider';

const CenterBox = styled.div`
position: absolute;
left:50%;
top:50%;
transform: translate(-50%,-50%);
background-color: #c8c8c8;
padding:25px;
text-align: center;
`

const Login : React.FC = () => {
  const {setToken} = useContext(AuthContext)
  const [userName, setUserName] = useState("")
  const [password, setPassword] = useState("")
  const navigate = useNavigate();
  const FormSubmit = () =>{
    CheckLogin(userName,password).then(res=>{
      setToken(res)
      navigate("/panel")
    }).catch(console.log)
  }
  return (
    <CenterBox>
      Login
      <br />
      <br />
      <form onSubmit={(e)=>{
        e.preventDefault()
        FormSubmit()
      }}>
      <input type="text" placeholder='Usuário' onChange={(e)=>setUserName(e.target.value)}/>
      <br />
      <input type="password" placeholder='Senha' onChange={(e)=>setPassword(e.target.value)}/>
      <br />
      <button type="submit">Enviar</button>
      </form>
    </CenterBox>
  )
}

export default Login