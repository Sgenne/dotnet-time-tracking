import styles from "../../styles/login/LoginPageComponent.module.css";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import ErrorMessage from "../utils/ErrorMessage";
import ClearTextInput from "../utils/input/ClearTextInput";
import HiddenTextInput from "../utils/input/HiddenTextInput";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import { useState } from "react";

export interface LoginPageComponentProps {
  usernameHandler: ControlledStateHandler<string>;
  passwordHandler: ControlledStateHandler<string>;
  onSubmit: () => void;
  errorMessage: string;
  isLoading: boolean;
}

const LoginPageComponent = ({
  usernameHandler,
  passwordHandler,
  onSubmit,
  errorMessage,
  isLoading
}: LoginPageComponentProps) => {
  const { onChange: usernameChangeHandler, value: usernameValue } =
    usernameHandler;
  const { onChange: passwordChangeHandler, value: passwordValue } =
    passwordHandler;

  const pageClassName = `${styles["page-container"]} ${isLoading ? styles["loading"] : ""}`

  return (
    <div className={pageClassName}>
      <div className={styles["login-section"]}>
        <h1 className={styles["page-title"]}>Login</h1>
        <div className={`${styles["error-message-container"]}`}>
          <ErrorMessage>{errorMessage}</ErrorMessage>
        </div>
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
        <div className={`${styles["submit-container"]}`}>
          <div className={styles["submit-button"]}>
            <PrimaryButton isLoading={isLoading} onClick={onSubmit}>Login</PrimaryButton>
          </div>
        </div>
      </div>
    </div>
  );
};

export default LoginPageComponent;
