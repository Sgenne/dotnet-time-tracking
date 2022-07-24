import styles from "../../../styles/utils/loading/LoadingPage.module.css";
import LoadingSpinner from "./LoadingSpinner";

const LoadingPage = () => {
    return (
        <div className={styles["container"]}>
            <LoadingSpinner />
        </div>
    )
}

export default LoadingPage