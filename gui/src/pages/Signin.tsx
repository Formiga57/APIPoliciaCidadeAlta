import React,{useContext, useState} from 'react'
import styled from 'styled-components';
import { CheckLogin } from '../api/endpoints/login';
import { CheckSignin } from '../api/endpoints/signin';
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

const Signin : React.FC = () => {
  const {setToken} = useContext(AuthContext)
  const [userName, setUserName] = useState("")
  const [password, setPassword] = useState("")
  const FormSubmit = () =>{
    CheckSignin(userName,password).then(res=>{
      setToken(res)
    }).catch(console.log)
  }
  return (
    <CenterBox>
      Signin
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

export default Signin