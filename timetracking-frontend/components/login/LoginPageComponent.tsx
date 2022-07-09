import styles from "../../styles/login/LoginPageComponent.module.css";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import ClearTextInput from "../utils/input/ClearTextInput";
import HiddenTextInput from "../utils/input/HiddenTextInput";

export interface LoginPageComponentProps {
  usernameHandler: ControlledStateHandler<string>;
  passwordHandler: ControlledStateHandler<string>;
}

const LoginPageComponent = ({
  usernameHandler,
  passwordHandler,
}: LoginPageComponentProps) => {
  const { changeHandler: usernameChangeHandler, value: usernameValue } =
    usernameHandler;
  const { changeHandler: passwordChangeHandler, value: passwordValue } =
    passwordHandler;

  return (
    <div className={styles["login-page"]}>
      <h1>Login</h1>
      <div className={styles["username-container"]}>
        <label>Enter username</label>
        <ClearTextInput
          onChange={usernameChangeHandler}
          value={usernameValue}
        />
      </div>
      <div className={styles["password-container"]}>
        <label>Enter password</label>
        <HiddenTextInput
          onChange={passwordChangeHandler}
          value={passwordValue}
        />
      </div>
    </div>
  );
};

export default LoginPageComponent;
