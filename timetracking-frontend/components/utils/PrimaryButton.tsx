import styles from "../../styles/utils/PrimaryButton.module.css";
import ButtonProps from "../../types/ButtonProps";

const PrimaryButton = ({ children, onClick }: ButtonProps) => {
  return (
    <div className={styles["button-container"]}>
      <button onClick={onClick} className={styles["button"]}>
        {children}
      </button>
    </div>
  );
};

export default PrimaryButton;
