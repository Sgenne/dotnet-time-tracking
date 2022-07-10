import { sendLoginRequest } from "../auth/AuthRequests";
import LoginPageComponent from "../components/login/LoginPageComponent";
import useStringInput from "../hooks/useStringInput";
import ControlledStateHandler from "../types/ControlledStateHandler";

const Login = () => {
  const usernameHandler: ControlledStateHandler<string> = useStringInput();
  const passwordHandler: ControlledStateHandler<string> = useStringInput();

  const { value: usernameValue } = usernameHandler;
  const { value: passwordValue } = passwordHandler;

  const submitHandler = () => {
    console.log(`Submitting: ${usernameValue}, ${passwordValue}`);
    sendLoginRequest(usernameValue, passwordValue);
  };

  return (
    <LoginPageComponent
      usernameHandler={usernameHandler}
      passwordHandler={passwordHandler}
      onSubmit={submitHandler}
    />
  );
};

export default Login;
