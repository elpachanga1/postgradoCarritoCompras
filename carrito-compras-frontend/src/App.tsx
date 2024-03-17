import {  Navigate } from "react-router-dom";
import { Routes, Route } from "react-router-dom";
import { AuthMenu } from "./components/Auth";
import Home from "./components/Home";
import { NoMatch } from "./components/NoMatch";
import 'bootstrap/dist/css/bootstrap.min.css';
function App() {
  return (
    <Routes>
      	<Route path="/" element={<Navigate to="/login" replace={true} />}></Route>
        <Route path="login" element={<AuthMenu />} />
        <Route path="home" element={<Home />} />
        <Route path="*" element={<NoMatch />} />      
    </Routes>
  );
}

export default App;
