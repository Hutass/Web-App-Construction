import React, { useEffect, useState } from "react";
import ReactDOM from "react-dom/client";
import Test from "./Components/Test/Test";
import TestCreate from "./Components/TestCreate/TestCreate";
import Layout from "./Components/Layout/Layout";
import Register from "./Components/Register/Register";
import LogIn from "./Components/LogIn/LogIn";
import LogOff from "./Components/LogOff/LogOff";
import { BrowserRouter, Route, Routes } from "react-router-dom";
//import './index.css';
//import App from './App';
//import reportWebVitals from './reportWebVitals';

const App = () => {
  const [tests, setTests] = useState([]);
  const addTest = (test) => setTests([...tests, test]);
  const removeTest = (removeId) =>
    setTests(tests.filter(({ testId }) => testId !== removeId));
  const [user, setUser] = useState({ isAuthenticated: false, userName: "" });

  useEffect(() => {
    const getUser = async () => {
      return await fetch("api/account/isauthenticated")
        .then((response) => {
          response.status === 401 &&
            setUser({ isAuthenticated: false, userName: "" });
          return response.json();
        })
        .then(
          (data) => {
            if (
              typeof data !== "undefined" &&
              typeof data.userName !== "undefined"
            ) {
              setUser({ isAuthenticated: true, userName: data.userName });
            }
          },
          (error) => {
            console.log(error);
          }
        );
    };
    getUser();
  }, [setUser]);

  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Layout user={user} />}>
          <Route index element={<h3>Main page</h3>} />
          <Route
            path="/tests"
            element={
              <>
                <TestCreate user={user} addTest={addTest} />
                <Test
                  user={user}
                  tests={tests}
                  setTests={setTests}
                  removeTest={removeTest}
                />
              </>
            }
          />
          <Route
            path="/register"
            element={<Register user={user} setUser={setUser} />}
          />
          <Route
            path="/login"
            element={<LogIn user={user} setUser={setUser} />}
          />
          <Route path="/logoff" element={<LogOff setUser={setUser} />} />
          <Route path="*" element={<h3>404</h3>} />
        </Route>
      </Routes>
    </BrowserRouter>
  );
};

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  //<React.StrictMode>
  <App />
  //</React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
//reportWebVitals();
