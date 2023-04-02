import React from "react";
import { Outlet, Link } from "react-router-dom";
const Layout = ({ user }) => {
  return (
    <>
      <div>
        {user.isAuthenticated ? (
          <h4>User: {user.userName}</h4>
        ) : (
          <h4>User: Guest</h4>
        )}
      </div>
      <nav>
        <Link to="/">Main</Link> <span> </span>
        <Link to="/tests">Tests</Link> <span> </span>
        <Link to="/register">Register</Link> <span> </span>
        <Link to="/login">Log In</Link> <span> </span>
        <Link to="/logoff">Exit</Link>
      </nav>
      <Outlet />
    </>
  );
};
export default Layout;
