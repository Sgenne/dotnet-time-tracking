import { ReactElement } from "react";
import Portal from "../../higherOrderComponents/Portal";
import styles from "../../styles/utils/Modal.module.css";

const Modal = ({ children }: { children: ReactElement }) => {
    return <Portal>
        <>
            <div className={styles["background"]} />
            <div className={styles["modal"]}>
                {children}
            </div>
        </>
    </Portal>

}

export default Modal