import Router from "next/router";
import { useState } from "react";
import { useAuthContext } from "../auth/AuthContext";
import { sendLoginRequest } from "../auth/AuthRequests";
import { useNoNavbarLayout } from "../components/layouts/NoNavbarLayout";
import LoginPageComponent from "../components/login/LoginPageComponent";
import User from "../domain/User";
import useStringInput from "../hooks/useStringInput";
import LoginResponse from "../types/apiResponses/LoginResponse";
import ControlledStateHandler from "../types/ControlledStateHandler";
import PageWithLayout from "../types/PageWithLayout";
import Result from "../utils/Result";

const Login: PageWithLayout = () => {
  const usernameHandler: ControlledStateHandler<string> = useStringInput();
  const passwordHandler: ControlledStateHandler<string> = useStringInput();
  const [errorMessage, setErrorMessage] = useState("");

  const { value: usernameValue } = usernameHandler;
  const { value: passwordValue } = passwordHandler;
  const authContext = useAuthContext();

  const submitHandler = async () => {
    const result: Result<LoginResponse> = await sendLoginRequest(
      usernameValue,
      passwordValue
    );

    if (!result.value) {
      const errorMessage: string = result.message || "Login failed";
      setErrorMessage(errorMessage);
      return;
    }

    setErrorMessage("");
    const user: User = {
      username: usernameValue,
    };
    const accessToken = result.value.accessToken;
    authContext.onSignIn(accessToken, user);
    Router.push("/")
  };

  return (
    <LoginPageComponent
      usernameHandler={usernameHandler}
      passwordHandler={passwordHandler}
      onSubmit={submitHandler}
      errorMessage={errorMessage}
    />
  );
};

Login.getLayout = useNoNavbarLayout;

export default Login;
