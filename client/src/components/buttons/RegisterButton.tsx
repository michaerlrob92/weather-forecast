import React from "react";
import { useAuth0 } from "@auth0/auth0-react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

export const RegisterButton: React.FC = () => {
  const { loginWithRedirect } = useAuth0();
  return (
    <button
      className="btn btn-primary"
      onClick={() => loginWithRedirect({ screen_hint: "signup" })}
    >
      <FontAwesomeIcon icon={["fas", "user-plus"]} /> Register
    </button>
  );
};
