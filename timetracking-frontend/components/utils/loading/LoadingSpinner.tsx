import ClipLoader from "react-spinners/ClipLoader";
import styles from "../../../styles/utils/loading/LoadingSpinner.module.css";

const LoadingSpinner = ({ color = "#ffeed9" }) => {
  return (
    <div className={styles["container"]}>
      <ClipLoader size={70} color={color} />
    </div>
  );
};

export default LoadingSpinner;
