import React from "react";
import { LoginButton } from "../components/buttons/LoginButton";
import { RegisterButton } from "../components/buttons/RegisterButton";

export const LoginRequired: React.FC = () => {
  return (
    <div className="row justify-content-center">
      <div className="col-lg-6 col-xl-4">
        <h1 className="text-center mb-5 display-5">Login Required</h1>
        <div className="d-flex align-items-center justify-content-center btn-split">
          <LoginButton />
          <RegisterButton />
        </div>
      </div>
    </div>
  );
};
