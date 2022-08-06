import { ReactElement } from "react";
import styles from "../../styles/utils/WhiteTopBar.module.css";

export interface WhiteTopBarProps {
    children: ReactElement
}

const WhiteTopBar = ({ children }: WhiteTopBarProps) => <div className={styles["top-bar"]}>
    {children}
</div>


export default WhiteTopBar