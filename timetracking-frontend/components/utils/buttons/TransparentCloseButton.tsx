import styles from "../../../styles/utils/buttons/TransparentCloseButton.module.css";
import CloseIcon from "../icons/CloseIcon";

export interface TransparentCloseButtonProps {
    onClick: () => void;
}

const TransparentCloseButton = ({ onClick }: TransparentCloseButtonProps) => {
    return (
        <button className={styles["button"]} onClick={onClick}>
            <CloseIcon />
        </button>
    )
}

export default TransparentCloseButton
