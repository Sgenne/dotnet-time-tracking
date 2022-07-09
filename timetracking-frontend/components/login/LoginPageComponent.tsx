import styles from "../../styles/login/LoginPageComponent.module.css";
import ClearTextInput from "../utils/input/ClearTextInput";
import HiddenTextInput from "../utils/input/HiddenTextInput";

const LoginPageComponent = () => {
  return (
    <div className={styles["login-page"]}>
      <h1>Login</h1>
      <div className={styles["username-container"]}>
        <label>Enter username</label>
        <ClearTextInput onChange={(s) => s} value="" />
      </div>
      <div className={styles["password-container"]}>
        <label>Enter password</label>
        <HiddenTextInput onChange={(s) => s} value="" />
      </div>
    </div>
  );
};

export default LoginPageComponent;
