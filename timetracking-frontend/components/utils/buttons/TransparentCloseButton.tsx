import styles from "../../../styles/utils/buttons/TransparentCloseButton.module.css";
import CloseIcon from "../icons/CloseIcon";

const TransparentCloseButton = () => {
    return (
        <button className={styles["button"]}>
            <CloseIcon />
        </button>
    )
}

export default TransparentCloseButton
