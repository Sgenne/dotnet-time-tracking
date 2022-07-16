import ClipLoader from "react-spinners/ClipLoader";
import styles from "../../../styles/utils/loading/LoadingSpinner.module.css";

const LoadingSpinner = () => {
  return (
    <div className={styles["container"]}>
      <ClipLoader />
    </div>
  );
};

export default LoadingSpinner;
