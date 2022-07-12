import { ReactElement } from "react";
import styles from "../../styles/utils/ErrorMessage.module.css";

export interface ErrorMessageProps {
  children: ReactElement | string;
}

const ErrorMessage = ({ children }: ErrorMessageProps) => {
  if (!children) {
    return <div></div>;
  }

  return (
    <div className={styles["container"]}>
      <p className={styles["message"]}></p>
    </div>
  );
};

export default ErrorMessage;
