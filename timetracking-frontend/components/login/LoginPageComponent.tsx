import styles from "../../styles/login/LoginPageComponent.module.css";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import ErrorMessage from "../utils/ErrorMessage";
import ClearTextInput from "../utils/input/ClearTextInput";
import HiddenTextInput from "../utils/input/HiddenTextInput";
import PrimaryButton from "../utils/PrimaryButton";

export interface LoginPageComponentProps {
  usernameHandler: ControlledStateHandler<string>;
  passwordHandler: ControlledStateHandler<string>;
  onSubmit: () => void;
  errorMessage: string;
}

const LoginPageComponent = ({
  usernameHandler,
  passwordHandler,
  onSubmit,
  errorMessage,
}: LoginPageComponentProps) => {
  const { changeHandler: usernameChangeHandler, value: usernameValue } =
    usernameHandler;
  const { changeHandler: passwordChangeHandler, value: passwordValue } =
    passwordHandler;

  return (
    <div className={styles["login-page"]}>
      <h1>Login</h1>
      <ErrorMessage>{errorMessage}</ErrorMessage>
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
      <div className={styles["submit-container"]}>
        <PrimaryButton onClick={onSubmit}>Login</PrimaryButton>
      </div>
    </div>
  );
};

export default LoginPageComponent;
