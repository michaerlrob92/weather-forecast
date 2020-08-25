import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export const LoginButton: React.FC = () => {
  const { loginWithRedirect } = useAuth0();
  return (
    <button
      className="btn btn-outline-primary"
      onClick={() => loginWithRedirect()}
    >
      <FontAwesomeIcon icon={["fas", "sign-in-alt"]} /> Login
    </button>
  );
};
