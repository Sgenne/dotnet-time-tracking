import styles from "../../../styles/utils/buttons/PrimaryButton.module.css";
import ButtonProps from "../../../types/ButtonProps";

const PrimaryButton = ({ children, onClick, isLoading = false }: ButtonProps) => {

  const className = `${styles["button"]} ${isLoading ? styles["loading"] : ""}`

  return (
    <button onClick={onClick} className={className}>
      {children}
    </button>
  );
};

export default PrimaryButton;
