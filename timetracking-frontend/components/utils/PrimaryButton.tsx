import styles from "../../styles/utils/PrimaryButton.module.css";
import ButtonProps from "../../types/ButtonProps";

const PrimaryButton = ({ children, onClick }: ButtonProps) => {
  return (
      <button onClick={onClick} className={styles["button"]}>
        {children}
      </button>
  );
};

export default PrimaryButton;
