import Portal from "../../../higherOrderComponents/Portal";
import styles from "../../../styles/utils/loading/LoadingPage.module.css";
import LoadingSpinner from "./LoadingSpinner";

const LoadingPage = () => {
    return (
        <Portal>
            <div className={styles["container"]}>
                <LoadingSpinner />
            </div>
        </Portal>
    )
}

export default LoadingPage