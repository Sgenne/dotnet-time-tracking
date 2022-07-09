import LoginPageComponent from "../components/login/LoginPageComponent";
import useStringInput from "../hooks/useStringInput";
import ControlledStateHandler from "../types/ControlledStateHandler";

const Login = () => {
  const usernameHandler: ControlledStateHandler<string> = useStringInput();
  const passwordHandler: ControlledStateHandler<string> = useStringInput();

  return (
    <LoginPageComponent
      usernameHandler={usernameHandler}
      passwordHandler={passwordHandler}
    />
  );
};

export default Login;
