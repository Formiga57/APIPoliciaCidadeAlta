import React from 'react';
import {
  BrowserRouter as Router,
  Route,
  Routes,
} from 'react-router-dom';
import PrivateRoute from './components/PrivateRoute';
import { AuthProvider } from './contexts/AuthProvider';

import Login from './pages/Login';
import Panel from './pages/Panel';
import Signin from './pages/Signin';
function App() {
  return (
    <AuthProvider>
    <Router>
      <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/signin" element={<Signin />} />
      <Route element={<PrivateRoute />}>
        <Route path={"/panel"} element={<Panel />}/>
      </Route>
      </Routes>
    </Router>
    </AuthProvider>
  );
}

export default App;
