import styles from "../../../styles/utils/buttons/PrimaryButton.module.css";
import ButtonProps from "../../../types/ButtonProps";

const PrimaryButton = ({ children, onClick }: ButtonProps) => {
  return (
    <button onClick={onClick} className={styles["button"]}>
      {children}
    </button>
  );
};

export default PrimaryButton;
